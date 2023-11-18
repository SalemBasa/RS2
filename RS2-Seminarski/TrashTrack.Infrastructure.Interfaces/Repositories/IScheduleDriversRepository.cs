using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Interfaces
{
    public interface IScheduleDriversRepository : IBaseRepository<ScheduleDriver, int, BaseSearchObject>
    {
        Task<IEnumerable<int>> GetDriversByScheduleIdAsync(int scheduleId, CancellationToken cancellationToken = default);
    }
}
