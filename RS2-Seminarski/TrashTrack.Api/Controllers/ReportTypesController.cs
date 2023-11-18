using TrashTrack.Core;
using TrashTrack.Application.Interfaces;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Api.Controllers
{
    public class ReportTypesController : BaseCrudController<ReportTypeDto, ReportTypeUpsertDto, ReportTypeSearchObject, IReportTypesService>
    {
        public ReportTypesController(IReportTypesService service, ILogger<ReportTypesController> logger) : base(service, logger)
        {
        }
    }
}
