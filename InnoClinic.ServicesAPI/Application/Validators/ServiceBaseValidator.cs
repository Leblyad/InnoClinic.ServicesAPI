using FluentValidation;
using InnoClinic.ServicesAPI.Core.Entities.DataTransferObject;

namespace InnoClinic.ServicesAPI.Application.Services.Validators
{
    public class ServiceBaseValidator<T> : AbstractValidator<T> where T : ServiceForManipulationDto
    {
        public ServiceBaseValidator()
        {
            RuleFor(s => s.ServiceName).Length(2, 30);
        }
    }
}
