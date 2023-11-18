using Microsoft.AspNetCore.Mvc;
using TrashTrack.Api.Controllers;
using TrashTrack.Application.Interfaces;
using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack_Api.Controllers
{
    public class GarbagesController : BaseCrudController<GarbageDto, GarbageUpsertDto, GarbageSearchObject, IGarbagesService>
    {
        public GarbagesController(IGarbagesService service, ILogger<BaseController> logger) : base(service, logger)
        {
        }

        [HttpGet("GlassGarbageCount")]
        public async Task<IActionResult> GetGlassGarbageCountAsync(CancellationToken cancellationToken = default)
        {
            var count = await Service.GetGlassGarbgeCountAsync(cancellationToken);

            return Ok(count);
        }

        [HttpGet("MetalGarbageCount")]
        public async Task<IActionResult> GetMetalGarbageCountAsync(CancellationToken cancellationToken = default)
        {
            var count = await Service.GetMetalGarbageCountAsync(cancellationToken);

            return Ok(count);
        }

        [HttpGet("PlasticGarbageCount")]
        public async Task<IActionResult> GetPlasticGarbageCountAsync(CancellationToken cancellationToken = default)
        {
            var count = await Service.GetPlasticGarbageCountAsync(cancellationToken);

            return Ok(count);
        }

        [HttpGet("OrganicGarbageCount")]
        public async Task<IActionResult> GetOrganicGarbageCountAsync(CancellationToken cancellationToken = default)
        {
            var count = await Service.GetOrganicGarbageCountAsync(cancellationToken);

            return Ok(count);
        }
    }
}
