using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application.Interfaces
{
    public interface   IReportsService : IBaseService<int, ReportDto, ReportUpsertDto, ReportSearchObject>
    {
        Task<OverviewCountDto<int>> GetCountAsync(ReportState reportState, CancellationToken cancellationToken = default);
        
        Task<int> UpdateReportStateAsync(ReportUpsertDto dto, CancellationToken cancellationToken = default);
    }
}


