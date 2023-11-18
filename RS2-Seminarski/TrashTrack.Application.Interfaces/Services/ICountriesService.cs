using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application.Interfaces
{
    public interface ICountriesService : IBaseService<int, CountryDto, CountryUpsertDto, CountriesSearchObject>
    {

    }
}

