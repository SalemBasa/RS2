using AutoMapper;
using FluentValidation;

using TrashTrack.Core;
using TrashTrack.Application.Interfaces;
using TrashTrack.Infrastructure;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application
{
    public class VehicleModelsService : BaseService<VehicleModel, VehicleModelDto, VehicleModelUpsertDto, VehicleModelSearchObject, IVehicleModelsRepository>, IVehicleModelsService
    {
        public VehicleModelsService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<VehicleModelUpsertDto> validator) : base(mapper, unitOfWork, validator)
        {

        }

        public async Task<int> GetGarbageTruckCountAsync(CancellationToken cancellationToken = default)
        {
            var count = await CurrentRepository.GetGarbageTruckCountAsync(cancellationToken);
            return count;
        }

        public async Task<int> GetTruckCountAsync(CancellationToken cancellationToken = default)
        {
            var count = await CurrentRepository.GetTruckCountAsync(cancellationToken);
            return count;
        }
    }
}