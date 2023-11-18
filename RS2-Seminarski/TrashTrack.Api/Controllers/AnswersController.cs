using TrashTrack.Core;
using TrashTrack.Application.Interfaces;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Api.Controllers
{
    public class AnswersController : BaseCrudController<AnswerDto, AnswerUpsertDto, BaseSearchObject, IAnswersService>
    {
        public AnswersController(IAnswersService service, ILogger<AnswersController> logger) : base(service, logger)
        {
        }
    }
}
