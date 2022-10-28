namespace ServicesAPI.Core.Entities.DataTransferObject
{
    public abstract class ServiceCategoryForManipulationDto
    {
        public string CategoryName { get; set; }
        public TimeOnly TimeSlotSize { get; set; }
    }
}
