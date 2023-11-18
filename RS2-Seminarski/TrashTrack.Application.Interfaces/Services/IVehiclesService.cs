using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application.Interfaces
{
    public interface IVehiclesService : IBaseService<int, VehicleDto, VehicleUpsertDto, VehicleSearchObject>
    {

    }
}




