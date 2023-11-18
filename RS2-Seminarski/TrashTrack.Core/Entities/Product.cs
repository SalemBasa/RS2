namespace TrashTrack.Core
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Photo { get; set; } = null!;
        public decimal Price { get; set; }
        public ProductType Type { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; } = null!;
    }
}
