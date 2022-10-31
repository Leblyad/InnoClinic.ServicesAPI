using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServicesAPI.Core.Entities.Models;

namespace ServicesAPI.Core.Entities.Configuration
{
    public class ServiceCategoryConfiguration : IEntityTypeConfiguration<ServiceCategory>
    {
        public void Configure(EntityTypeBuilder<ServiceCategory> builder)
        {
            builder.HasKey(serviceCategory => serviceCategory.Id);
            builder.HasData(new ServiceCategory
            {
                Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                CategoryName = "1"
            });

        }
    }
}
