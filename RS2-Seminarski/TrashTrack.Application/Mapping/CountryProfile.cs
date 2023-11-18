using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class CountryProfile : BaseProfile
    {
        public CountryProfile()
        {
            CreateMap<CountryDto, Country>().ReverseMap();

            CreateMap<CountryUpsertDto, Country>().ReverseMap();
        }
    }
}
