using ServicesAPI.Core.Entities.Models;

namespace ServicesAPI.Core.Contracts.Repositories
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAllServicesAsync(bool trackChanges);
        Task<Service> GetServiceAsync(Guid serviceId, bool trackChanges);
        Task CreateServiceAsync(Service service);
        Task DeleteServiceAsync(Service service);
    }
}
