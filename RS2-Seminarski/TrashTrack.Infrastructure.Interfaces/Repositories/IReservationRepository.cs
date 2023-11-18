using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Interfaces;

public interface IReservationRepository : IBaseRepository<Reservation, int, ReservationSearchObject>
{
        Task<int> GetReservationCountAsync(CancellationToken cancellationToken = default);
}
