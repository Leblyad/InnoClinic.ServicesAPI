using InnoClinic.ServicesAPI.Core.Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace InnoClinic.ServicesAPI.Core.Entities.DataTransferObject
{
    public abstract class ServiceForManipulationDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Service Name is required field.")]
        [MaxLength(30, ErrorMessage = "Maximum lenght for the Service Name is 30 characters.")]
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
        [Required]
        public Guid SpecializationId { get; set; }
        [Required]
        public Guid ServiceCategoryId { get; set; }
    }
}
