using AutoMapper;
using FluentValidation;
using TrashTrack.Application.Interfaces;
using TrashTrack.Core;
using TrashTrack.Infrastructure;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application
{
    public class FeedbacksService : BaseService<Feedback, FeedBackDto, FeedbackUpsertDto, BaseSearchObject, FeedbacksRepository>, IFeedbacksService
    {
        public FeedbacksService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<FeedbackUpsertDto> validator) : base(mapper, unitOfWork, validator)
        {
        }
    }
}
