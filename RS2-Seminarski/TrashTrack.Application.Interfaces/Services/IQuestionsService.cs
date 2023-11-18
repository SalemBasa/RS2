using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application.Interfaces
{
    public interface IQuestionsService : IBaseService<int, QuestionDto, QuestionUpsertDto, BaseSearchObject>
    {

    }
}

