using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Infrastructure
{
    public class NotificationsRepository : BaseRepository<Notification, int, BaseSearchObject>, INotificationsRepository
    {
        public NotificationsRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}