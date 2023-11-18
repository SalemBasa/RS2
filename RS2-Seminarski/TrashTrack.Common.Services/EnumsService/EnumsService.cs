using TrashTrack.Core;

namespace TrashTrack.Common.Services
{
    public class EnumsService : IEnumsService
    {
        public Task<IEnumerable<KeyValuePair<int, string>>> GetVehicleTypesAsync() => Task.FromResult(GetValues<VehicleType>());
        
        public Task<IEnumerable<KeyValuePair<int, string>>> GetGarbageTypesAsync() => Task.FromResult(GetValues<GarbageType>());
        
        public Task<IEnumerable<KeyValuePair<int, string>>> GetRolesAsync() => Task.FromResult(GetValues<Role>());
        
        public Task<IEnumerable<KeyValuePair<int, string>>> GetReportStateAsync() => Task.FromResult(GetValues<ReportState>());
        
        public Task<IEnumerable<KeyValuePair<int, string>>> GetReportTypeAsync() => Task.FromResult(GetValues<ReportType>());

        public Task<IEnumerable<KeyValuePair<int, string>>> GetReservationStatusAsync() => Task.FromResult(GetValues<ReservationStatus>());

        public Task<IEnumerable<KeyValuePair<int, string>>> GetPickupStatusAsync() => Task.FromResult(GetValues<PickupStatus>());

        public Task<IEnumerable<KeyValuePair<int, string>>> GetProductTypeAsync() => Task.FromResult(GetValues<ProductType>());

        private IEnumerable<KeyValuePair<int, string>> GetValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T))
                       .Cast<int>()
                       .Select(e => new KeyValuePair<int, string>(e, Enum.GetName(typeof(T), e)!));
        }
    }
}