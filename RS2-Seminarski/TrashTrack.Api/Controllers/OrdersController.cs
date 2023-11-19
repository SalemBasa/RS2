using TrashTrack.Core;
using TrashTrack.Application.Interfaces;
using TrashTrack.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace TrashTrack.Api.Controllers
{
    public class OrdersController : BaseCrudController<OrderDto, OrderUpsertDto, OrderSearchObject, IOrdersService>
    {
        public OrdersController(IOrdersService service, ILogger<OrdersController> logger) : base(service, logger)
        {
        }

        [Authorize]
        [HttpGet("ByUser")]
        public async Task<IActionResult> GetOrdersByUserIdAsync([FromQuery] int userId, CancellationToken cancellationToken = default)
        {
            try
            {
                var cities = await Service.GetOrdersByUserIdAsync(userId, cancellationToken);
                return Ok(cities);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Error while getting orders by user ID {0}", userId);
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPut("ToggleOrderStatus")]
        public async Task<IActionResult> ToggleOrderStatus(int id, CancellationToken cancellationToken = default)
        {
            await Service.ToggleOrderStatusAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
