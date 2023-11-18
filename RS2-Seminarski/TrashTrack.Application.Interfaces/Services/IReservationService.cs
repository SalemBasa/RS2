using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application.Interfaces;

public interface IReservationService : IBaseService<int, ReservationDto, ReservationUpsertDto, ReservationSearchObject>
{
	Task<int> UpdateReservationStatusAsync(ReservationUpsertDto dto, CancellationToken cancellationToken = default);
	
	Task<ReservationDto> PayWithBalanceAsync(ReservationUpsertDto dto, CancellationToken cancellationToken = default);
    Task<int> GetReservationCountAsync(CancellationToken cancellationToken = default);
}
