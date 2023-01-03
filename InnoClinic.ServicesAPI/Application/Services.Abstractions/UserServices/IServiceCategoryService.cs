using InnoClinic.ServicesAPI.Application.Entities.DataTransferObject;
using InnoClinic.ServicesAPI.Core.Entities.QueryParameters;

namespace InnoClinic.ServicesAPI.Core.Services.Abstractions.UserServices
{
    public interface IServiceCategoryService
    {
        Task<IEnumerable<ServiceCategoryDto>> GetAllServiceCategoriesAsync(ServiceCategoryParameters serviceCategoryParameters);
        Task<ServiceCategoryDto> GetServiceCategoryAsync(Guid serviceCategoryId);
        Task<ServiceCategoryDto> CreateServiceCategoryAsync(ServiceCategoryForCreationDto serviceCategory);
        Task UpdateServiceCategoryAsync(Guid serviceCategoryId, ServiceCategoryForUpdateDto serviceCategory);
        Task DeleteServiceCategoryAsync(Guid serviceCategoryId);
    }
}
