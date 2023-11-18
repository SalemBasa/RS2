using AutoMapper;
using FluentValidation;

using TrashTrack.Core;
using TrashTrack.Application.Interfaces;
using TrashTrack.Infrastructure;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application
{
    public class CitiesService : BaseService<City, CityDto, CityUpsertDto, CitiesSearchObject, ICitiesRepository>, ICitiesService
    {
        public CitiesService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<CityUpsertDto> validator) : base(mapper, unitOfWork, validator)
        {

        }

        public async Task<IEnumerable<CityDto>> GetByCountryIdAsync(int countryId, CancellationToken cancellationToken = default)
        {
            var cities = await CurrentRepository.GetByCountryIdAsync(countryId, cancellationToken);

            return Mapper.Map<IEnumerable<CityDto>>(cities);
        }
    }
}
