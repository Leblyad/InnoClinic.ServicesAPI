using AutoMapper;
using ServicesAPI.Core.Contracts;
using ServicesAPI.Core.Services.Abstractions;
using ServicesAPI.Core.Services.Abstractions.UserServices;
using ServicesAPI.Core.Services.UserServices;

namespace ServicesAPI.Core.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IServiceService> _lazyServiceService;
        private readonly Lazy<IServiceCategoryService> _lazyServiceCategoryService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _lazyServiceService = new Lazy<IServiceService>(() => new ServiceService(repositoryManager, mapper));
            _lazyServiceCategoryService = new Lazy<IServiceCategoryService>(() => new ServiceCategoryService(repositoryManager, mapper));
        }

        public IServiceCategoryService CategoryService => _lazyServiceCategoryService.Value;

        public IServiceService Service => _lazyServiceService.Value;
    }
}
