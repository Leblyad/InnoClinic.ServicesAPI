using Microsoft.EntityFrameworkCore;
using ServicesAPI.Core.Contracts.Repositories;
using ServicesAPI.Core.Entities;
using ServicesAPI.Core.Entities.Models;

namespace ServicesAPI.Core.Repository.UserClasses
{
    public class ServiceCategoryRepository : RepositoryBase<ServiceCategory>, IServiceCategoryRepository
    {
        public ServiceCategoryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateServiceCategory(ServiceCategory serviceCategory) => Create(serviceCategory);

        public void DeleteServiceCategory(ServiceCategory serviceCategory) => Delete(serviceCategory);

        public async Task<IEnumerable<ServiceCategory>> GetAllServiceCategoriesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(category => category.CategoryName)
            .ToListAsync();

        public async Task<ServiceCategory> GetServiceCategoryAsync(Guid serviceCategory, bool trackChanges) =>
            await FindByCondition(serviceCategory => serviceCategory.Id.Equals(serviceCategory), trackChanges)
            .SingleOrDefaultAsync();
    }
}
