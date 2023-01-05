using FluentValidation;
using InnoClinic.ServicesAPI.Application.Entities.DataTransferObject;

namespace InnoClinic.ServicesAPI.Application.Services.Validators
{
    public class ServiceForCreationValidator : AbstractValidator<ServiceForCreationDto>
    {
        public ServiceForCreationValidator()
        {
            RuleFor(s => s.Name).Length(2, 30);
        }
    }
}
