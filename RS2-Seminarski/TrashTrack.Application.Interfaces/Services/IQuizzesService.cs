using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application.Interfaces
{
    public interface IQuizzesService : IBaseService<int, QuizDto, QuizUpsertDto, QuizzesSearchObject>
    {
        Task<int> ProcessQuizSubmission(QuizSubmissionDto dto, CancellationToken cancellationToken = default);
    }
}


