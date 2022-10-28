namespace ServicesAPI.Core.Entities.Models
{
    public class Service
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public float Price { get; set; }
        public string SpecializationName { get; set; }
        public Guid ServiceCategoryId { get; set; }
        public ServiceCategory Category { get; set; }
    }
}
