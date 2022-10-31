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

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _lazyServiceService = new Lazy<IServiceService>(() => new ServiceService(repositoryManager, mapper));   
        }

        public IServiceCategoryService CategoryService => throw new NotImplementedException();

        public IServiceService Service => _lazyServiceService.Value;
    }
}
