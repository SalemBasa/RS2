using AutoMapper;
using FluentValidation;

using TrashTrack.Core;
using TrashTrack.Application.Interfaces;
using TrashTrack.Infrastructure;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application
{
    public class ScheduleDriversService : BaseService<ScheduleDriver, ScheduleDriverDto, ScheduleDriverUpsertDto, BaseSearchObject, IScheduleDriversRepository>, IScheduleDriversService
    {
        public ScheduleDriversService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<ScheduleDriverUpsertDto> validator) : base(mapper, unitOfWork, validator)
        {
        }

        public async Task<IEnumerable<int>> GetDriversByScheduleIdAsync(int scheduleId, CancellationToken cancellationToken = default)
        {
            var driverIds = await CurrentRepository.GetDriversByScheduleIdAsync(scheduleId, cancellationToken);

            return driverIds;
        }
    }
}

