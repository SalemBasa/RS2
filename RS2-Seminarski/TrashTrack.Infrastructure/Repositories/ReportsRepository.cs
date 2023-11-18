using Microsoft.EntityFrameworkCore;
using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Infrastructure
{
    public class ReportsRepository : BaseRepository<Report, int, ReportSearchObject>, IReportsRepository
    {
        public ReportsRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<int> GetCountByReportStateAsync(ReportState reportState, CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(r => r.ReportState == reportState).CountAsync(cancellationToken);
        }

        public override Task<PagedList<Report>> GetPagedAsync(ReportSearchObject searchObject, CancellationToken cancellationToken = default)
        {
            return DbSet.Include(r=>r.ReporterUser)
                        .Include(x =>x.Garbage)
                .Where(r=> searchObject.ReportState == null || r.ReportState == searchObject.ReportState)
                .Where(r=> searchObject.Note == null || r.Note.ToLower().Contains(searchObject.Note.ToLower())).ToPagedListAsync(searchObject, cancellationToken);   

        }
    }
}