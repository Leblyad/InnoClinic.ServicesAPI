using Microsoft.EntityFrameworkCore;
using ServicesAPI.Core.Entities.Configuration;
using ServicesAPI.Core.Entities.Models;

namespace ServicesAPI.Infrastructure.Repository
{
    public class RepositoryContext : DbContext
    {
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceCategory> ServiceCategories { get; set; }

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

            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceCategoryConfiguration());
        }
    }
}
