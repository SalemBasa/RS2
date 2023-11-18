using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class VehicleModelProfile : BaseProfile
    {
        public VehicleModelProfile()
        {
            CreateMap<VehicleModelDto, VehicleModel>().ReverseMap();

            CreateMap<VehicleModelUpsertDto, VehicleModel>();
        }
    }
}


