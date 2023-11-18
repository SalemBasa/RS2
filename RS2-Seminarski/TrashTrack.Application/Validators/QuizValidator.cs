using FluentValidation;

using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class QuizValidator : AbstractValidator<QuizUpsertDto>
    {
        public QuizValidator()
        {
            RuleFor(a => a.Title).NotEmpty().WithErrorCode(ErrorCodes.NotEmpty);
            RuleFor(a => a.Description).NotEmpty().WithErrorCode(ErrorCodes.NotEmpty);
        }
    }
}
