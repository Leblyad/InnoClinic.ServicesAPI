using ServicesAPI.Core.Entities.Models;

namespace ServicesAPI.Core.Contracts.Repositories
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAllServicesAsync(bool trackChanges);
        Task<Service> GetServiceAsync(bool trackChanges);
        void CreateService(Service service);
        void DeleteService(Service service);
    }
}
