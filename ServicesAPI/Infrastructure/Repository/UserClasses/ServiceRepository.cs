using Microsoft.EntityFrameworkCore;
using ServicesAPI.Core.Contracts.Repositories;
using ServicesAPI.Core.Entities.Models;
using ServicesAPI.Core.Entities.QueryParameters;
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

        public async Task<IEnumerable<Service>> GetAllServicesAsync(ServiceParameters serviceParameters, bool trackChanges = false) =>
            serviceParameters.PageNumber > 0
            && serviceParameters.PageSize > 0 ?
            await FindAll(trackChanges)
                .Skip((serviceParameters.PageNumber - 1) * serviceParameters.PageSize)
                .Take(serviceParameters.PageSize)
                .Include(service => service.ServiceCategory)
                .ToListAsync() :
            await FindAll(trackChanges)
                .Include(service => service.ServiceCategory)
                .ToListAsync();

        public async Task<Service> GetServiceAsync(Guid serviceId, bool trackChanges = false) =>
            await FindByCondition(service => service.Id.Equals(serviceId), trackChanges)
                .Include(service => service.ServiceCategory)
                .SingleOrDefaultAsync();
    }
}
