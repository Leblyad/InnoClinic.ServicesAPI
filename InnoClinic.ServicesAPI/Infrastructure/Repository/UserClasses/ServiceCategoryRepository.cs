using InnoClinic.ServicesAPI.Core.Contracts.Repositories;
using InnoClinic.ServicesAPI.Core.Entities.Models;
using InnoClinic.ServicesAPI.Core.Entities.QueryParameters;
using InnoClinic.ServicesAPI.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace InnoClinic.ServicesAPI.Core.Repository.UserClasses
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

        public async Task<IEnumerable<ServiceCategory>> GetAllServiceCategoriesAsync(ServiceCategoryParameters serviceCategoryParameters, bool trackChanges = false) =>
            serviceCategoryParameters.PageNumber > 0
            && serviceCategoryParameters.PageSize > 0 ?
            await FindAll(trackChanges)
                .OrderBy(category => category.CategoryName)
                .Skip((serviceCategoryParameters.PageNumber - 1) * serviceCategoryParameters.PageSize)
                .Take(serviceCategoryParameters.PageSize)
                .ToListAsync() :
             await FindAll(trackChanges)
                .OrderBy(category => category.CategoryName)
                .ToListAsync();

        public async Task<ServiceCategory> GetServiceCategoryAsync(Guid serviceCategoryId, bool trackChanges = false) =>
            await FindByCondition(serviceCategory => serviceCategory.Id.Equals(serviceCategoryId), trackChanges)
                .SingleOrDefaultAsync();
    }
}
