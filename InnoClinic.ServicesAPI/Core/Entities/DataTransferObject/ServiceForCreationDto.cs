using System.ComponentModel.DataAnnotations;

namespace InnoClinic.ServicesAPI.Application.Entities.DataTransferObject
{
    public class ServiceForCreationDto
    {
        [Required(ErrorMessage = "Service Name is required field.")]
        [MaxLength(30, ErrorMessage = "Maximum lenght for the Service Name is 30 characters.")]
        public string Name { get; set; }
        public decimal Price { get; set; }
        [Required]
        public Guid SpecializationId { get; set; }
        [Required]
        public Guid ServiceCategoryId { get; set; }
    }
}
