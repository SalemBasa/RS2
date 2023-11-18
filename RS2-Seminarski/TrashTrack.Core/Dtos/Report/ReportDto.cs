namespace TrashTrack.Core
{
    public class ReportDto : BaseDto
    {
        public string Note { get; set; } = null!;
        public ReportState ReportState { get; set; }
        public ReportType ReportType { get; set; }

        public int ReporterUserId { get; set; }
        public UserDto ReporterUser { get; set; } = null!;
        
        public string? Photo { get; set; }

        public int? GarbageId { get; set; }
        public GarbageDto? Garbage { get; set; } 
    }
}
