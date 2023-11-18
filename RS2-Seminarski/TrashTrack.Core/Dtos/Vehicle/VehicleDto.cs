namespace TrashTrack.Core
{
    public class VehicleDto : BaseDto
    {
        public string Color { get; set; } = null!;
        public string? Notes { get; set; }
        public string LicensePlateNumber { get; set; } = null!;
        public int ManufactureYear { get; set; }
        public int Capacity { get; set; }

        public int VehicleModelId { get; set; }
        public VehicleModelDto VehicleModel { get; set; } = null!;
    }
}
