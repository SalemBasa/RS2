using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application.Interfaces
{
    public interface ISchedulesService : IBaseService<int, ScheduleDto, ScheduleUpsertDto, SchedulesSearchObject>
    {
        Task<IEnumerable<ScheduleDto>> GetScheduleByIdAsync(int driverId, CancellationToken cancellationToken = default);
        Task<int> UpdatePickupStatusAsync(ScheduleDto dto, CancellationToken cancellationToken = default);
        
        Schedule Recommend(int userId);
    }
}



