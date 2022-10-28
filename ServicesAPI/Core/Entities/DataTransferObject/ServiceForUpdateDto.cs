namespace ServicesAPI.Core.Entities.DataTransferObject
{
    public class ServiceForUpdateDto : ServiceForManipulationDto
    {
        public Guid ServiceCategoryId { get; set; }
    }
}
