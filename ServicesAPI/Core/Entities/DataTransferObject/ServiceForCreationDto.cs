namespace ServicesAPI.Core.Entities.DataTransferObject
{
    public class ServiceForCreationDto
    {
        public string ServiceName { get; set; }
        public float Price { get; set; }
        public string SpecializationName { get; set; }
        public ServiceCategoryDto Category { get; set; }
    }
}
