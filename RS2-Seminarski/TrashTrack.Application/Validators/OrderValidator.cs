using FluentValidation;

using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class OrderValidator : AbstractValidator<OrderUpsertDto>
    {
        public OrderValidator()
        {
        }
    }
}
