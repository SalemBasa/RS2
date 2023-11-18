using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class OrderProfile : BaseProfile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, Order>().ReverseMap();

            CreateMap<OrderUpsertDto, Order>().ReverseMap();

        }
    }
}

