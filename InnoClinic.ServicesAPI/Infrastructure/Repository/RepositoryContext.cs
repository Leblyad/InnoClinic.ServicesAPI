using Microsoft.EntityFrameworkCore;
using InnoClinic.ServicesAPI.Core.Entities.Configuration;
using InnoClinic.ServicesAPI.Core.Entities.Models;

namespace InnoClinic.ServicesAPI.Infrastructure.Repository
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<Specialization> Specializations { get; set; }

        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public RepositoryContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new SpecializationConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
        }
    }
}
