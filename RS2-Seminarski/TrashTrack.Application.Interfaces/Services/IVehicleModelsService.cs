using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application.Interfaces
{
    public interface IVehicleModelsService : IBaseService<int, VehicleModelDto, VehicleModelUpsertDto, VehicleModelSearchObject>
    {
        Task<int> GetTruckCountAsync(CancellationToken cancellationToken = default);
        Task<int> GetGarbageTruckCountAsync(CancellationToken cancellationToken = default);
    }
}




