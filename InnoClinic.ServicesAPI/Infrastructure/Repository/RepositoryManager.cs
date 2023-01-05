using InnoClinic.ServicesAPI.Core.Contracts;
using InnoClinic.ServicesAPI.Core.Contracts.Repositories;
using InnoClinic.ServicesAPI.Core.Repository.UserClasses;
using InnoClinic.ServicesAPI.Infrastructure.Repository;

namespace InnoClinic.ServicesAPI.Core.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IServiceRepository _serviceRepository;
        private IServiceCategoryRepository _serviceCategoryRepository;
        private ISpecializationRepository _specializationRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IServiceRepository Service
        {
            get
            {
                if (_serviceRepository == null)
                    _serviceRepository = new ServiceRepository(_repositoryContext);

                return _serviceRepository;
            }
        }

        public IServiceCategoryRepository ServiceCategory
        {
            get
            {
                if (_serviceCategoryRepository == null)
                    _serviceCategoryRepository = new ServiceCategoryRepository(_repositoryContext);

                return _serviceCategoryRepository;
            }
        }

        public ISpecializationRepository Specialization
        {
            get
            {
                if (_specializationRepository == null)
                    _specializationRepository = new SpecializationRepository(_repositoryContext);

                return _specializationRepository;
            }
        }

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
