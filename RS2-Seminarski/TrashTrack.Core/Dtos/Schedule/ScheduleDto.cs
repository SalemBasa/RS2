namespace TrashTrack.Core
{
    public class ScheduleDto : BaseDto
    {
        public DateTime PickupDate { get; set; }
        public PickupStatus Status { get; set; }

        public int VehicleId { get; set; }
        public VehicleDto Vehicle { get; set; } = null!;

        public ICollection<ScheduleDriverDto> ScheduleDrivers { get; set; } = null!;

        public ICollection<ScheduleGarbageDto> ScheduleGarbages { get; set; } = null!;
    }
}
