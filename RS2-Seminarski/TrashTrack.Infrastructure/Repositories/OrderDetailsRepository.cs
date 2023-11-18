using Microsoft.EntityFrameworkCore;
using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Infrastructure
{
    public class OrderDetailsRepository : BaseRepository<OrderDetails, int, BaseSearchObject>, IOrderDetailsRepository
    {   
        public OrderDetailsRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public override Task<PagedList<OrderDetails>> GetPagedAsync(BaseSearchObject searchObject, CancellationToken cancellationToken = default)
        {
            return DbSet.AsNoTracking()
                .Include(od => od.Product)
                .ToPagedListAsync(searchObject, cancellationToken);
        }
    }
}

