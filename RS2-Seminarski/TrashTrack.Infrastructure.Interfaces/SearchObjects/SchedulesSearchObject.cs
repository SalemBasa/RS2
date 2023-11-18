using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Interfaces
{
    public class SchedulesSearchObject : BaseSearchObject
    {
        public int? DriverId { get; set; }
        public PickupStatus? Status { get; set; }
    }
}
