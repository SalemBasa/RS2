using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application.Interfaces
{
    public interface IOrdersService : IBaseService<int, OrderDto, OrderUpsertDto, OrderSearchObject>
    {
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId, CancellationToken cancellationToken = default);
        Task ToggleOrderStatusAsync(int id, CancellationToken cancellationToken = default);
    }
}






