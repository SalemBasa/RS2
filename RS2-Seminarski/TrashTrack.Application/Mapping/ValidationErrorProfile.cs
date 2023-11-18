using FluentValidation.Results;

using TrashTrack.Core;

namespace TrashTrack.Application.Mapping
{
    public class ValidationErrorProfile : BaseProfile
    {
        public ValidationErrorProfile()
        {
            CreateMap<ValidationFailure, ValidationError>();
        }
    }
}