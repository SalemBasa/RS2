using Microsoft.EntityFrameworkCore;
using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Infrastructure
{
    public class VehiclesRepository : BaseRepository<Vehicle, int, VehicleSearchObject>, IVehiclesRepository
    {
        public VehiclesRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override Task<PagedList<Vehicle>> GetPagedAsync(VehicleSearchObject searchObject, CancellationToken cancellationToken = default)
        {
            return DbSet.AsNoTracking()
                .Include(v => v.VehicleModel)
                .Where(v => searchObject.LicensePlateNumber == null || v.LicensePlateNumber.ToLower().Contains(searchObject.LicensePlateNumber.ToLower()))
                .Where(v => searchObject.ManufactureYear == null || v.ManufactureYear == searchObject.ManufactureYear)
                .ToPagedListAsync(searchObject, cancellationToken);
        }
    }
}