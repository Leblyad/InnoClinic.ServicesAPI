using ServicesAPI.Core.Entities.Models;

namespace ServicesAPI.Core.Entities.DataTransferObject
{
    public class ServiceCategoryDto
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public TimeOnly TimeSlotSize { get; set; }
    }
}
