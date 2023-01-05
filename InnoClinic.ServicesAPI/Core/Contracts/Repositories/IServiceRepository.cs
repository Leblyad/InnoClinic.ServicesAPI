using InnoClinic.ServicesAPI.Core.Entities.Models;
using InnoClinic.ServicesAPI.Core.Entities.QueryParameters;

namespace InnoClinic.ServicesAPI.Core.Contracts.Repositories
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAllServicesAsync(ServiceParameters serviceParameters, bool trackChanges = false);
        Task<Service> GetServiceAsync(Guid serviceId, bool trackChanges = false);
        Task CreateServiceAsync(Service service);
        Task DeleteServiceAsync(Service service);
    }
}
