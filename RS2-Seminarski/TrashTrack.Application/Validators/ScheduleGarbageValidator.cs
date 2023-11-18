using FluentValidation;

using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class ScheduleGarbageValidator : AbstractValidator<ScheduleGarbageUpsertDto>
    {
        public ScheduleGarbageValidator()
        {
            //RuleFor(a => a.ScheduleId).NotEmpty().WithErrorCode(ErrorCodes.NotEmpty);
            //RuleFor(a => a.GarbageId).NotEmpty().WithErrorCode(ErrorCodes.NotEmpty);
        }
    }
}

