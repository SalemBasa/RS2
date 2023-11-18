using Microsoft.EntityFrameworkCore;
using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Infrastructure
{
	public class SchedulesRepository : BaseRepository<Schedule, int, SchedulesSearchObject>,
									   ISchedulesRepository
	{
		public SchedulesRepository(DatabaseContext databaseContext) : base(databaseContext)
		{
		}

		public async Task<IEnumerable<Schedule>> GetScheduleByIdAsync(int driverId, CancellationToken cancellationToken = default)
		{
			return await DbSet.AsNoTracking()
							  .Include(sd => sd.ScheduleDrivers)
							  .Include(sg => sg.ScheduleGarbages)
							  .Where(s => s.ScheduleDrivers.Any(sd => sd.DriverId == driverId))
							  .ToListAsync(cancellationToken);
		}

        public override Task<PagedList<Schedule>> GetPagedAsync(SchedulesSearchObject searchObject, CancellationToken cancellationToken = default)
        {
            return DbSet.AsNoTracking()
                .Include(s => s.ScheduleDrivers)
				.ThenInclude(sd => sd.Driver)
                .Include(s => s.ScheduleGarbages)
				.Include(s => s.Vehicle)
                .Where(s => searchObject.Status == null || s.Status == searchObject.Status)
                .Where(s => searchObject.DriverId == null || s.ScheduleDrivers.Any(sd => sd.DriverId == searchObject.DriverId))
                .ToPagedListAsync(searchObject, cancellationToken);
        }

		public override async Task<Schedule?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
		{
			return await DbSet.AsNoTracking()
							  .Where(x => x.Id == id)
							  .Include(sd => sd.ScheduleDrivers)
							  .Include(sg => sg.ScheduleGarbages)
							  .FirstOrDefaultAsync();
		}
	}
}
