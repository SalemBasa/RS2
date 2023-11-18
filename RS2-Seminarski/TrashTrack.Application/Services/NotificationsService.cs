using AutoMapper;
using FluentValidation;
using TrashTrack.Application.Interfaces;
using TrashTrack.Core;
using TrashTrack.Infrastructure;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application
{
    public class NotificationsService : BaseService<Notification, NotificationDto, NotificationUpsertDto, BaseSearchObject, NotificationsRepository>, INotificationsService
    {
        public NotificationsService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<NotificationUpsertDto> validator) : base(mapper, unitOfWork, validator)
        {
        }
    }
}
