using Microsoft.EntityFrameworkCore;
using InnoClinic.ServicesAPI.Core.Contracts.Repositories;
using InnoClinic.ServicesAPI.Core.Entities.Models;
using InnoClinic.ServicesAPI.Core.Entities.QueryParameters;
using InnoClinic.ServicesAPI.Infrastructure.Repository;

namespace InnoClinic.ServicesAPI.Core.Repository.UserClasses
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
                .Include(service => service.Specialization)
                .ToListAsync() :
            await FindAll(trackChanges)
                .Include(service => service.ServiceCategory)
                .Include(service => service.Specialization)
                .ToListAsync();

        public async Task<Service> GetServiceAsync(Guid serviceId, bool trackChanges = false) =>
            await FindByCondition(service => service.Id.Equals(serviceId), trackChanges)
                .Include(service => service.ServiceCategory)
                .Include(service => service.Specialization)
                .SingleOrDefaultAsync();
    }
}
