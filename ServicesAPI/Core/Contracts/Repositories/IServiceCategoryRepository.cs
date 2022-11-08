using ServicesAPI.Core.Entities.Models;

namespace ServicesAPI.Core.Contracts.Repositories
{
    public interface IServiceCategoryRepository
    {
        Task<IEnumerable<ServiceCategory>> GetAllServiceCategoriesAsync(bool trackChanges = false);
        Task<ServiceCategory> GetServiceCategoryAsync(Guid serviceCategoryId, bool trackChanges = false);
        Task CreateServiceCategoryAsync(ServiceCategory serviceCategory);
        Task DeleteServiceCategoryAsync(ServiceCategory serviceCategory);
    }
}
