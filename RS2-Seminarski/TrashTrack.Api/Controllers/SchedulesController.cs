using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrashTrack.Api.Controllers;
using TrashTrack.Api.Models.Schedules;
using TrashTrack.Application.Interfaces;
using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack_Api.Controllers
{
    public class SchedulesController : BaseCrudController<ScheduleDto, ScheduleUpsertDto, SchedulesSearchObject, ISchedulesService>
    {
        private readonly IMapper _mapper;

        public SchedulesController(ISchedulesService service, ILogger<BaseController> logger, IMapper mapper) : base(service, logger)
        {
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("ByDriver")]
        public async Task<IActionResult> GetByDriver([FromQuery] int driverId, CancellationToken cancellationToken = default)
        {
            try
            {
                var schedules = await Service.GetScheduleByIdAsync(driverId, cancellationToken);
                return Ok(schedules);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Error while getting schedules by schedule ID {0}", driverId);
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPut("PutPickupStatus")]
        public async Task<IActionResult> PutPickupStatus([FromBody] ScheduleUpdateModel model, CancellationToken cancellationToken = default)
        {
            var scheduleDto = _mapper.Map<ScheduleDto>(model);
            var schedule = await Service.UpdatePickupStatusAsync(scheduleDto, cancellationToken);

            return Ok(schedule);
        }

        [Authorize]
        [HttpGet("/Recommended/{id}")]
        public Schedule Recommend(int id)
        {
            return Service.Recommend(id);
        }
    }
}
