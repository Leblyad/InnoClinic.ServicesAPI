using FluentValidation;
using ServicesAPI.Core.Entities.DataTransferObject;

namespace ServicesAPI.Application.Services.Validators
{
    public class ServiceBaseValidator<T> : AbstractValidator<T> where T : ServiceForManipulationDto
    {
        public ServiceBaseValidator()
        {
            RuleFor(s => s.ServiceName).Length(2, 30);
            RuleFor(s => s.SpecializationName).Length(2, 30);
        }
    }
}
