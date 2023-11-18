using AutoMapper;
using FluentValidation;

using TrashTrack.Core;
using TrashTrack.Application.Interfaces;
using TrashTrack.Infrastructure;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application
{
    public class VehiclesService : BaseService<Vehicle, VehicleDto, VehicleUpsertDto, VehicleSearchObject, IVehiclesRepository>, IVehiclesService
    {
        public VehiclesService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<VehicleUpsertDto> validator) : base(mapper, unitOfWork, validator)
        {
        }
    }
}
