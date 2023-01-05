using InnoClinic.ServicesAPI.Core.Contracts.Repositories;
using InnoClinic.ServicesAPI.Core.Entities.Models;
using InnoClinic.ServicesAPI.Core.Entities.QueryParameters;
using InnoClinic.ServicesAPI.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace InnoClinic.ServicesAPI.Core.Repository.UserClasses
{
    public class SpecializationRepository : RepositoryBase<Specialization>, ISpecializationRepository
    {
        public SpecializationRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task CreateSpecializationAsync(Specialization specialization)
        {
            Create(specialization);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task DeleteSpecializationAsync(Specialization specialization)
        {
            Delete(specialization);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Specialization>> GetAllSpecializationsAsync(SpecializationParameters specializationParameters, bool trackChanges = false) =>
            specializationParameters.PageNumber > 0
            && specializationParameters.PageSize > 0 ?
            await FindAll(trackChanges)
                .Skip((specializationParameters.PageNumber - 1) * specializationParameters.PageSize)
                .Take(specializationParameters.PageSize)
                .ToListAsync() :
            await FindAll(trackChanges)
                .ToListAsync();

        public async Task<Specialization> GetSpecializationAsync(Guid specializationId, bool trackChanges = false) =>
            await FindByCondition(specialization => specialization.Id.Equals(specializationId), trackChanges)
                .SingleOrDefaultAsync();
    }
}
