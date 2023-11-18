using FluentValidation;

using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class NotificationValidator : AbstractValidator<NotificationUpsertDto>
    {
        public NotificationValidator()
        {
            RuleFor(c => c.DateSent).NotNull().WithErrorCode(ErrorCodes.NotNull);
            RuleFor(c => c.Message).NotEmpty().WithErrorCode(ErrorCodes.NotEmpty);
            RuleFor(c => c.IsSeen).NotNull().WithErrorCode(ErrorCodes.NotNull);
            RuleFor(c => c.UserId).NotNull().WithErrorCode(ErrorCodes.NotNull);
        }
    }
}
