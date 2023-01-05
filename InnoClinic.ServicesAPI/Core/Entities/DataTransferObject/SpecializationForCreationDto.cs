using System.ComponentModel.DataAnnotations;

namespace InnoClinic.ServicesAPI.Application.Entities.DataTransferObject
{
    public class SpecializationForCreationDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
