using Microsoft.AspNetCore.Mvc;

using TrashTrack.Core;
using TrashTrack.Application.Interfaces;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Api.Controllers
{
    public class PhotosController : BaseCrudController<PhotoDto, PhotoUpsertDto, BaseSearchObject, IPhotosService>
    {
        public PhotosController(IPhotosService service, ILogger<PhotosController> logger) : base(service, logger)
        {
        }

        public override async Task<IActionResult> Get(int id, CancellationToken cancellationToken = default)
        {
            var Photo = await Service.GetByIdAsync(id, cancellationToken);
            if (Photo == null)
                return NotFound();

            return File(Photo.Data, $"Photo-{id}", true);
        }
    }
}