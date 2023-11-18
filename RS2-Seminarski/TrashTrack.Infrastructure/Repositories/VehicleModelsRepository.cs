using Microsoft.EntityFrameworkCore;
using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Infrastructure
{
    public class VehicleModelsRepository : BaseRepository<VehicleModel, int, VehicleModelSearchObject>, IVehicleModelsRepository
    {
        public VehicleModelsRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<int> GetGarbageTruckCountAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(v => v.VehicleType == VehicleType.GarbageTruck).CountAsync(cancellationToken);
        }

        public override Task<PagedList<VehicleModel>> GetPagedAsync(VehicleModelSearchObject searchObject, CancellationToken cancellationToken = default)
        {
            return DbSet.AsNoTracking()
                .Where(vm => searchObject.Query == null || vm.Name.ToLower().Contains(searchObject.Query.ToLower()))
                .Where(vm => searchObject.Type == null || vm.VehicleType == searchObject.Type)
                .ToPagedListAsync(searchObject, cancellationToken);
        }

        public async Task<int> GetTruckCountAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(v => v.VehicleType == VehicleType.Truck).CountAsync(cancellationToken);
        }
    }
}