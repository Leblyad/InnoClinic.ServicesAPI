using ServicesAPI.Core.Contracts;
using ServicesAPI.Core.Entities.DataTransferObject;
using ServicesAPI.Core.Entities.Models;
using ServicesAPI.Core.Services.Abstractions;

namespace ServicesAPI.Core.Services
{
    internal sealed class ServiceService : IServiceService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ServiceService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public Task<ServiceDto> CreateService(ServiceForCreationDto service)
        {
            throw new NotImplementedException();
        }

        public Task DeleteService(Guid serviceId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ServiceDto>> GetAllServicesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceDto> GetServiceAsync(Guid serviceId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateService(Guid serviceId, ServiceForUpdateDto service)
        {
            throw new NotImplementedException();
        }
    }
}
