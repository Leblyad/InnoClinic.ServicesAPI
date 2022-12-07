﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServicesAPI.Core.Entities.Models;

namespace ServicesAPI.Core.Entities.Configuration
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(service => service.Id);

            builder.HasData(new List<Service>()
            {
                new Service() { Id = new Guid("8c6d093c-c52c-4a9b-709b-08dac166520c"), Price = 100, ServiceName = "SomeName1", SpecializationName = "SpecName1",
                    ServiceCategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")},
                new Service() { Id = new Guid("24d92a89-a088-4687-9947-08dac62592e6"), Price = 90, ServiceName = "SomeName2", SpecializationName = "SpecName2",
                    ServiceCategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")},
                new Service() { Id = new Guid("3a31f073-c35d-4a5c-072f-08dad37b7a49"), Price = 80, ServiceName = "SomeName3", SpecializationName = "SpecName3",
                    ServiceCategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")},
                new Service() { Id = new Guid("d46f387f-86a2-4775-238b-08dad77cc06d"), Price = 70, ServiceName = "SomeName4", SpecializationName = "SpecName4",
                    ServiceCategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")},
                new Service() { Id = new Guid("0d6b7dc6-b351-4b72-ab6a-08dad78540c0"), Price = 60, ServiceName = "SomeName5", SpecializationName = "SpecName5",
                    ServiceCategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")}
            });
        }
    }
}