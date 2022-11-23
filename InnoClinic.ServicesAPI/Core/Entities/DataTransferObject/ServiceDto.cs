namespace ServicesAPI.Core.Entities.DataTransferObject
{
    public class ServiceDto
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
        public string SpecializationName { get; set; }
        public ServiceCategoryDto ServiceCategory { get; set; }
    }
}
