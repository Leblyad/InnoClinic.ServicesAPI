using System.ComponentModel.DataAnnotations;

namespace InnoClinic.ServicesAPI.Core.Entities.DataTransferObject
{
    public class SpecializationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
