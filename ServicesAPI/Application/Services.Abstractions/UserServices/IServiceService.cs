using ServicesAPI.Core.Entities.DataTransferObject;
using ServicesAPI.Core.Entities.QueryParameters;

namespace ServicesAPI.Core.Services.Abstractions.UserServices
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceDto>> GetAllServicesAsync(ServiceParameters serviceParameters);
        Task<ServiceDto> GetServiceAsync(Guid serviceId);
        Task<ServiceDto> CreateServiceAsync(ServiceForCreationDto service);
        Task UpdateServiceAsync(Guid serviceId, ServiceForUpdateDto service);
        Task DeleteServiceAsync(Guid serviceId);
    }
}
