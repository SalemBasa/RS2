using FluentValidation;

using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class FeedbackValidator : AbstractValidator<FeedbackUpsertDto>
    {
        public FeedbackValidator()
        {
        }
    }
}
