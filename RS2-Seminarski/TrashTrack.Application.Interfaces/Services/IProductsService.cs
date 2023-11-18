using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application.Interfaces
{
    public interface IProductsService : IBaseService<int, ProductDto, ProductUpsertDto, ProductSearchObject>
    {
        List<Product> Recommend(int userId);
    }
}




