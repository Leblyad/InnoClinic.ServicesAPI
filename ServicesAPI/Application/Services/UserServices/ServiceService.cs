using AutoMapper;
using ServicesAPI.Core.Contracts;
using ServicesAPI.Core.Entities.DataTransferObject;
using ServicesAPI.Core.Entities.Models;
using ServicesAPI.Core.Entities.QueryParameters;
using ServicesAPI.Core.Exceptions.UserClassExceptions;
using ServicesAPI.Core.Services.Abstractions.UserServices;

namespace ServicesAPI.Core.Services.UserServices
{
    public class ServiceService : IServiceService
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
            if (service == null)
            {
                throw new ServiceNullReferenceException(typeof(ServiceForCreationDto));
            }

            var serviceEntity = _mapper.Map<Service>(service);
            await _repositoryManager.Service.CreateServiceAsync(serviceEntity);

            return _mapper.Map<ServiceDto>(serviceEntity);
        }

        public async Task DeleteServiceAsync(Guid serviceId)
        {
            var service = await _repositoryManager.Service.GetServiceAsync(serviceId);

            if (service == null)
            {
                throw new ServiceNotFoundException(serviceId);
            }

            await _repositoryManager.Service.DeleteServiceAsync(service);
        }

        public async Task<IEnumerable<ServiceDto>> GetAllServicesAsync(ServiceParameters serviceParameters)
        {
            var services = await _repositoryManager.Service.GetAllServicesAsync(serviceParameters);

            return _mapper.Map<IEnumerable<ServiceDto>>(services);
        }

        public async Task<ServiceDto> GetServiceAsync(Guid serviceId)
        {
            var service = await _repositoryManager.Service.GetServiceAsync(serviceId);

            if (service == null)
            {
                throw new ServiceNotFoundException(serviceId);
            }

            return _mapper.Map<ServiceDto>(service);
        }

        public async Task UpdateServiceAsync(Guid serviceId, ServiceForUpdateDto service)
        {
            if (service == null)
            {
                throw new ServiceNullReferenceException(typeof(ServiceForUpdateDto));
            }

            var serviceEntity = await _repositoryManager.Service.GetServiceAsync(serviceId, trackChanges: true);

            if (serviceEntity == null)
            {
                throw new ServiceNotFoundException(serviceId);
            }

            _mapper.Map(service, serviceEntity);

            await _repositoryManager.SaveAsync();
        }
    }
}
