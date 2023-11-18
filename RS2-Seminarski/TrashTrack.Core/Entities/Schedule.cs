namespace TrashTrack.Core
{
    public class Schedule : BaseEntity
    {
        public DateTime PickupDate { get; set; }
        public PickupStatus Status { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = null!;

        public ICollection<ScheduleDriver> ScheduleDrivers{ get; set; } = null!;
        public ICollection<ScheduleGarbage> ScheduleGarbages { get; set; } = null!;
    }
}
