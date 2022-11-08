namespace ServicesAPI.Core.Exceptions
{
    public abstract class BadRequestException : Exception
    {
        protected BadRequestException(string message)
            : base(message)
        { }
    }
}
