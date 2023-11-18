using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Interfaces;

public class ReservationSearchObject : BaseSearchObject
{
	public ReservationStatus? Status { get; set; }
}
