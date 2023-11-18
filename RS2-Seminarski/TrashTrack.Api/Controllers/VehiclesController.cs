using TrashTrack.Api.Controllers;
using TrashTrack.Application.Interfaces;
using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack_Api.Controllers
{
    public class VehiclesController : BaseCrudController<VehicleDto, VehicleUpsertDto, VehicleSearchObject, IVehiclesService>
    {
        public VehiclesController(IVehiclesService service, ILogger<BaseController> logger) : base(service, logger)
        {
        }
    }
}
