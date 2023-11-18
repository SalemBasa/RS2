using TrashTrack.Application.Interfaces;
using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Api.Controllers;

public class NotificationRabbitController : BaseCrudController<NotificationRabbitDto, NotificationRabbitUpsertDto, BaseSearchObject, INotificationRabbitService>
{
	public NotificationRabbitController(INotificationRabbitService service, ILogger<NotificationRabbitController> logger) : base(service, logger)
	{
	}
}
