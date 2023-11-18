using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class ScheduleProfile : BaseProfile
    {
        public ScheduleProfile()
        {
            CreateMap<ScheduleDto, Schedule>().ReverseMap();

            CreateMap<ScheduleUpsertDto, Schedule>();
        }
    }
}

