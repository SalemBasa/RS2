using TrashTrack.Core;
using TrashTrack.Application.Interfaces;
using TrashTrack.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace TrashTrack.Api.Controllers
{
    public class ScheduleDriversController : BaseCrudController<ScheduleDriverDto, ScheduleDriverUpsertDto, BaseSearchObject, IScheduleDriversService>
    {
        public ScheduleDriversController(IScheduleDriversService service, ILogger<ScheduleDriversController> logger) : base(service, logger)
        {
        }

        [Authorize]
        [HttpGet("BySchedule")]
        public async Task<IActionResult> GetByDriver([FromQuery] int scheduleId, CancellationToken cancellationToken = default)
        {
            try
            {
                var driverIds = await Service.GetDriversByScheduleIdAsync(scheduleId, cancellationToken);
                return Ok(driverIds);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Error while getting drivers by schedule ID {0}", scheduleId);
                return BadRequest();
            }
        }
    }
}
