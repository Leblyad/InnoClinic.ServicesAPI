namespace InnoClinic.ServicesAPI.Core.Exceptions.UserClassExceptions
{
    public class ServiceNullReferenceException : CustomNullReferenceException
    {
        public ServiceNullReferenceException(Type type) : base($"Object of type: {type.Name} is null.")
        {

        }
    }
}
