using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnoClinic.ServicesAPI.Core.Entities.Models
{
    public class Service
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Service Name is required field.")]
        [MaxLength(30, ErrorMessage = "Maximum lenght for the Service Name is 30 characters.")]
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
        [Required]
        public Guid SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
        [Required]
        public Guid ServiceCategoryId { get; set; }
        public ServiceCategory ServiceCategory { get; set; }
    }
}
