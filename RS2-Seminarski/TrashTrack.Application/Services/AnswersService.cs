using AutoMapper;
using FluentValidation;

using TrashTrack.Core;
using TrashTrack.Application.Interfaces;
using TrashTrack.Infrastructure;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application
{
    public class AnswersService : BaseService<Answer, AnswerDto, AnswerUpsertDto, BaseSearchObject, IAnswersRepository>, IAnswersService
    {
        public AnswersService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<AnswerUpsertDto> validator) : base(mapper, unitOfWork, validator)
        {
        }
    }
}

