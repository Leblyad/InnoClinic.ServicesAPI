using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InnoClinic.ServicesAPI.Core.Entities.Models;

namespace InnoClinic.ServicesAPI.Core.Entities.Configuration
{
    public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
    {
        public void Configure(EntityTypeBuilder<Specialization> builder)
        {
            builder.HasKey(service => service.Id);

            builder.HasData(new List<Specialization>()
            {
                new Specialization() { Id = new Guid("acc08d75-50ea-4689-84cc-bc4b41138301"), Name = "SpecName1", Status = true}
            });
        }
    }
}
