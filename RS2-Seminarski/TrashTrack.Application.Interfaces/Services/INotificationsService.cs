using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application.Interfaces
{
    public interface INotificationsService : IBaseService<int, NotificationDto, NotificationUpsertDto, BaseSearchObject>
    {

    }
}


