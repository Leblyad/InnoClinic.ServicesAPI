using ServicesAPI.Core.Entities.DataTransferObject;

namespace ServicesAPI.Core.Services.Abstractions
{
    public interface IServiceCategoryService
    {
        Task<IEnumerable<ServiceDto>> GetAllServicesAsync();
        Task<ServiceDto> GetServiceAsync(Guid serviceCategoryId);
        Task<ServiceDto> CreateServiceAsync(ServiceCategoryForCreationDto serviceCategory);
        Task UpdateServiceAsync(Guid serviceCategoryId, ServiceCategoryForUpdateDto serviceCategory);
        Task DeleteServiceAsync(Guid serviceCategoryId);
    }
}
