using InnoClinic.ServicesAPI.Core.Contracts.Repositories;

namespace InnoClinic.ServicesAPI.Core.Contracts
{
    public interface IRepositoryManager
    {
        IServiceRepository Service { get; }
        IServiceCategoryRepository ServiceCategory { get; }
        ISpecializationRepository Specialization { get; }
        Task SaveAsync();
    }
}
