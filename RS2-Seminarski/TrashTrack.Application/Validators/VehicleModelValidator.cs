using FluentValidation;

using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class VehicleModelValidator : AbstractValidator<VehicleModelUpsertDto>
    {
        public VehicleModelValidator()
        {
            RuleFor(vm => vm.Name).NotEmpty().WithErrorCode(ErrorCodes.NotEmpty);
            RuleFor(vm => vm.VehicleType).NotNull().WithErrorCode(ErrorCodes.NotNull);
        }
    }
}