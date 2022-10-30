using Microsoft.EntityFrameworkCore;
using ServicesAPI.Core.Contracts.Repositories;
using ServicesAPI.Core.Entities;
using ServicesAPI.Core.Entities.Models;

namespace ServicesAPI.Core.Repository.UserClasses
{
    public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {
        public ServiceRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {  
        }

        public void CreateService(Service service) => Create(service);

        public void DeleteService(Service service) => Delete(service);

        public async Task<IEnumerable<Service>> GetAllServicesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .Include(serviceCategory => serviceCategory.Category)
            .ToListAsync();

        public async Task<Service> GetServiceAsync(Guid serviceId, bool trackChanges) =>
            await FindByCondition(service => service.Id.Equals(serviceId), trackChanges)
            .Include(service => service.Category)
            .SingleOrDefaultAsync();
    }
}
