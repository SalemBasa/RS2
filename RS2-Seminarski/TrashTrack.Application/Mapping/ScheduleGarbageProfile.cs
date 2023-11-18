using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class ScheduleGarbageProfile : BaseProfile
    {
        public ScheduleGarbageProfile()
        {
            CreateMap<ScheduleGarbageDto, ScheduleGarbage>().ReverseMap();

            CreateMap<ScheduleGarbageUpsertDto, ScheduleGarbage>().ReverseMap();
        }
    }
}
