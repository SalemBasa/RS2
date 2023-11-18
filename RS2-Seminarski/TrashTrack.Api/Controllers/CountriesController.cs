using TrashTrack.Core;
using TrashTrack.Application.Interfaces;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Api.Controllers
{
    public class CountriesController : BaseCrudController<CountryDto, CountryUpsertDto, CountriesSearchObject, ICountriesService>
    {
        public CountriesController(ICountriesService service, ILogger<CountriesController> logger) : base(service, logger)
        {
        }
    }
}
