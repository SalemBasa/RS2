using TrashTrack.Core;
using TrashTrack.Application.Interfaces;
using TrashTrack.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace TrashTrack.Api.Controllers
{
    public class VehicleModelsController : BaseCrudController<VehicleModelDto, VehicleModelUpsertDto, VehicleModelSearchObject, IVehicleModelsService>
    {
        public VehicleModelsController(IVehicleModelsService service, ILogger<VehicleModelsController> logger) : base(service, logger)
        {
        }

        [Authorize]
        [HttpGet("GarbageTruckCount")]
        public async Task<IActionResult> GetGarbageTruckCountAsync(CancellationToken cancellationToken = default)
        {
            var count = await Service.GetGarbageTruckCountAsync(cancellationToken);

            return Ok(count);
        }

        [Authorize]
        [HttpGet("TruckCount")]
        public async Task<IActionResult> GetTruckCountAsync(CancellationToken cancellationToken = default)
        {
            var count = await Service.GetTruckCountAsync(cancellationToken);

            return Ok(count);
        }
    }
}
