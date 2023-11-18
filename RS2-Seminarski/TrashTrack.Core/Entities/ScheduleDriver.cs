namespace TrashTrack.Core
{
    public class ScheduleDriver : BaseEntity
    {
        public int ScheduleId { get; set; }

        public int DriverId { get; set; }
        public User Driver { get; set; } = null!;
    }
}
