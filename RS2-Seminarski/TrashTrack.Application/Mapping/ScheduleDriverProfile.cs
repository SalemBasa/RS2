using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class ScheduleDriverProfile : BaseProfile
    {
        public ScheduleDriverProfile()
        {
            CreateMap<ScheduleDriverDto, ScheduleDriver>().ReverseMap();

            CreateMap<ScheduleDriverUpsertDto, ScheduleDriver>().ReverseMap();
        }
    }
}
