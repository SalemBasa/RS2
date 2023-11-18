using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Infrastructure;

public class NotificationRabbitRepository : BaseRepository<NotificationRabbit, int, BaseSearchObject>, INotificationRabbitRepository
{
	public NotificationRabbitRepository(DatabaseContext databaseContext) : base(databaseContext)
	{
		
	}
}
