using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application.Interfaces
{
    public interface IScheduleGarbagesService : IBaseService<int, ScheduleGarbageDto, ScheduleGarbageUpsertDto, BaseSearchObject>
    {

    }
}

