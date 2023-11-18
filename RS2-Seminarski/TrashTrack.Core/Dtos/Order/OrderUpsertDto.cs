namespace TrashTrack.Core
{
    public class OrderUpsertDto : BaseUpsertDto
    {
        public DateTime OrderDate { get; set; }
        public bool isCanceled { get; set; }

        public int UserId { get; set; }

        public ICollection<OrderDetailsUpsertDto> OrderDetails { get; set; } = null!;
    }
}
