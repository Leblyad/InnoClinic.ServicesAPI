using System.ComponentModel.DataAnnotations;

namespace ServicesAPI.Core.Entities.DataTransferObject
{
    public abstract class ServiceForManipulationDto
    {
        [Required(ErrorMessage = "Service Name is required field.")]
        [MaxLength(30, ErrorMessage = "Maximum lenght for the Service Name is 30 characters.")]
        public string ServiceName { get; set; }

        public decimal Price { get; set; }

        [Required(ErrorMessage = "Specialization Name is required field.")]
        [MaxLength(30, ErrorMessage = "Maximum lenght for the Specialization Name is 30 characters.")]
        public string SpecializationName { get; set; }
    }
}
