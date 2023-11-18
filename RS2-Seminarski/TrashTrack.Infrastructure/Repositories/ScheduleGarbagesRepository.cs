using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Infrastructure
{
    public class ScheduleGarbagesRepository : BaseRepository<ScheduleGarbage, int, BaseSearchObject>, IScheduleGarbagesRepository
    {
        public ScheduleGarbagesRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }
    }
}
