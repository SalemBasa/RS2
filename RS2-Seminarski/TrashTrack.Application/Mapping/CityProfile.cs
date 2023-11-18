using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class CityProfile : BaseProfile
    {
        public CityProfile()
        {
            CreateMap<CityDto, City>().ReverseMap();

            CreateMap<CityUpsertDto, City>();
        }
    }
}
