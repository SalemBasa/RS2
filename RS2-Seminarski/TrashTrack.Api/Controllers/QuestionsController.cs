using Microsoft.AspNetCore.Mvc;
using TrashTrack.Core;
using TrashTrack.Application.Interfaces;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Api.Controllers
{
    public class QuestionsController : BaseCrudController<QuestionDto, QuestionUpsertDto, BaseSearchObject, IQuestionsService>
    {
        public QuestionsController(IQuestionsService service, ILogger<QuestionsController> logger) : base(service, logger)
        {
        }
    }
}
