using TrashTrack.Core;

namespace TrashTrack.Application.Mapping;

public class NotificationRabbitProfile : BaseProfile
{
	public NotificationRabbitProfile()
	{
		CreateMap<NotificationRabbitDto, NotificationRabbit>().ReverseMap();

		CreateMap<NotificationRabbitUpsertDto, NotificationRabbit>().ReverseMap();
	}
}
