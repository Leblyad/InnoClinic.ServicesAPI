using AutoMapper;
using ServicesAPI.Core.Contracts;
using ServicesAPI.Core.Entities.DataTransferObject;
using ServicesAPI.Core.Entities.Models;
using ServicesAPI.Core.Entities.QueryParameters;
using ServicesAPI.Core.Exceptions.UserClassExceptions;
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

        public async Task<ServiceCategoryDto> CreateServiceCategoryAsync(ServiceCategoryForCreationDto serviceCategory)
        {
            var serviceCategoryEntity = _mapper.Map<ServiceCategory>(serviceCategory);
            await _repositoryManager.ServiceCategory.CreateServiceCategoryAsync(serviceCategoryEntity);

            return _mapper.Map<ServiceCategoryDto>(serviceCategoryEntity);
        }

        public async Task DeleteServiceCategoryAsync(Guid serviceCategoryId)
        {
            var serviceCategory = await _repositoryManager.ServiceCategory.GetServiceCategoryAsync(serviceCategoryId);

            if (serviceCategory == null)
            {
                throw new ServiceCategoryNotFoundException(serviceCategoryId);
            }

            await _repositoryManager.ServiceCategory.DeleteServiceCategoryAsync(serviceCategory);
        }

        public async Task<IEnumerable<ServiceCategoryDto>> GetAllServiceCategoriesAsync(ServiceCategoryParameters serviceCategoryParameters)
        {
            var serviceCategories = await _repositoryManager.ServiceCategory.GetAllServiceCategoriesAsync(serviceCategoryParameters);

            return _mapper.Map<IEnumerable<ServiceCategoryDto>>(serviceCategories);
        }

        public async Task<ServiceCategoryDto> GetServiceCategoryAsync(Guid serviceCategoryId)
        {
            var serviceCategoryEntity = await _repositoryManager.ServiceCategory.GetServiceCategoryAsync(serviceCategoryId);

            if (serviceCategoryEntity == null)
            {
                throw new ServiceCategoryNotFoundException(serviceCategoryId);
            }

            return _mapper.Map<ServiceCategoryDto>(serviceCategoryEntity);
        }

        public async Task UpdateServiceCategoryAsync(Guid serviceCategoryId, ServiceCategoryForUpdateDto serviceCategory)
        {
            var serviceCategoryEntity = await _repositoryManager.ServiceCategory.GetServiceCategoryAsync(serviceCategoryId, trackChanges: true);

            if (serviceCategory == null)
            {
                throw new ServiceCategoryNotFoundException(serviceCategoryId);
            }

            _mapper.Map(serviceCategory, serviceCategoryEntity);

            await _repositoryManager.SaveAsync();
        }

    }
}
