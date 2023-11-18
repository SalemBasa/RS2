namespace TrashTrack.Core
{
    public class Vehicle : BaseEntity
    {
        public string Color { get; set; } = null!;
        public string? Notes { get; set; }
        public string LicensePlateNumber { get; set; } = null!;
        public int ManufactureYear { get; set; }
        public int Capacity { get; set; }

        public int VehicleModelId { get; set; }
        public VehicleModel VehicleModel { get; set; } = null!;

        public ICollection<Schedule> Schedules { get; set; } = null!;
    }
}
