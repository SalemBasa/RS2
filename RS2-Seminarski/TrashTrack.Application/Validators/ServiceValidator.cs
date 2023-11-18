using FluentValidation;
using TrashTrack.Core;

namespace TrashTrack.Application;

public class ServiceValidator : AbstractValidator<ServiceUpsertDto>
{
	public ServiceValidator()
	{
		RuleFor(x => x.Name).NotEmpty().WithErrorCode(ErrorCodes.NotEmpty);
		RuleFor(x => x.Description).NotEmpty().WithErrorCode(ErrorCodes.NotEmpty);
	}
}
