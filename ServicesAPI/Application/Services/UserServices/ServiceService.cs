using AutoMapper;
using ServicesAPI.Core.Contracts;
using ServicesAPI.Core.Entities.DataTransferObject;
using ServicesAPI.Core.Entities.Models;
using ServicesAPI.Core.Services.Abstractions.UserServices;

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

        public async Task<ServiceDto> CreateServiceAsync(ServiceForCreationDto service)
        {
            var serviceEntity = _mapper.Map<Service>(service);
            await _repositoryManager.Service.CreateServiceAsync(serviceEntity);

            return _mapper.Map<ServiceDto>(serviceEntity);
        }

        public async Task DeleteServiceAsync(Guid serviceId)
        {
            var service = await _repositoryManager.Service.GetServiceAsync(serviceId, trackChanges: false);

            await _repositoryManager.Service.DeleteServiceAsync(service);
        }

        public async Task<IEnumerable<ServiceDto>> GetAllServicesAsync()
        {
            var services = await _repositoryManager.Service.GetAllServicesAsync(trackChanges: false);

            return _mapper.Map<IEnumerable<ServiceDto>>(services);
        }

        public async Task<ServiceDto> GetServiceAsync(Guid serviceId)
        {
            var service = await _repositoryManager.Service.GetServiceAsync(serviceId, trackChanges: false);

            return _mapper.Map<ServiceDto>(service);
        }

        public async Task UpdateServiceAsync(Guid serviceId, ServiceForUpdateDto service)
        {
            var serviceEntity = await _repositoryManager.Service.GetServiceAsync(serviceId, trackChanges: true);
            _mapper.Map(service, serviceEntity);

            await _repositoryManager.SaveAsync();
        }
    }
}
