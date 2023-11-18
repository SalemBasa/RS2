namespace TrashTrack.Core;

public class ReservationDto : BaseDto
{
	public int UserId { get; set; }
	public UserDto User { get; set; } = default!;

	public int ServiceId { get; set; }
	public ServiceDto Service { get; set; } = default!;

	public ReservationStatus Status { get; set; }
	public decimal Latitude { get; set; }
	public decimal Longitude { get; set; }
	public decimal Price { get; set; }
}
