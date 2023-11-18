using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Interfaces
{
    public interface IQuestionsRepository : IBaseRepository<Question, int, BaseSearchObject>
    {
    }
}
