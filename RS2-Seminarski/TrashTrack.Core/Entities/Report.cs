namespace TrashTrack.Core
{
    public class Report : BaseEntity
    {
        public string Note { get; set; } = null!;
        public ReportState ReportState { get; set; }
        
        public ReportType ReportType { get; set; }

        public int ReporterUserId { get; set; }
        public User ReporterUser { get; set; } = null!;

        public string? Photo { get; set; } 

        public int? GarbageId { get; set; }
        public Garbage? Garbage { get; set; } 
    }
}
