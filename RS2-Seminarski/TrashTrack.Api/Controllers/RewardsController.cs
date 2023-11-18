using TrashTrack.Api.Controllers;
using TrashTrack.Application.Interfaces;
using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack_Api.Controllers
{
    public class RewardsController : BaseCrudController<RewardDto, RewardUpsertDto, BaseSearchObject, IRewardsService>
    {
        public RewardsController(IRewardsService service, ILogger<BaseController> logger) : base(service, logger)
        {
        }
    }
}
