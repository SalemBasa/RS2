using TrashTrack.Core;
using TrashTrack.Application.Interfaces;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Api.Controllers
{
    public class OrderDetailsController : BaseCrudController<OrderDetailsDto, OrderDetailsUpsertDto, BaseSearchObject, IOrderDetailsService>
    {
        public OrderDetailsController(IOrderDetailsService service, ILogger<OrderDetailsController> logger) : base(service, logger)
        {
        }
    }
}
