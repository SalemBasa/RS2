using TrashTrack.Core;
using TrashTrack.Application.Interfaces;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Api.Controllers
{
    public class ScheduleGarbagesController : BaseCrudController<ScheduleGarbageDto, ScheduleGarbageUpsertDto, BaseSearchObject, IScheduleGarbagesService>
    {
        public ScheduleGarbagesController(IScheduleGarbagesService service, ILogger<ScheduleGarbagesController> logger) : base(service, logger)
        {
        }
    }
}
