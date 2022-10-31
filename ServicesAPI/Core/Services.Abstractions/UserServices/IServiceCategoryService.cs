using ServicesAPI.Core.Entities.DataTransferObject;

namespace ServicesAPI.Core.Services.Abstractions.UserServices
{
    public interface IServiceCategoryService
    {
        Task<IEnumerable<ServiceDto>> GetAllServicesAsync();
        Task<ServiceDto> GetServiceAsync(Guid serviceCategoryId);
        Task<ServiceDto> CreateService(ServiceCategoryForCreationDto serviceCategory);
        Task UpdateService(Guid serviceCategoryId, ServiceCategoryForUpdateDto serviceCategory);
        Task DeleteService(Guid serviceCategoryId);
    }
}
