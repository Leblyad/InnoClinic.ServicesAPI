using FluentValidation;
using InnoClinic.ServicesAPI.Application.Entities.DataTransferObject;

namespace InnoClinic.ServicesAPI.Application.Services.Validators
{
    public class ServiceForUpdateValidator : AbstractValidator<ServiceForUpdateDto>
    {
        public ServiceForUpdateValidator()
        {
            RuleFor(s => s.Name).Length(2, 30);
        }
    }
}
