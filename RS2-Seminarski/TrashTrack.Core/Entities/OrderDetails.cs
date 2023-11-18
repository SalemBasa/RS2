namespace TrashTrack.Core
{
    public class OrderDetails : BaseEntity
    {
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
    }
}
