using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Interfaces
{
    public interface IFeedbacksRepository : IBaseRepository<Feedback, int, BaseSearchObject>
    {
    }
}
