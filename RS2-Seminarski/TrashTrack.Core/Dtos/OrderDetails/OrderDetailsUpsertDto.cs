namespace TrashTrack.Core
{
    public class OrderDetailsUpsertDto : BaseUpsertDto
    {
        public int Quantity { get; set; }

        public int ProductId { get; set; }
    }
}
