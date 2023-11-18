using FluentValidation;

using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class RewardValidator : AbstractValidator<RewardUpsertDto>
    {
        public RewardValidator()
        {
            RuleFor(r => r.UserId).NotEmpty().WithErrorCode(ErrorCodes.NotEmpty);
            RuleFor(r => r.QuizId).NotEmpty().WithErrorCode(ErrorCodes.NotEmpty);
            RuleFor(r => r.Score).NotNull().WithErrorCode(ErrorCodes.NotNull);
            RuleFor(r => r.MoneyEarned).NotNull().WithErrorCode(ErrorCodes.NotNull);
        }
    }
}
