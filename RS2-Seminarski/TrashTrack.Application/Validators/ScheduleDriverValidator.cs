using FluentValidation;

using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class ScheduleDriverValidator : AbstractValidator<ScheduleDriverUpsertDto>
    {
        public ScheduleDriverValidator()
        {
            RuleFor(a => a.DriverId).NotEmpty().WithErrorCode(ErrorCodes.NotEmpty);
        }
    }
}

