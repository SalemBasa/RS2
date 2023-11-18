using AutoMapper;
using FluentValidation;
using TrashTrack.Application.Interfaces;
using TrashTrack.Core;
using TrashTrack.Infrastructure;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application;

public class NotificationRabbitService : BaseService<NotificationRabbit, NotificationRabbitDto, NotificationRabbitUpsertDto, BaseSearchObject, INotificationRabbitRepository>, INotificationRabbitService
{
	public NotificationRabbitService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<NotificationRabbitUpsertDto> validator) : base(mapper, unitOfWork, validator)
	{
	}
}
