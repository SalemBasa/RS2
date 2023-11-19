using Microsoft.AspNetCore.Mvc;
using TrashTrack.Core;
using TrashTrack.Application.Interfaces;
using TrashTrack.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace TrashTrack.Api.Controllers
{
    public class QuizzesController : BaseCrudController<QuizDto, QuizUpsertDto, QuizzesSearchObject, IQuizzesService>
    {
        public QuizzesController(IQuizzesService service, ILogger<QuizzesController> logger) : base(service, logger)
        {
        }

        [Authorize]     
        [HttpPost("QuizSubmission")]
        public async Task<IActionResult> QuizSubmission([FromBody] QuizSubmissionDto dto, CancellationToken cancellationToken = default)
        {
            try
            {
                var userScroe = await Service.ProcessQuizSubmission(dto, cancellationToken);
                return Ok(userScroe);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Error while processing quiz submission.");
                return BadRequest();
            }
        }
    }
}
