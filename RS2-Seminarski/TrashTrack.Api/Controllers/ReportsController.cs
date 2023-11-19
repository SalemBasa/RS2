using AutoMapper;
using TrashTrack.Core;
using TrashTrack.Application.Interfaces;
using TrashTrack.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TrashTrack.Api.Models.Report;
using Microsoft.AspNetCore.Authorization;

namespace TrashTrack.Api.Controllers
{
    public class ReportsController : BaseCrudController<ReportDto, ReportUpsertDto, ReportSearchObject, IReportsService>
    {
        private readonly IMapper _mapper;

        public ReportsController(IReportsService service, ILogger<ReportsController> logger,
                                 IMapper mapper) : base(service, logger)
        {
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("Count")]
        public async Task<IActionResult> GetCount(ReportState reportState, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await Service.GetCountAsync(reportState, cancellationToken);
                return Ok(result);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Error while trying to get total number of reports");
                return BadRequest();
            }
        }

        [HttpPost]
        public override Task<IActionResult> Post([FromBody] ReportUpsertDto upsertDto, CancellationToken cancellationToken = default)
        {
            upsertDto.ReportState = ReportState.WaitingForReview;
            return base.Post(upsertDto, cancellationToken);
        }

        [Authorize]
        [HttpPut("PutReportState")]
        public async Task<IActionResult> PutReportState([FromBody] ReportUpsertModel model, CancellationToken cancellationToken = default)
        {
            var reportDto = _mapper.Map<ReportUpsertDto>(model);
            var report = await Service.UpdateReportStateAsync(reportDto, cancellationToken);

            return Ok(report);
        }
    }
}
