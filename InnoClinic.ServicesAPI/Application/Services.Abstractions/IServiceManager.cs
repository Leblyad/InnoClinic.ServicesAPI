using ServicesAPI.Core.Services.Abstractions.UserServices;

namespace ServicesAPI.Core.Services.Abstractions
{
    public interface IServiceManager
    {
        IServiceCategoryService CategoryService { get; }
        IServiceService Service { get; }
    }
}
