using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application.Interfaces
{
    public interface IAnswersService : IBaseService<int, AnswerDto, AnswerUpsertDto, BaseSearchObject>
    {

    }
}

