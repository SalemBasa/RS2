using AutoMapper;
using FluentValidation;

using TrashTrack.Core;
using TrashTrack.Application.Interfaces;
using TrashTrack.Infrastructure;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application
{
    public class ScheduleGarbagesService : BaseService<ScheduleGarbage, ScheduleGarbageDto, ScheduleGarbageUpsertDto, BaseSearchObject, IScheduleGarbagesRepository>, IScheduleGarbagesService
    {
        public ScheduleGarbagesService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<ScheduleGarbageUpsertDto> validator) : base(mapper, unitOfWork, validator)
        {
        }
    }
}

