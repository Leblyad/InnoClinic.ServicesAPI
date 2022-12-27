namespace InnoClinic.ServicesAPI.Core.Exceptions.UserClassExceptions
{
    public class SpecializationNotFoundException : NotFoundException
    {
        public SpecializationNotFoundException(Guid serviceId) : base($"The specialization with the identifier {serviceId} was not found.")
        {
        }
    }
}
