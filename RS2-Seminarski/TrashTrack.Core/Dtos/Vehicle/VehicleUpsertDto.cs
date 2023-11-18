namespace TrashTrack.Core
{
    public class VehicleUpsertDto : BaseUpsertDto
    {
        public string Color { get; set; } = null!;
        public string? Notes { get; set; }
        public string LicensePlateNumber { get; set; } = null!;
        public int ManufactureYear { get; set; }
        public int Capacity { get; set; }

        public int VehicleModelId { get; set; }
    }
}
