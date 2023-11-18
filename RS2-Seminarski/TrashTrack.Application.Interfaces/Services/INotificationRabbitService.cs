using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application.Interfaces;

public interface INotificationRabbitService : IBaseService<int, NotificationRabbitDto, NotificationRabbitUpsertDto, BaseSearchObject>
{
	
}
