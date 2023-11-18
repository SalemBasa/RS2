using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Infrastructure
{
    public class ProductsRepository : BaseRepository<Product, int, ProductSearchObject>, IProductsRepository
    {
        public ProductsRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public override async Task<PagedList<Product>> GetPagedAsync(ProductSearchObject searchObject, CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(c => searchObject.ProductType == null || c.Type == searchObject.ProductType)
                              .Where(x => searchObject.Name == null || x.Name.ToLower().Contains(searchObject.Name.ToLower()))
                              .ToPagedListAsync(searchObject, cancellationToken);
        }
    }
}

