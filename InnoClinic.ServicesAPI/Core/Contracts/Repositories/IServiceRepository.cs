using ServicesAPI.Core.Entities.Models;
using ServicesAPI.Core.Entities.QueryParameters;

namespace ServicesAPI.Core.Contracts.Repositories
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAllServicesAsync(ServiceParameters serviceParameters, bool trackChanges = false);
        Task<Service> GetServiceAsync(Guid serviceId, bool trackChanges = false);
        Task CreateServiceAsync(Service service);
        Task DeleteServiceAsync(Service service);
    }
}
