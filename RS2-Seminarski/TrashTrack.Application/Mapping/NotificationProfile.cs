using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class NotificationProfile : BaseProfile
    {
        public NotificationProfile()
        {
            CreateMap<NotificationDto, Notification>().ReverseMap();

            CreateMap<NotificationUpsertDto, Notification>();
        }
    }
}
