using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class VehicleProfile : BaseProfile
    {
        public VehicleProfile()
        {
            CreateMap<VehicleDto, Vehicle>().ReverseMap();

            CreateMap<VehicleUpsertDto, Vehicle>();
        }
    }
}


