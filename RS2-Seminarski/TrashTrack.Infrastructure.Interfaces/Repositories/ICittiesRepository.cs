using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Interfaces
{
    public interface ICitiesRepository : IBaseRepository<City, int, CitiesSearchObject>
    {
        Task<IEnumerable<City>> GetByCountryIdAsync(int countryId, CancellationToken cancellationToken = default);
    }
}