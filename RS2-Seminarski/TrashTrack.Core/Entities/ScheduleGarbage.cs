namespace TrashTrack.Core
{
    public class ScheduleGarbage : BaseEntity
    {
        public int ScheduleId { get; set; }
        public int GarbageId { get; set; }
        public Garbage Garbage { get; set; } = default!;
    }
}
