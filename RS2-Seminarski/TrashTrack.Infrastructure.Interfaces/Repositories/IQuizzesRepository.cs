using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Interfaces
{
    public interface IQuizzesRepository : IBaseRepository<Quiz, int, QuizzesSearchObject>
    {
    }
}
