using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class GarbageProfile : BaseProfile
    {
        public GarbageProfile()
        {
            CreateMap<GarbageDto, Garbage>().ReverseMap();

            CreateMap<GarbageUpsertDto, Garbage>();
        }
    }
}
