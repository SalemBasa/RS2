using AutoMapper;
using FluentValidation;
using TrashTrack.Application.Interfaces;
using TrashTrack.Core;
using TrashTrack.Infrastructure;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application;

public class ReservationService : BaseService<Reservation, ReservationDto, ReservationUpsertDto, ReservationSearchObject, IReservationRepository>, IReservationService
{
	private readonly IServiceRepository _serviceRepository;
	private readonly IUsersRepository _usersRepository;


	public ReservationService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<ReservationUpsertDto> validator, IServiceRepository serviceRepository, IUsersRepository usersRepository) : base(mapper, unitOfWork, validator)
	{
		_serviceRepository = serviceRepository;
		_usersRepository = usersRepository;
	}

	public override async Task<ReservationDto> AddAsync(ReservationUpsertDto dto, CancellationToken cancellationToken = default)
	{
		var reservation = Mapper.Map<Reservation>(dto);
		
		var service = await _serviceRepository.GetByIdAsync(dto.ServiceId);
		
		reservation.Price = service!.Price;
		reservation.Status = ReservationStatus.InProgress;
		
		await CurrentRepository.AddAsync(reservation, cancellationToken);
		await UnitOfWork.SaveChangesAsync(cancellationToken);
		return Mapper.Map<ReservationDto>(reservation);
	}
	
	public async Task<ReservationDto> PayWithBalanceAsync(ReservationUpsertDto dto, CancellationToken cancellationToken = default)
	{
		var reservation = Mapper.Map<Reservation>(dto);
		
		var service = await _serviceRepository.GetByIdAsync(dto.ServiceId);
		
		var user = await _usersRepository.GetByIdAsync(dto.UserId);
		
		reservation.Price = service!.Price;
		reservation.Status = ReservationStatus.InProgress;
		user!.Balance -= reservation.Price;
		
		await CurrentRepository.AddAsync(reservation, cancellationToken);
		await UnitOfWork.SaveChangesAsync(cancellationToken);
		return Mapper.Map<ReservationDto>(reservation);
	}

    public async Task<int> GetReservationCountAsync(CancellationToken cancellationToken = default)
    {
        var count = await CurrentRepository.GetReservationCountAsync(cancellationToken);
        return count;
    }

    public async Task<int> UpdateReservationStatusAsync(ReservationUpsertDto dto, CancellationToken cancellationToken = default)
	{
		var reservation = await CurrentRepository.GetByIdAsync(dto.Id.GetValueOrDefault(), cancellationToken);
		if (reservation == null)
			throw new Exception("Reservation not found");

		reservation.Status = dto.Status;

		CurrentRepository.Update(reservation);
		await UnitOfWork.SaveChangesAsync(cancellationToken);

		return Mapper.Map<int>(reservation.Status);
	}
}
