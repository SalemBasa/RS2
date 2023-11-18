namespace TrashTrack.Core;

public class Reservation : BaseEntity
{
	public int UserId { get; set; }
	public User User { get; set; } = default!;

	public int ServiceId { get; set; }
	public Service Service { get; set; } = default!;

	public ReservationStatus Status { get; set; }
	public decimal Latitude { get; set; }
	public decimal Longitude { get; set; }

	public decimal Price { get; set; }
}
