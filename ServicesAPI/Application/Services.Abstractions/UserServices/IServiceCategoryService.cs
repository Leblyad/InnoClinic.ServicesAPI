using ServicesAPI.Core.Entities.DataTransferObject;

namespace ServicesAPI.Core.Services.Abstractions.UserServices
{
    public interface IServiceCategoryService
    {
        Task<IEnumerable<ServiceCategoryDto>> GetAllServiceCategoriesAsync();
        Task<ServiceCategoryDto> GetServiceCategoryAsync(Guid serviceCategoryId);
        Task<ServiceCategoryDto> CreateServiceCategoryAsync(ServiceCategoryForCreationDto serviceCategory);
        Task UpdateServiceCategoryAsync(Guid serviceCategoryId, ServiceCategoryForUpdateDto serviceCategory);
        Task DeleteServiceCategoryAsync(Guid serviceCategoryId);
    }
}
