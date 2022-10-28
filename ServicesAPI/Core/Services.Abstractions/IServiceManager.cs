namespace ServicesAPI.Core.Services.Abstractions
{
    public interface IServiceManager
    {
        IServiceCategoryService CategoryService { get; }
        IServiceService Service { get; }
    }
}
