using InnoClinic.ServicesAPI.Core.Entities.Models;

namespace InnoClinic.ServicesAPI.Core.Entities.DataTransferObject
{
    public class ServiceDto
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
        public Specialization Specialization { get; set; }
        public ServiceCategory ServiceCategory { get; set; }
    }
}
