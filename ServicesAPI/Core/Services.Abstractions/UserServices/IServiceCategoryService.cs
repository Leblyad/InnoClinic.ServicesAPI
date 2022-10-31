using ServicesAPI.Core.Entities.DataTransferObject;

namespace ServicesAPI.Core.Services.Abstractions.UserServices
{
    public interface IServiceCategoryService
    {
        Task<IEnumerable<ServiceCategoryDto>> GetAllServiceCategoriesAsync();
        Task<ServiceCategoryDto> GetServiceCategoryAsync(Guid serviceCategoryId);
        Task<ServiceCategoryDto> CreateServiceCategory(ServiceCategoryForCreationDto serviceCategory);
        Task UpdateServiceCategory(Guid serviceCategoryId, ServiceCategoryForUpdateDto serviceCategory);
        Task DeleteServiceCategory(Guid serviceCategoryId);
    }
}
