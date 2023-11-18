using FluentValidation;

using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class AnswerValidator : AbstractValidator<AnswerUpsertDto>
    {
        public AnswerValidator()
        {
            RuleFor(a => a.Content).NotEmpty().WithErrorCode(ErrorCodes.NotEmpty);
            RuleFor(a => a.IsTrue).NotEmpty().WithErrorCode(ErrorCodes.NotEmpty);
        }
    }
}
