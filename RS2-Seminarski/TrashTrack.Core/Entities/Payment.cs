namespace TrashTrack.Core;

public class Payment : BaseEntity
{
	public double Amount { get; set; }
	public DateTime DateOfTransaction { get; set; }
	public string NumberOfTransaction { get; set; } = default!;

    public ICollection<Order> Orders { get; set; } = null!;
}
