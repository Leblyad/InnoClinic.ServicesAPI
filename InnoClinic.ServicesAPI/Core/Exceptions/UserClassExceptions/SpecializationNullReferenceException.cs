namespace InnoClinic.ServicesAPI.Core.Exceptions.UserClassExceptions
{
    public class SpecializationNullReferenceException : CustomNullReferenceException
    {
        public SpecializationNullReferenceException(Type type) : base($"Object of type: {type.Name} is null.")
        {

        }
    }
}
