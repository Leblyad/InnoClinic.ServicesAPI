namespace InnoClinic.ServicesAPI.Core.Entities.DataTransferObject
{
    public class ServiceForCreationDto : ServiceForManipulationDto
    {
        public Guid ServiceCategoryId { get; set; }
    }
}
