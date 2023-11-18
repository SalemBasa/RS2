namespace TrashTrack.Infrastructure.Interfaces
{
    public class OrderSearchObject : BaseSearchObject
    {
        public string? OrderNumber { get; set; }
        public bool? isCanceled { get; set; }

        public int? UserId { get; set; }
    }
}
