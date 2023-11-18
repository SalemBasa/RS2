using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Interfaces
{
    public interface ISchedulesRepository : IBaseRepository<Schedule, int, SchedulesSearchObject>
    {
        Task<IEnumerable<Schedule>> GetScheduleByIdAsync(int driverId, CancellationToken cancellationToken = default);
    }
}

