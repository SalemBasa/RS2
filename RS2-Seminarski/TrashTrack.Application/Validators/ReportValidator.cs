using FluentValidation;

using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class ReportValidator : AbstractValidator<ReportUpsertDto>
    {
        public ReportValidator()
        {
            RuleFor(r => r.Note).NotEmpty().WithErrorCode(ErrorCodes.NotEmpty);
            RuleFor(r => r.ReportState).NotNull().WithErrorCode(ErrorCodes.NotNull);
            RuleFor(r => r.ReporterUserId).NotNull().WithErrorCode(ErrorCodes.NotNull);
        }
    }
}
