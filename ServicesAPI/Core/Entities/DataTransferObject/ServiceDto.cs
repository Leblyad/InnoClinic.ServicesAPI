using ServicesAPI.Core.Entities.Models;

namespace ServicesAPI.Core.Entities.DataTransferObject
{
    public class ServiceDto
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public float Price { get; set; }
        public string SpecializationName { get; set; }
        public ServiceCategoryDto Category { get; set; }
    }
}
