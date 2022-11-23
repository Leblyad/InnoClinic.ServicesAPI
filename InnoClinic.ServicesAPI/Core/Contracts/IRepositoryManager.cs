using ServicesAPI.Core.Contracts.Repositories;

namespace ServicesAPI.Core.Contracts
{
    public interface IRepositoryManager
    {
        IServiceRepository Service { get; }
        IServiceCategoryRepository ServiceCategory { get; }
        Task SaveAsync();
    }
}
