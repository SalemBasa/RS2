using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Infrastructure
{
    public class QuestionsRepository : BaseRepository<Question, int, BaseSearchObject>, IQuestionsRepository
    {
        public QuestionsRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }
    }
}
