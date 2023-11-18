using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Interfaces
{
    public class VehicleModelSearchObject : BaseSearchObject
    {
        public string? Query { get; set; }
        public VehicleType? Type { get; set; }
    }
}
