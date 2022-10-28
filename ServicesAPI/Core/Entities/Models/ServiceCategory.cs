namespace ServicesAPI.Core.Entities.Models
{
    public class ServiceCategory
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public TimeOnly TimeSlotSize { get; set; }
    }
}
