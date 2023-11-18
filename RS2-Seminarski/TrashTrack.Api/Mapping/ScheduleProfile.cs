using TrashTrack.Api.Models.Schedules;
using TrashTrack.Core;

namespace TrashTrack.Application;

public class ScheduleProfile : BaseProfile
{
	public ScheduleProfile()
	{
		CreateMap<ScheduleUpdateModel, ScheduleDto>();
	}
}
