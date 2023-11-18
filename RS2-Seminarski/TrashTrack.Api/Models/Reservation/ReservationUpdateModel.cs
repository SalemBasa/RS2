using TrashTrack.Core;

namespace TrashTrack.Api.Models.Reservation;

public class ReservationUpdateModel
{
	public int Id { get; set; }
    
	public ReservationStatus Status { get; set; }
}
