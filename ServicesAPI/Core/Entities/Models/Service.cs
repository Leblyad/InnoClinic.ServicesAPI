using System.ComponentModel.DataAnnotations;

namespace ServicesAPI.Core.Entities.Models
{
    public class Service
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Service Name is required field.")]
        [MaxLength(30, ErrorMessage = "Maximum lenght for the Service Name is 30 characters.")]
        public string ServiceName { get; set; }

        public decimal Price { get; set; }

        [Required(ErrorMessage = "Specialization Name is required field.")]
        [MaxLength(30, ErrorMessage = "Maximum lenght for the Specialization Name is 30 characters.")]
        public string SpecializationName { get; set; }

        [Required(ErrorMessage = "Service Category Id is required field.")]
        public Guid ServiceCategoryId { get; set; }
        public ServiceCategory ServiceCategory { get; set; }
    }
}
