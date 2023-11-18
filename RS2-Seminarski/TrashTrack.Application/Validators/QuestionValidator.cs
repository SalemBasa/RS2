using FluentValidation;

using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class QuestionValidator : AbstractValidator<QuestionUpsertDto>
    {
        public QuestionValidator()
        {
            RuleFor(a => a.Content).NotEmpty().WithErrorCode(ErrorCodes.NotEmpty);
            RuleFor(a => a.Points).NotEmpty().WithErrorCode(ErrorCodes.NotEmpty);
        }
    }
}
