using AutoMapper;
using FluentValidation;

using TrashTrack.Core;
using TrashTrack.Application.Interfaces;
using TrashTrack.Infrastructure;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application
{
    public class OrderDetailsService : BaseService<OrderDetails, OrderDetailsDto, OrderDetailsUpsertDto, BaseSearchObject, IOrderDetailsRepository>, IOrderDetailsService
    {
        public OrderDetailsService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<OrderDetailsUpsertDto> validator) : base(mapper, unitOfWork, validator)
        {
        }
    }
}

