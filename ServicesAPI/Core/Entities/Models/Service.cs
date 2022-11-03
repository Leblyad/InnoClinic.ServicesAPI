namespace ServicesAPI.Core.Entities.Models
{
    public class Service
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
        public string SpecializationName { get; set; }
        public Guid ServiceCategoryId { get; set; }
        public ServiceCategory ServiceCategory { get; set; }
    }
}
