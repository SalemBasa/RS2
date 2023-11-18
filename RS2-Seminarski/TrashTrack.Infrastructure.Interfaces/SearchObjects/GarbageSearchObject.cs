using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Interfaces;

public class GarbageSearchObject : BaseSearchObject
{
	public string? Address { get; set; }
	public GarbageType? GarbageType { get; set; }
}
