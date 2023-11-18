using TrashTrack.Core;

namespace TrashTrack.Api.Models.Schedules;

public class ScheduleUpdateModel
{
	public int Id { get; set; }
	public PickupStatus Status { get; set; }
}
