using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class OrderDetailsProfile : BaseProfile
    {
        public OrderDetailsProfile()
        {
            CreateMap<OrderDetailsDto, OrderDetails>().ReverseMap();

            CreateMap<OrderDetailsUpsertDto, OrderDetails>().ReverseMap();

            CreateMap<OrderDetailsUpsertDto, OrderDetailsDto>().ReverseMap();
        }
    }
}

