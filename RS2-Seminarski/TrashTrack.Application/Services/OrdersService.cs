using AutoMapper;
using FluentValidation;

using TrashTrack.Core;
using TrashTrack.Application.Interfaces;
using TrashTrack.Infrastructure;
using TrashTrack.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TrashTrack.Application
{
    public class OrdersService : BaseService<Order, OrderDto, OrderUpsertDto, OrderSearchObject, IOrdersRepository>, IOrdersService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public OrdersService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<OrderUpsertDto> validator, DatabaseContext databaseContext) : base(mapper, unitOfWork, validator)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public string GenerateOrderNumber()
        {
            string datePart = DateTime.Now.ToString("yyyyMMdd");
            string randomPart = GenerateRandomNumber(1000, 9999).ToString(); // Adjust the range as needed.

            return $"ORD-{datePart}-{randomPart}";
        }

        private int GenerateRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max + 1);
        }


        public override async Task<OrderDto> AddAsync(OrderUpsertDto dto, CancellationToken cancellationToken = default)
        {
            var order = new Order
            {
                OrderNumber = GenerateOrderNumber(),
                OrderDate = dto.OrderDate,
                isCanceled = false,
                UserId = dto.UserId
            };

            var orderDetailsDto = _mapper.Map<IEnumerable<OrderDetailsDto>>(dto.OrderDetails);

            order.Total = CalculateOrderTotal(orderDetailsDto);

            _databaseContext.Add(order);
            _databaseContext.SaveChanges();

            foreach (var orderDetailDto in dto.OrderDetails)
            {
                var orderDetail = new OrderDetails
                {
                    Quantity = orderDetailDto.Quantity,
                    ProductId = orderDetailDto.ProductId,
                    OrderId = order.Id
                };

                _databaseContext.Add(orderDetail);
            }

            _databaseContext.SaveChanges();

            return _mapper.Map<OrderDto>(order);
        }

        private decimal CalculateOrderTotal(IEnumerable<OrderDetailsDto> orderDetails)
        {
            decimal total = 0;

            foreach (var orderDetailDto in orderDetails)
            {
                var product = _databaseContext.Products.Find(orderDetailDto.ProductId);

                if (product != null)
                {
                    total += orderDetailDto.Quantity * product.Price;
                }
            }

            return total;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            var orders = await CurrentRepository.GetOrdersByUserIdAsync(userId, cancellationToken);

            return Mapper.Map<IEnumerable<Order>>(orders);
        }

        public async Task ToggleOrderStatusAsync(int id, CancellationToken cancellationToken = default)
        {
            var order = await CurrentRepository.GetByIdAsync(id, cancellationToken);
            if (order == null)
                throw new UserNotFoundException();

            order.isCanceled = !order.isCanceled;

            await UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}

