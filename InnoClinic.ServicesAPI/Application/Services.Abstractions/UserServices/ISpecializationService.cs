using InnoClinic.ServicesAPI.Application.Entities.DataTransferObject;
using InnoClinic.ServicesAPI.Core.Entities.QueryParameters;

namespace InnoClinic.ServicesAPI.Core.Services.Abstractions.UserServices
{
    public interface ISpecializationService
    {
        Task<IEnumerable<SpecializationDto>> GetAllSpecializationsAsync(SpecializationParameters specializationParameters);
        Task<SpecializationDto> GetSpecializationAsync(Guid specializationId);
        Task<SpecializationDto> CreateSpecializationAsync(SpecializationForCreationDto specialization);
        Task UpdateSpecializationAsync(Guid specializationId, SpecializationForUpdateDto specialization);
        Task DeleteSpecializationAsync(Guid specializationId);
    }
}
