using ServicesAPI.Core.Entities.Models;

namespace ServicesAPI.Core.Exceptions.UserClassExceptions
{
    public class ServiceCategoryNotFoundException : NotFoundException
    {
        public ServiceCategoryNotFoundException(Guid serviceCategoryId) : base($"The service category with the identifier {serviceCategoryId} was not found.")
        {
        }
    }
}
