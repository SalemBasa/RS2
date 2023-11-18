namespace TrashTrack.Core;

public class ReservationUpsertDto : BaseUpsertDto
{
	public int UserId { get; set; }
	public UserDto User { get; set; }

	public int ServiceId { get; set; }

	public ReservationStatus Status { get; set; }
	public decimal Latitude { get; set; }
	public decimal Longitude { get; set; }
}
