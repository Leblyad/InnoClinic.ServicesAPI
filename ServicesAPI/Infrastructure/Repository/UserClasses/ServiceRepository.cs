using Microsoft.EntityFrameworkCore;
using ServicesAPI.Core.Contracts.Repositories;
using ServicesAPI.Core.Entities.Models;
using ServicesAPI.Infrastructure.Repository;

namespace ServicesAPI.Core.Repository.UserClasses
{
    public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {
        public ServiceRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task CreateServiceAsync(Service service)
        {
            Create(service);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task DeleteServiceAsync(Service service)
        {
            Delete(service);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Service>> GetAllServicesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .Include(serviceCategory => serviceCategory.ServiceCategory)
            .ToListAsync();

        public async Task<Service> GetServiceAsync(Guid serviceId, bool trackChanges) =>
            await FindByCondition(service => service.Id.Equals(serviceId), trackChanges)
            .Include(service => service.ServiceCategory)
            .SingleOrDefaultAsync();
    }
}
