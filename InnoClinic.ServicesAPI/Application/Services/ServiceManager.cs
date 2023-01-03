using AutoMapper;
using InnoClinic.ServicesAPI.Core.Contracts;
using InnoClinic.ServicesAPI.Core.Services.Abstractions;
using InnoClinic.ServicesAPI.Core.Services.Abstractions.UserServices;
using InnoClinic.ServicesAPI.Core.Services.UserServices;
using MassTransit;

namespace InnoClinic.ServicesAPI.Core.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IServiceService> _lazyServiceService;
        private readonly Lazy<IServiceCategoryService> _lazyServiceCategoryService;
        private readonly Lazy<ISpecializationService> _lazySpecializationService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, IPublishEndpoint publisher)
        {
            _lazyServiceService = new Lazy<IServiceService>(() => new ServiceService(repositoryManager, mapper, publisher));
            _lazyServiceCategoryService = new Lazy<IServiceCategoryService>(() => new ServiceCategoryService(repositoryManager, mapper));
            _lazySpecializationService = new Lazy<ISpecializationService>(() => new SpecializationService(repositoryManager, mapper));
        }

        public IServiceCategoryService CategoryService => _lazyServiceCategoryService.Value;

        public IServiceService Service => _lazyServiceService.Value;

        public ISpecializationService Specialization => _lazySpecializationService.Value;
    }
}
