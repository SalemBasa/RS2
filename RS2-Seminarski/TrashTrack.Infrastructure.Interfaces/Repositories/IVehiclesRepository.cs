using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Interfaces
{
    public interface IVehiclesRepository : IBaseRepository<Vehicle, int, VehicleSearchObject>
    {
    }
}

