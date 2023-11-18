using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Infrastructure
{
    public class AnswersRepository : BaseRepository<Answer, int, BaseSearchObject>, IAnswersRepository
    {
        public AnswersRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }
    }
}
