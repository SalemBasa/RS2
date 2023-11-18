namespace TrashTrack.Core
{
    public class ReportUpsertDto : BaseUpsertDto
    {
        public string Note { get; set; } = null!;
        public ReportState? ReportState { get; set; }
        public ReportType ReportType { get; set; }

        public int ReporterUserId { get; set; }
        
        public string? Photo { get; set; }

        public int? GarbageId { get; set; }
    }
}
