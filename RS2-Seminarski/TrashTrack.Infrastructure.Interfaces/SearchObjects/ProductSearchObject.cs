using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Interfaces;

public class ProductSearchObject : BaseSearchObject
{
    public string? Name { get; set; }
    public ProductType? ProductType { get; set; }
}

