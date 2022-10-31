using AutoMapper;
using ServicesAPI.Core.Contracts;
using ServicesAPI.Core.Entities.DataTransferObject;
using ServicesAPI.Core.Services.Abstractions.UserServices;

namespace ServicesAPI.Core.Services.UserServices
{
    public sealed class ServiceCategoryService : IServiceCategoryService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ServiceCategoryService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public Task<ServiceDto> CreateService(ServiceCategoryForCreationDto serviceCategory)
        {
            throw new NotImplementedException();
        }

        public Task DeleteService(Guid serviceCategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ServiceDto>> GetAllServicesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceDto> GetServiceAsync(Guid serviceCategoryId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateService(Guid serviceCategoryId, ServiceCategoryForUpdateDto serviceCategory)
        {
            throw new NotImplementedException();
        }
    }
}
