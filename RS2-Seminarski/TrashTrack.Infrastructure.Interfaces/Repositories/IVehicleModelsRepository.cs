using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Interfaces
{
    public interface IVehicleModelsRepository : IBaseRepository<VehicleModel, int, VehicleModelSearchObject>
    {
        Task<int> GetTruckCountAsync(CancellationToken cancellationToken = default);
        Task<int> GetGarbageTruckCountAsync(CancellationToken cancellationToken = default);
    }
}

