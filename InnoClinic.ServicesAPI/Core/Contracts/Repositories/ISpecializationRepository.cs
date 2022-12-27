using InnoClinic.ServicesAPI.Core.Entities.Models;
using InnoClinic.ServicesAPI.Core.Entities.QueryParameters;

namespace InnoClinic.ServicesAPI.Core.Contracts.Repositories
{
    public interface ISpecializationRepository
    {
        Task<IEnumerable<Specialization>> GetAllSpecializationsAsync(SpecializationParameters specializationParameters, bool trackChanges = false);
        Task<Specialization> GetSpecializationAsync(Guid specializationId, bool trackChanges = false);
        Task CreateSpecializationAsync(Specialization specialization);
        Task DeleteSpecializationAsync(Specialization specialization);
    }
}
