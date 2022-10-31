using AutoMapper;
using ServicesAPI.Core.Contracts;
using ServicesAPI.Core.Entities.DataTransferObject;
using ServicesAPI.Core.Entities.Models;
using ServicesAPI.Core.Services.Abstractions;

namespace ServicesAPI.Core.Services.UserServices
{
    internal sealed class ServiceService : IServiceService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ServiceService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ServiceDto> CreateService(ServiceForCreationDto service)
        {
            var serviceEntity = _mapper.Map<Service>(service);

            _repositoryManager.Service.CreateService(serviceEntity);
            await _repositoryManager.SaveAsync();

            var serviceDto = _mapper.Map<ServiceDto>(serviceEntity);

            return serviceDto;
        }

        public async Task DeleteService(Guid serviceId)
        {
            var service = await _repositoryManager.Service.GetServiceAsync(serviceId, trackChanges: false);

            _repositoryManager.Service.DeleteService(service);
            await _repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<ServiceDto>> GetAllServicesAsync()
        {
            var services = await _repositoryManager.Service.GetAllServicesAsync(trackChanges: false);

            var servicesDto = _mapper.Map<IEnumerable<ServiceDto>>(services);

            return servicesDto;
        }

        public async Task<ServiceDto> GetServiceAsync(Guid serviceId)
        {
            var service = await _repositoryManager.Service.GetServiceAsync(serviceId, trackChanges: false);

            var serviceDto = _mapper.Map<ServiceDto>(service);

            return serviceDto;
        }

        public async Task UpdateService(Guid serviceId, ServiceForUpdateDto service)
        {
            var serviceEntity = await _repositoryManager.Service.GetServiceAsync(serviceId, trackChanges: false);
            serviceEntity = _mapper.Map<Service>(service);

            _repositoryManager.Service.UpdateService(serviceEntity);
            await _repositoryManager.SaveAsync();
        }
    }
}
