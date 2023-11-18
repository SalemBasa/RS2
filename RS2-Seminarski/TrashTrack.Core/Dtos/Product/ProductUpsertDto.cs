namespace TrashTrack.Core
{
    public class ProductUpsertDto : BaseUpsertDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Photo { get; set; } = null!;
        public decimal Price { get; set; }
        public ProductType Type { get; set; }
    }
}
