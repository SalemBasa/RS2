using FluentValidation;

using TrashTrack.Core;
using TrashTrack.Application;

namespace TrashTrack.Application
{
    public class UserValidator : AbstractValidator<UserUpsertDto>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithErrorCode(ErrorCodes.NotEmpty);
            RuleFor(u => u.LastName).NotEmpty().WithErrorCode(ErrorCodes.NotEmpty);
            RuleFor(u => u.Email).NotEmpty().WithErrorCode(ErrorCodes.NotEmpty)
                                 .EmailAddress().WithErrorCode(ErrorCodes.InvalidValue);

            RuleFor(u => u.Password)
                .NotEmpty()
                .NotNull()
                .MinimumLength(8)
                .Matches(@"[A-Z]+")
                .Matches(@"[a-z]+")
                .Matches(@"[0-9]+")
                .WithErrorCode(ErrorCodes.InvalidValue)
                .When(u => u.Id == null || u.Password != null);

            RuleFor(u => u.PhoneNumber).NotEmpty().WithErrorCode(ErrorCodes.NotEmpty);

            RuleFor(u => u.Gender).IsInEnum().WithErrorCode(ErrorCodes.NotNull);
            RuleFor(u => u.BirthDate).NotNull().WithErrorCode(ErrorCodes.NotNull);

//            RuleFor(u => u.ProfileProduct)
//                .MustAsync(async (profileProduct, cancellationToken) => await ValidateProductSizeAsync(profileProduct, cancellationToken))
//                .WithErrorCode(ErrorCodes.InvalidSize)
//                .When(u => u.ProfileProduct != null);
        }
    }
}
