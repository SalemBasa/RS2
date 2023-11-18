using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Interfaces
{
    public class ReportSearchObject : BaseSearchObject
    {
        public string? Note { get; set; } = null!;
        public ReportState? ReportState { get; set; }

    }
}