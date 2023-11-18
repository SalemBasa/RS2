using Microsoft.EntityFrameworkCore;
using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Infrastructure;

public class ReservationRepository : BaseRepository<Reservation, int, ReservationSearchObject>, IReservationRepository
{
	public ReservationRepository(DatabaseContext databaseContext) : base(databaseContext)
	{
		
	}

	public override async Task<PagedList<Reservation>> GetPagedAsync(ReservationSearchObject searchObject, CancellationToken cancellationToken = default)
	{
		return await DbSet.Include(c=>c.User)
						  .Include(x => x.Service)
						  .Where(c=>searchObject.Status== null || c.Status == searchObject.Status)
						  .ToPagedListAsync(searchObject, cancellationToken);
	}

    public async Task<int> GetReservationCountAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet.CountAsync(cancellationToken);
    }
}
