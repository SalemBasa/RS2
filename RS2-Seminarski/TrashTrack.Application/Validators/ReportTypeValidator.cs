using FluentValidation;

using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class ReportTypeValidator : AbstractValidator<ReportTypeUpsertDto>
    {
        public ReportTypeValidator()
        {
            RuleFor(r => r.Name).NotEmpty().WithErrorCode(ErrorCodes.NotEmpty);
        }
    }
}
