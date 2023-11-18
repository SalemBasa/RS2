using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Interfaces
{
    public interface IOrdersRepository : IBaseRepository<Order, int, OrderSearchObject>
    {
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId, CancellationToken cancellationToken = default);
    }
}

