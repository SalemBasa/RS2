using FluentValidation;
using TrashTrack.Core;

namespace TrashTrack.Application;

public class ReservationValidator : AbstractValidator<ReservationUpsertDto>
{
	public ReservationValidator()
	{
		RuleFor(x => x.UserId).NotNull().WithErrorCode(ErrorCodes.NotNull);
		RuleFor(x => x.ServiceId).NotNull().WithErrorCode(ErrorCodes.NotNull);
		RuleFor(r => r.Status).NotNull().WithErrorCode(ErrorCodes.NotNull);

	}
}
