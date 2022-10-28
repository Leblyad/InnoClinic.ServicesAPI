namespace ServicesAPI.Core.Entities.DataTransferObject
{
    public abstract class ServiceForManipulationDto
    {
        public string ServiceName { get; set; }
        public float Price  { get; set; }
        public string SpecializationName { get; set; }
    }
}
