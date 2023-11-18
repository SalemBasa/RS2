using AutoMapper;
using FluentValidation;

using TrashTrack.Core;
using TrashTrack.Application.Interfaces;
using TrashTrack.Infrastructure;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application
{
    public class QuestionsService : BaseService<Question, QuestionDto, QuestionUpsertDto, BaseSearchObject, IQuestionsRepository>, IQuestionsService
    {
        public QuestionsService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<QuestionUpsertDto> validator) : base(mapper, unitOfWork, validator)
        {
        }
    }
}

