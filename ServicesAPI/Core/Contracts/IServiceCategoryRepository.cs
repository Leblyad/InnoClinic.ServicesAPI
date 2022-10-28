using ServicesAPI.Core.Entities.Models;

namespace ServicesAPI.Core.Contracts
{
    public interface IServiceCategoryRepository
    {
        Task<IEnumerable<ServiceCategory>> GetAllServiceCategoriesAsync(bool trackChanges);
        Task<ServiceCategory> GetServiceCategoryAsync(bool trackChanges);
        void CreateServiceCategory(ServiceCategory serviceCategory);
        void DeleteServiceCategory(ServiceCategory serviceCategory);
    }
}
