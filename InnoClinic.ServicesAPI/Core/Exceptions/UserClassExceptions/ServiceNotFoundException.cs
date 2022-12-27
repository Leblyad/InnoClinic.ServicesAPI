namespace InnoClinic.ServicesAPI.Core.Exceptions.UserClassExceptions
{
    public class ServiceNotFoundException : NotFoundException
    {
        public ServiceNotFoundException(Guid serviceId) : base($"The service with the identifier {serviceId} was not found.")
        {
        }
    }
}
