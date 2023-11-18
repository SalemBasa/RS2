using TrashTrack.Api.Controllers;
using TrashTrack.Application.Interfaces;
using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack_Api.Controllers
{
    public class FeedbacksController : BaseCrudController<FeedBackDto, FeedbackUpsertDto, BaseSearchObject, IFeedbacksService>
    {
        public FeedbacksController(IFeedbacksService service, ILogger<BaseController> logger) : base(service, logger)
        {
        }
    }
}
