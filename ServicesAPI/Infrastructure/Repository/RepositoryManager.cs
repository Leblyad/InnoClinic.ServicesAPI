using ServicesAPI.Core.Contracts.Repositories;
using ServicesAPI.Core.Repository.UserClasses;
using ServicesAPI.Infrastructure.Repository;

namespace ServicesAPI.Core.Repository
{
    public class RepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IServiceRepository _serviceRepository;
        private IServiceCategoryRepository _serviceCategoryRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IServiceRepository Service
        {
            get {
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
    }
}
