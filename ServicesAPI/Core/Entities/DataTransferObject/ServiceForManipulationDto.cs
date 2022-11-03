namespace ServicesAPI.Core.Entities.DataTransferObject
{
    public abstract class ServiceForManipulationDto
    {
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
        public string SpecializationName { get; set; }
    }
}
