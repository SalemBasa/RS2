using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class PhotoProfile : BaseProfile
    {
        public PhotoProfile()
        {
            CreateMap<PhotoDto, Photo>().ReverseMap();

            CreateMap<PhotoUpsertDto, Photo>();
        }
    }
}

