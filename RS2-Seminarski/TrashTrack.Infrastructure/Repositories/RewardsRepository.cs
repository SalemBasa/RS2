using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Infrastructure
{
    public class RewardsRepository : BaseRepository<Reward, int, BaseSearchObject>, IRewardsRepository
    {
        public RewardsRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}