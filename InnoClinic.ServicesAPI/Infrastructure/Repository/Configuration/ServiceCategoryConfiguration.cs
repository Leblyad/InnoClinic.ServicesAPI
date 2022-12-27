using InnoClinic.ServicesAPI.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnoClinic.ServicesAPI.Core.Entities.Configuration
{
    public class ServiceCategoryConfiguration : IEntityTypeConfiguration<ServiceCategory>
    {
        public void Configure(EntityTypeBuilder<ServiceCategory> builder)
        {
            builder.HasKey(serviceCategory => serviceCategory.Id);
            builder.HasData(new ServiceCategory
            {
                Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                CategoryName = "SomeCategoryName"
            });

        }
    }
}
