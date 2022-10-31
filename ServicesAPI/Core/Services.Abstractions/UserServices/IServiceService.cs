using ServicesAPI.Core.Entities.DataTransferObject;

namespace ServicesAPI.Core.Services.Abstractions.UserServices
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceDto>> GetAllServicesAsync();
        Task<ServiceDto> GetServiceAsync(Guid serviceId);
        Task<ServiceDto> CreateService(ServiceForCreationDto service);
        Task UpdateService(Guid serviceId, ServiceForUpdateDto service);
        Task DeleteService(Guid serviceId);
    }
}
