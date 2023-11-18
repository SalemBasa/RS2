using TrashTrack.Api.Controllers;
using TrashTrack.Application.Interfaces;
using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack_Api.Controllers
{
    public class NotificationsController : BaseCrudController<NotificationDto, NotificationUpsertDto, BaseSearchObject, INotificationsService>
    {
        public NotificationsController(INotificationsService service, ILogger<BaseController> logger) : base(service, logger)
        {
        }
    }
}
