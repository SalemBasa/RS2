using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application.Interfaces
{
    public interface IFeedbacksService : IBaseService<int, FeedBackDto, FeedbackUpsertDto, BaseSearchObject>
    {

    }
}


