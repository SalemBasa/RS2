namespace TrashTrack.Core
{
    public class ScheduleUpsertDto : BaseUpsertDto
    {
        public DateTime PickupDate { get; set; }

        public PickupStatus Status { get; set; }
        
        public int VehicleId { get; set; }

        public ICollection<ScheduleDriverUpsertDto> ScheduleDrivers { get; set; } = null!;
        public ICollection<ScheduleGarbageUpsertDto> ScheduleGarbages { get; set; } = null!;
    }
}
