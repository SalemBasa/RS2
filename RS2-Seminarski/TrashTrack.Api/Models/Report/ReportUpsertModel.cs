using TrashTrack.Core;

namespace TrashTrack.Api.Models.Report;

public class ReportUpsertModel
{
	public int Id { get; set; }
    
	public ReportState ReportState { get; set; }
}
