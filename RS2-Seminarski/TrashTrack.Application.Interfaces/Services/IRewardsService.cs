using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application.Interfaces
{
    public interface IRewardsService : IBaseService<int, RewardDto, RewardUpsertDto, BaseSearchObject>
    {

    }
}



