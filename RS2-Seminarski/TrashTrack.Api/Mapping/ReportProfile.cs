using TrashTrack.Api.Models.Report;
using TrashTrack.Core;

namespace TrashTrack.Application;

public class ReportProfile : BaseProfile
{
	public ReportProfile()
	{
		CreateMap<ReportUpsertModel, ReportUpsertDto>();
	}
}
