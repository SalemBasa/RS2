using AutoMapper;
using FluentValidation;
using TrashTrack.Application.Interfaces;
using TrashTrack.Core;
using TrashTrack.Infrastructure;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application
{
    public class RewardsService : BaseService<Reward, RewardDto, RewardUpsertDto, BaseSearchObject, RewardsRepository>, IRewardsService
    {
        public RewardsService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<RewardUpsertDto> validator) : base(mapper, unitOfWork, validator)
        {
        }
    }
}
