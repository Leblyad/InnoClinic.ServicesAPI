using Microsoft.EntityFrameworkCore;
using ServicesAPI.Core.Contracts.Repositories;
using ServicesAPI.Core.Entities.Models;
using ServicesAPI.Infrastructure.Repository;

namespace ServicesAPI.Core.Repository.UserClasses
{
    public class ServiceCategoryRepository : RepositoryBase<ServiceCategory>, IServiceCategoryRepository
    {
        public ServiceCategoryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task CreateServiceCategoryAsync(ServiceCategory serviceCategory)
        {
            Create(serviceCategory);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task DeleteServiceCategoryAsync(ServiceCategory serviceCategory)
        {
            Delete(serviceCategory);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ServiceCategory>> GetAllServiceCategoriesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(category => category.CategoryName)
            .ToListAsync();

        public async Task<ServiceCategory> GetServiceCategoryAsync(Guid serviceCategoryId, bool trackChanges) =>
            await FindByCondition(serviceCategory => serviceCategory.Id.Equals(serviceCategoryId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
