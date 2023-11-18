using AutoMapper;
using FluentValidation;

using TrashTrack.Core;
using TrashTrack.Application.Interfaces;
using TrashTrack.Infrastructure;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application
{
    public class ReportsService : BaseService<Report, ReportDto, ReportUpsertDto, ReportSearchObject, IReportsRepository>, IReportsService
    {
        private readonly IMapper _mapper;
        private readonly IProductsService _ProductsService;

        public ReportsService(IMapper mapper, 
                              IUnitOfWork unitOfWork, 
                              IValidator<ReportUpsertDto> validator, 
                              IProductsService ProductsService) : base(mapper, unitOfWork, validator)
        {
            _mapper = mapper;
            _ProductsService = ProductsService;
        }

        public async Task<OverviewCountDto<int>> GetCountAsync(ReportState reportState, CancellationToken cancellationToken = default)
        {
            var count = await CurrentRepository.GetCountByReportStateAsync(reportState, cancellationToken);
            return new OverviewCountDto<int> { Count = count };
        }

        public override async Task<ReportDto> AddAsync(ReportUpsertDto dto, CancellationToken cancellationToken = default)
        {
            var report = Mapper.Map<Report>(dto);

            report.ReportState = ReportState.WaitingForReview;
            
            await CurrentRepository.AddAsync(report, cancellationToken);
            await UnitOfWork.SaveChangesAsync(cancellationToken);

            return Mapper.Map<ReportDto>(report);
        }
        
        public async Task<int> UpdateReportStateAsync(ReportUpsertDto dto, CancellationToken cancellationToken = default)
        {
            var report = await CurrentRepository.GetByIdAsync(dto.Id.GetValueOrDefault(), cancellationToken);
            if (report == null)
                throw new Exception("Report not found");

            report.ReportState = ReportState.Reviewed;

            CurrentRepository.Update(report);
            await UnitOfWork.SaveChangesAsync(cancellationToken);

            return Mapper.Map<int>(report.ReportState);
        }
    }
}
