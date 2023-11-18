using Microsoft.EntityFrameworkCore;
using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Infrastructure
{
    public class CountriesRepository : BaseRepository<Country, int, CountriesSearchObject>, ICountriesRepository
    {
        public CountriesRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override Task<PagedList<Country>> GetPagedAsync(CountriesSearchObject searchObject, CancellationToken cancellationToken = default)
        {
            return DbSet.AsNoTracking()
                .Where(c => searchObject.Name == null || c.Name.ToLower().Contains(searchObject.Name.ToLower()))
                .Where(c => searchObject.IsActive == null || c.IsActive == searchObject.IsActive)
                .ToPagedListAsync(searchObject, cancellationToken);
        }
    }
}
