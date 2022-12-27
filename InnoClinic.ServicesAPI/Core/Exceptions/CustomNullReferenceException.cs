namespace InnoClinic.ServicesAPI.Core.Exceptions
{
    public abstract class CustomNullReferenceException : NullReferenceException
    {
        protected CustomNullReferenceException(string message)
            : base(message)
        { }
    }
}
