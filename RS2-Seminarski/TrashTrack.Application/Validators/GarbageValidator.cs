using FluentValidation;

using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class GarbageValidator : AbstractValidator<GarbageUpsertDto>
    {
        public GarbageValidator()
        {
            RuleFor(c => c.Address).NotEmpty().WithErrorCode(ErrorCodes.NotEmpty);
        }
    }
}
