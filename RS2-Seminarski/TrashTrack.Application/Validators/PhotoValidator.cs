using FluentValidation;

using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class PhotoValidator : AbstractValidator<PhotoUpsertDto>
    {
        public PhotoValidator()
        {
            RuleFor(c => c.Data).NotNull().WithErrorCode(ErrorCodes.NotNull);
        }
    }
}
