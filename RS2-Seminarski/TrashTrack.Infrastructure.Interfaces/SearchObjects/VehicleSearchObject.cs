using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Interfaces
{
    public class VehicleSearchObject : BaseSearchObject
    {
        public string? LicensePlateNumber { get; set; }
        public int? ManufactureYear { get; set; }
    }
}

