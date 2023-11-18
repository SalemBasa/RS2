using FluentValidation;
using TrashTrack.Core;

namespace TrashTrack.Application;

public class NotificationRabbitValidator : AbstractValidator<NotificationRabbitUpsertDto>
{
	public NotificationRabbitValidator()
	{
		
	}
}
