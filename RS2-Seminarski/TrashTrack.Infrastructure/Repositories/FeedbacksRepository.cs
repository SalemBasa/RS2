using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Infrastructure
{
    public class FeedbacksRepository : BaseRepository<Feedback, int, BaseSearchObject>, IFeedbacksRepository
    {
        public FeedbacksRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
