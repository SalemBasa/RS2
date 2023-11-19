using Microsoft.EntityFrameworkCore;
using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Infrastructure
{
    public class OrdersRepository : BaseRepository<Order, int, OrderSearchObject>, IOrdersRepository
    {
        public OrdersRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            return await DbSet.AsNoTracking()
                              .Where(o => o.UserId == userId)
                              .Include(o => o.User)
                              .Include(o => o.OrderDetails)
                              .ToListAsync();
        }

        public override Task<PagedList<Order>> GetPagedAsync(OrderSearchObject searchObject, CancellationToken cancellationToken = default)
        {
            return DbSet.AsNoTracking()
                .Include(o => o.User)
                .Include(o => o.OrderDetails).ThenInclude(i => i.Product)
                .Where(c => searchObject.OrderNumber == null || c.OrderNumber.ToLower().Contains(searchObject.OrderNumber.ToLower()))
                .Where(c => searchObject.isCanceled == null || c.isCanceled == searchObject.isCanceled)
                .Where(c => searchObject.UserId == null || c.UserId == searchObject.UserId)
                .Select(order => new Order()
                {
                    Id = order.Id,
                    OrderNumber = order.OrderNumber,
                    OrderDate = order.OrderDate,
                    Total = order.Total,
                    UserId = order.UserId,
                    User = order.User,
                    isCanceled = order.isCanceled,
                    OrderDetails = order.OrderDetails.Select(od => new OrderDetails()
                    {
                        Id = od.Id,
                        Quantity = od.Quantity,
                        Product = new Product()
                        {
                            Id = od.Product.Id,
                            Name = od.Product.Name,
                            Price = od.Product.Price
                        }
                    }).ToList(),
                })
                .ToPagedListAsync(searchObject, cancellationToken);
        }
    }
}

