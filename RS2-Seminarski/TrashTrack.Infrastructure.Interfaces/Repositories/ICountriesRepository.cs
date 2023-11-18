using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Interfaces
{
    public interface ICountriesRepository : IBaseRepository<Country, int, CountriesSearchObject>
    {
    }
}
