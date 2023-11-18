namespace TrashTrack.Common.Services
{
    public interface IEnumsService
    {
        Task<IEnumerable<KeyValuePair<int, string>>> GetVehicleTypesAsync();
        
        Task<IEnumerable<KeyValuePair<int, string>>> GetGarbageTypesAsync();
        
        Task<IEnumerable<KeyValuePair<int, string>>> GetRolesAsync();
        
        Task<IEnumerable<KeyValuePair<int, string>>> GetReportStateAsync();
        
        Task<IEnumerable<KeyValuePair<int, string>>> GetReportTypeAsync();
        
        Task<IEnumerable<KeyValuePair<int, string>>> GetReservationStatusAsync();
        
        Task<IEnumerable<KeyValuePair<int, string>>> GetPickupStatusAsync();

        Task<IEnumerable<KeyValuePair<int, string>>> GetProductTypeAsync();
    }
}
