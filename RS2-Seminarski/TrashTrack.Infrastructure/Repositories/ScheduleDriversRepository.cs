using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Infrastructure
{
    public class ScheduleDriversRepository : BaseRepository<ScheduleDriver, int, BaseSearchObject>, IScheduleDriversRepository
    {
        public ScheduleDriversRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public async Task<IEnumerable<int>> GetDriversByScheduleIdAsync(int scheduleId, CancellationToken cancellationToken = default)
        {
            var driverIds = new List<int>();

            var scheduleDrivers = DbSet.Where(s => s.ScheduleId == scheduleId).ToList();

            foreach (var scheduleDriver in scheduleDrivers)
            {
                driverIds.Add(scheduleDriver.DriverId);
            }

            return driverIds;
        }
    }
}
