namespace ServicesAPI.Core.Entities
{
    public class Service
    {
        public Guid id { get; set; }
        public string serviceName { get; set; }
        public float price { get; set; }
        public string specializationName { get; set; }
        public ServiceCategory category { get; set; }
    }
}
