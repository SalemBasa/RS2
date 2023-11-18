using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Interfaces
{
    public interface IReportsRepository : IBaseRepository<Report, int, ReportSearchObject>
    {
        Task<int> GetCountByReportStateAsync(ReportState reportState, CancellationToken cancellationToken = default);
    }
}

