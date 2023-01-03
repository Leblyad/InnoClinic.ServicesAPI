using System.ComponentModel.DataAnnotations;

namespace InnoClinic.ServicesAPI.Application.Entities.DataTransferObject
{
    public class ServiceForUpdateDto
    {
        [Required]
        public string ServiceName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public Guid ServiceCategoryId { get; set; }
        [Required]
        public Guid SpecializationId { get; set; }
    }
}
