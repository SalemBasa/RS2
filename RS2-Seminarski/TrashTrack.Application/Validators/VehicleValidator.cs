using FluentValidation;

using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class VehicleValidator : AbstractValidator<VehicleUpsertDto>
    {
        public VehicleValidator()
        {
            RuleFor(uv => uv.Color).NotEmpty().WithErrorCode(ErrorCodes.NotEmpty);
            RuleFor(uv => uv.LicensePlateNumber).NotEmpty().WithErrorCode(ErrorCodes.NotEmpty);
            RuleFor(uv => uv.ManufactureYear).NotNull().WithErrorCode(ErrorCodes.NotEmpty)
                                             .GreaterThanOrEqualTo(1900).WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(uv => uv.Capacity).NotEmpty().WithErrorCode(ErrorCodes.NotEmpty);
            RuleFor(uv => uv.VehicleModelId).NotNull().WithErrorCode(ErrorCodes.NotNull);
        }
    }
}


