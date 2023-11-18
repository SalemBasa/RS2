using AutoMapper;
using FluentValidation;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using TrashTrack.Application.Interfaces;
using TrashTrack.Core;
using TrashTrack.Infrastructure;
using TrashTrack.Infrastructure.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrashTrack.Application
{
	public class SchedulesService : BaseService<Schedule, ScheduleDto, ScheduleUpsertDto, SchedulesSearchObject, ISchedulesRepository>,
									ISchedulesService
	{
		private readonly DatabaseContext _databaseContext;
		private readonly IMapper _mapper;

		public SchedulesService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<ScheduleUpsertDto> validator, DatabaseContext databaseContext) : base(mapper, unitOfWork, validator)
		{
			_databaseContext = databaseContext;
			_mapper = mapper;
		}

		public override async Task<ScheduleDto> AddAsync(ScheduleUpsertDto dto, CancellationToken cancellationToken = default)
		{
			var schedule = new Schedule();
			schedule.PickupDate = dto.PickupDate;
			schedule.Status = PickupStatus.Pending;
			schedule.VehicleId = dto.VehicleId;

			_databaseContext.Add(schedule);
			_databaseContext.SaveChanges();

			foreach (var garabage in dto.ScheduleGarbages)
			{
				var scheduleGarbage = new ScheduleGarbage();
				scheduleGarbage.ScheduleId = schedule.Id;
				scheduleGarbage.GarbageId = garabage.GarbageId;

				_databaseContext.Add(scheduleGarbage);
			}

			_databaseContext.SaveChanges();

			foreach (var driver in dto.ScheduleDrivers)
			{
				var scheduleDriver = new ScheduleDriver();
				scheduleDriver.ScheduleId = schedule.Id;
				scheduleDriver.DriverId = driver.DriverId;

				_databaseContext.Add(scheduleDriver);
			}

			_databaseContext.SaveChanges();

			return _mapper.Map<ScheduleDto>(schedule);
		}

		public async Task<IEnumerable<ScheduleDto>> GetScheduleByIdAsync(int driverId, CancellationToken cancellationToken = default)
		{
			var schedules = await CurrentRepository.GetScheduleByIdAsync(driverId, cancellationToken);

			return Mapper.Map<IEnumerable<ScheduleDto>>(schedules);
		}

		public async Task<int> UpdatePickupStatusAsync(ScheduleDto dto, CancellationToken cancellationToken = default)
		{
			var schedule = await CurrentRepository.GetByIdAsync(dto.Id, cancellationToken);

			if (schedule == null)
				throw new Exception("Schedule not found");

			schedule.Status = dto.Status;

			foreach (var garbage in schedule.ScheduleGarbages.Select(x => x))
			{
				var garbageEntity = await _databaseContext.Garbages.FindAsync(garbage.GarbageId);
				garbageEntity!.Occupancy = 0;
			}

			CurrentRepository.Update(schedule);
			await UnitOfWork.SaveChangesAsync(cancellationToken);

			return Mapper.Map<int>(schedule.Status);
		}

        static object isLocked = new object();
		static MLContext mlContext = null;
		static ITransformer model = null;

		public Schedule Recommend(int userId)
		{
			var all = _databaseContext.Schedules.Include(x => x.ScheduleGarbages).ThenInclude(x => x.Garbage).ToList();
			List<int> allGarbages = new List<int>();

			foreach (var item in all)
			{
				foreach (var item2 in item.ScheduleGarbages)
				{
					allGarbages.Add(item2.GarbageId);
				}
			}

			if (allGarbages.Distinct().Count() < 2)
				return null;

			var scheduleGarbage = _databaseContext.Schedules
												  .Include(x => x.ScheduleGarbages)
												  .ThenInclude(x => x.Garbage)
												  .Where(x => x.ScheduleDrivers.Any(x => x.DriverId == userId))
												  .ToList();

			if (scheduleGarbage.Count == 0)
				return null;

			int id;
			List<int> garbage = new List<int>();

			foreach (var item in scheduleGarbage)
			{
				foreach (var item2 in item.ScheduleGarbages)
				{
					garbage.Add(item2.GarbageId);
				}
			}

			if (garbage.Distinct().Count() >= 2)
			{
				var list = garbage.Distinct();
				Random rand = new Random();
				int r = rand.Next(list.Count() - 1);
				id = garbage.ElementAt(r);
			}
			else
			{
				id = garbage.ElementAt(0);
			}

			lock (isLocked)
			{
				if (mlContext == null)
				{
					mlContext = new MLContext();

					var tmpData = _databaseContext.Schedules.Include("ScheduleGarbages").ToList();

					var data = new List<GarbageEntry>();

					foreach (var x in tmpData)
					{
						if (x.ScheduleGarbages.Count > 1)
						{
							var distinctItemId = x.ScheduleGarbages.Select(y => y.GarbageId).ToList();

							distinctItemId.ForEach(
								y =>
								{
									var relatedItems = x.ScheduleGarbages.Where(z => z.GarbageId != y);

									foreach (var z in relatedItems)
									{
										data.Add(
											new GarbageEntry()
											{
												GarbageID = (uint) y,
												CoPurchaseGarbageID = (uint) z.GarbageId,
											}
										);
									}
								}
							);
						}
					}

					var traindata = mlContext.Data.LoadFromEnumerable(data);

					MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
					options.MatrixColumnIndexColumnName = nameof(GarbageEntry.GarbageID);
					options.MatrixRowIndexColumnName = nameof(GarbageEntry.CoPurchaseGarbageID);
					options.LabelColumnName = "Label";
					options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
					options.Alpha = 0.01;
					options.Lambda = 0.025;
					options.NumberOfIterations = 100;
					options.C = 0.00001;

					var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);

					model = est.Fit(traindata);
				}
			}

			List<Garbage> allItems = _databaseContext.Garbages.ToList();

			var predictionResult = new List<Tuple<Garbage, float>>();

			foreach (var item in allItems)
			{
				var predictionEngine = mlContext.Model.CreatePredictionEngine<GarbageEntry, Copurchase_prediction>(model);

				var prediction = predictionEngine.Predict(
					new GarbageEntry()
					{
						GarbageID = (uint) id,
						CoPurchaseGarbageID = (uint) item.Id
					}
				);

				predictionResult.Add(new Tuple<Garbage, float>(item, prediction.Score));
			}

			var finalResult = predictionResult.OrderByDescending(x => x.Item2)
											  .Select(x => x.Item1)
											  .ToList();

			var recommendedScheduleGarbages = new List<ScheduleGarbage>();

			foreach (var result in predictionResult)
			{
				var scheduleGarbagePrediction = new ScheduleGarbage
				{
					GarbageId = result.Item1.Id
				};

				recommendedScheduleGarbages.Add(scheduleGarbagePrediction);
			}

			var allVehicles = _databaseContext.Vehicles.ToList();

			if (allVehicles.Count == 0)
			{
				return null;
			}

			Random random = new Random();
			int randomIndex = random.Next(allVehicles.Count);

			var randomVehicle = allVehicles[randomIndex].Id;

			var recommendedSchedule = new Schedule
			{
				PickupDate = DateTime.Now.AddDays(1),
				Status = PickupStatus.Pending,
				VehicleId = randomVehicle,
				ScheduleGarbages = predictionResult
								   .Select(
									   result => new ScheduleGarbage
									   {
										   GarbageId = result.Item1.Id
									   }
								   )
								   .ToList(),
				ScheduleDrivers = scheduleGarbage.Distinct()
												 .Select(
													 sg => new ScheduleDriver
													 {
														 DriverId = userId,
													 }
												 )
												 .Distinct()
												 .ToList()
			};

			return recommendedSchedule;
		}

		public class Copurchase_prediction
		{
			public float Score { get; set; }
		}

		public class GarbageEntry
		{
			[KeyType(count: 10)]
			public uint GarbageID { get; set; }

			[KeyType(count: 10)]
			public uint CoPurchaseGarbageID { get; set; }

			public float Label { get; set; }
		}
	}
}
