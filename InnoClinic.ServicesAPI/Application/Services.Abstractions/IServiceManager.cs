using InnoClinic.ServicesAPI.Core.Services.Abstractions.UserServices;

namespace InnoClinic.ServicesAPI.Core.Services.Abstractions
{
    public interface IServiceManager
    {
        IServiceCategoryService CategoryService { get; }
        IServiceService Service { get; }
        ISpecializationService Specialization { get; }
    }
}
