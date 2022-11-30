using ServicesAPI.Application.Services.Validation;
using ServicesAPI.Application.Services.Validators;

namespace InnoClinic.ServicesAPI.Application.Validators
{
    public class ValidatorManager
    {
        private readonly ServiceCategoryForCreationValidator _serviceCategoryForCreation;
        private readonly ServiceCategoryForUpdateValidator _serviceCategoryForUpdate;
        private readonly ServiceForCreationValidator _serviceForCreationValidator;
        private readonly ServiceForUpdateValidator _serviceForUpdateValidator;
        public ValidatorManager(ServiceCategoryForCreationValidator serviceCategoryForCreation, ServiceCategoryForUpdateValidator serviceCategoryForUpdate,
            ServiceForCreationValidator serviceForCreationValidator, ServiceForUpdateValidator serviceForUpdateValidator)
        {
            _serviceCategoryForCreation = serviceCategoryForCreation;
            _serviceCategoryForUpdate = serviceCategoryForUpdate;
            _serviceForCreationValidator = serviceForCreationValidator;
            _serviceForUpdateValidator = serviceForUpdateValidator;
        }
    }
}
