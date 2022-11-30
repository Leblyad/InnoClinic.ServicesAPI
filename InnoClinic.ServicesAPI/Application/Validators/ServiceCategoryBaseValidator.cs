using FluentValidation;
using ServicesAPI.Core.Entities.DataTransferObject;

namespace ServicesAPI.Application.Services.Validation
{
    public class ServiceCategoryBaseValidator<T> : AbstractValidator<T> where T : ServiceCategoryForManipulationDto
    {
        public ServiceCategoryBaseValidator()
        {
            RuleFor(x => x.CategoryName).Length(2, 30);
        }
    }
}
