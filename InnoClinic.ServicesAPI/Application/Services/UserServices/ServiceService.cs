using AutoMapper;
using InnoClinic.ServicesAPI.Application.Entities.DataTransferObject;
using InnoClinic.ServicesAPI.Core.Contracts;
using InnoClinic.ServicesAPI.Core.Entities.Models;
using InnoClinic.ServicesAPI.Core.Entities.QueryParameters;
using InnoClinic.ServicesAPI.Core.Exceptions;
using InnoClinic.ServicesAPI.Core.Exceptions.UserClassExceptions;
using InnoClinic.ServicesAPI.Core.Services.Abstractions.UserServices;
using InnoClinic.SharedModels;
using MassTransit;

namespace InnoClinic.ServicesAPI.Core.Services.UserServices
{
    public class ServiceService : IServiceService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public ServiceService(IRepositoryManager repositoryManager, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<ServiceDto> CreateServiceAsync(ServiceForCreationDto service)
        {
            if (service == null)
            {
                throw new CustomNullReferenceException(typeof(ServiceForCreationDto));
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
                throw new CustomNullReferenceException(typeof(ServiceForUpdateDto));
            }

            var serviceEntity = await _repositoryManager.Service.GetServiceAsync(serviceId, trackChanges: true);

            if (serviceEntity == null)
            {
                throw new ServiceNotFoundException(serviceId);
            }

            _mapper.Map(service, serviceEntity);

            var message = _mapper.Map<ServiceUpdatedMessage>(serviceEntity);

            await _repositoryManager.SaveAsync();

            using (var tokenSrc = new CancellationTokenSource())
            {
                tokenSrc.CancelAfter(5000);
                try
                {
                    await _publishEndpoint.Publish(message, tokenSrc.Token);
                }
                catch { }
            }
        }
    }
}
