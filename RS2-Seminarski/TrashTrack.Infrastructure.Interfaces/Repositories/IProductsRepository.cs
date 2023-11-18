using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Interfaces
{
    public interface IProductsRepository : IBaseRepository<Product, int, ProductSearchObject>
    {
    }
}

