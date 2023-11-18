namespace TrashTrack.Core
{
    public class Garbage : BaseEntity
    {
        public string Address { get; set; } = null!;
        public GarbageType GarbageType { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int Occupancy { get; set; }

        public ICollection<Report> Reports { get; set; } = null!;
        public ICollection<ScheduleGarbage> ScheduleGarbages { get; set; } = null!;
    }
}
