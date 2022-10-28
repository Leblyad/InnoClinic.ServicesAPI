namespace ServicesAPI.Core.Entities
{
    public class ServiceCategory
    {
        public Guid id { get; set; }
        public string categoryName { get; set; }
        public TimeOnly timeSlotSize { get; set; }
    }
}
