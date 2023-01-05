using InnoClinic.ServicesAPI.Core.Entities.Models;
using InnoClinic.ServicesAPI.Core.Entities.QueryParameters;

namespace InnoClinic.ServicesAPI.Core.Contracts.Repositories
{
    public interface IServiceCategoryRepository
    {
        Task<IEnumerable<ServiceCategory>> GetAllServiceCategoriesAsync(ServiceCategoryParameters serviceCategoryParameters, bool trackChanges = false);
        Task<ServiceCategory> GetServiceCategoryAsync(Guid serviceCategoryId, bool trackChanges = false);
        Task CreateServiceCategoryAsync(ServiceCategory serviceCategory);
        Task DeleteServiceCategoryAsync(ServiceCategory serviceCategory);
    }
}
