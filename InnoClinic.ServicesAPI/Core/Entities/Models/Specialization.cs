using System.ComponentModel.DataAnnotations;

namespace InnoClinic.ServicesAPI.Core.Entities.Models
{
    public class Specialization
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
