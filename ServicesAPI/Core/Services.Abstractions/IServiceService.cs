using ServicesAPI.Core.Entities.DataTransferObject;

namespace ServicesAPI.Core.Services.Abstractions
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceDto>> GetAllServicesAsync();
        Task<ServiceDto> GetServiceAsync(Guid serviceId);
        Task<ServiceDto> CreateServiceAsync(ServiceForCreationDto service);
        Task UpdateServiceAsync(Guid serviceId,ServiceForUpdateDto service);
        Task DeleteServiceAsync(Guid serviceId);
    }
}
