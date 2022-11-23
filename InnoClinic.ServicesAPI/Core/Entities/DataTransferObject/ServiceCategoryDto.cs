namespace ServicesAPI.Core.Entities.DataTransferObject
{
    public class ServiceCategoryDto
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public int TimeSlotSize { get; set; }
    }
}
