using FluentValidation;

using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class OrderDetailsValidator : AbstractValidator<OrderDetailsUpsertDto>
    {
        public OrderDetailsValidator()
        {
        }
    }
}
