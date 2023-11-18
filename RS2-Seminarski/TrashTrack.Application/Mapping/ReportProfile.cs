using TrashTrack.Core;

namespace TrashTrack.Application
{
	public class ReportProfile : BaseProfile
	{
		public ReportProfile()
		{
			CreateMap<ReportDto, Report>()
				.ReverseMap();

			CreateMap<ReportUpsertDto, Report>().ReverseMap();

		}
	}
}
