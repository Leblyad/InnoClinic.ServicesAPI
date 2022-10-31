using AutoMapper;
using ServicesAPI.Core.Contracts;
using ServicesAPI.Core.Entities.DataTransferObject;
using ServicesAPI.Core.Entities.Models;
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

        public async Task<ServiceCategoryDto> CreateServiceCategory(ServiceCategoryForCreationDto serviceCategory)
        {
            var serviceCategoryEntity = _mapper.Map<ServiceCategory>(serviceCategory);

            _repositoryManager.ServiceCategory.CreateServiceCategory(serviceCategoryEntity);
            await _repositoryManager.SaveAsync();

            var serviceCategoryDto = _mapper.Map<ServiceCategoryDto>(serviceCategoryEntity);

            return serviceCategoryDto;
        }

        public async Task DeleteServiceCategory(Guid serviceCategoryId)
        {
            var serviceCategory = await _repositoryManager.ServiceCategory.GetServiceCategoryAsync(serviceCategoryId, trackChanges: false);

            _repositoryManager.ServiceCategory.DeleteServiceCategory(serviceCategory);
            await _repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<ServiceCategoryDto>> GetAllServiceCategoriesAsync()
        {
            var serviceCategories = await _repositoryManager.ServiceCategory.GetAllServiceCategoriesAsync(trackChanges: false);

            var serviceCategoriesDto = _mapper.Map<IEnumerable<ServiceCategoryDto>>(serviceCategories);

            return serviceCategoriesDto;
        }

        public async Task<ServiceCategoryDto> GetServiceCategoryAsync(Guid serviceCategoryId)
        {
            var serviceCategoryEntity = await _repositoryManager.ServiceCategory.GetServiceCategoryAsync(serviceCategoryId, trackChanges: false);

            var serviceCategoryDto = _mapper.Map<ServiceCategoryDto>(serviceCategoryEntity);

            return serviceCategoryDto;
        }

        public async Task UpdateServiceCategory(Guid serviceCategoryId, ServiceCategoryForUpdateDto serviceCategory)
        {
            var serviceCategoryEntity = await _repositoryManager.ServiceCategory.GetServiceCategoryAsync(serviceCategoryId, trackChanges: false);
            serviceCategoryEntity = _mapper.Map<ServiceCategory>(serviceCategory);

            _repositoryManager.ServiceCategory.UpdateServiceCategory(serviceCategoryEntity);
            await _repositoryManager.SaveAsync();
        }
    }
}
