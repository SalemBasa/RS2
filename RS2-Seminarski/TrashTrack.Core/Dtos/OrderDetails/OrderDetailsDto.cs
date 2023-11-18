namespace TrashTrack.Core
{
    public class OrderDetailsDto : BaseDto
    {
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public ProductDto Product { get; set; } = null!;

        public int OrderId { get; set; }
        public OrderDto Order { get; set; } = null!;
    }
}
