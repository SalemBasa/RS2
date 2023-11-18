using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class RewardProfile : BaseProfile
    {
        public RewardProfile()
        {
            CreateMap<RewardDto, Reward>().ReverseMap();

            CreateMap<RewardUpsertDto, Reward>();
        }
    }
}

