using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application.Interfaces
{
    public interface IScheduleDriversService : IBaseService<int, ScheduleDriverDto, ScheduleDriverUpsertDto, BaseSearchObject>
    {
        Task<IEnumerable<int>> GetDriversByScheduleIdAsync(int scheduleId, CancellationToken cancellationToken = default);
    }
}

