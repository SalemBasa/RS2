using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application.Interfaces
{
    public interface IReportTypesService : IBaseService<int, ReportTypeDto, ReportTypeUpsertDto, ReportTypeSearchObject>
    {

    }
}


