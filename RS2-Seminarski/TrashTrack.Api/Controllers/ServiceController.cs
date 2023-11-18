using TrashTrack.Application.Interfaces;
using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Api.Controllers;

public class ServiceController : BaseCrudController<ServiceDto, ServiceUpsertDto, ServicesSearchObject, IServiceService>
{
	public ServiceController(IServiceService service, ILogger<BaseController> logger) : base(service, logger)
	{
	}
}
