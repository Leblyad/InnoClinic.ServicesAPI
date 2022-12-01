namespace ServicesAPI.Core.Exceptions.UserClassExceptions
{
    public class ServiceBadRequestException : BadRequestException
    {
        public ServiceBadRequestException() : base("ServiceForCreation dto is not valid")
        {
        }
    }
}
