using FluentValidation;

using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class ProductValidator : AbstractValidator<ProductUpsertDto>
    {
        public ProductValidator()
        {
        }
    }
}
