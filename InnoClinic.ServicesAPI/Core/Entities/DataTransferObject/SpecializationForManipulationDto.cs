using System.ComponentModel.DataAnnotations;

namespace InnoClinic.ServicesAPI.Core.Entities.DataTransferObject
{
    public class SpecializationForManipulationDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
