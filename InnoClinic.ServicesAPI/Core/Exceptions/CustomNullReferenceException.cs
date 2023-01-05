namespace InnoClinic.ServicesAPI.Core.Exceptions
{
    public class CustomNullReferenceException : NullReferenceException
    {
        public CustomNullReferenceException(Type type) : base($"Object of type: {type.Name} is null.")
        { }
    }
}
