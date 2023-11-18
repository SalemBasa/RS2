using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class ProductProfile : BaseProfile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();

            CreateMap<ProductUpsertDto, Product>().ReverseMap();
        }
    }
}

