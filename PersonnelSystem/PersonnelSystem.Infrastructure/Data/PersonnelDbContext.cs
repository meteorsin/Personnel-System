using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelSystem.Core.Entities;

namespace PersonnelSystem.Infrastructure.Data
{
    public class PersonnelDbContext : DbContext
    {
        public PersonnelDbContext(DbContextOptions<PersonnelDbContext> options) : base(options)
        {
                
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(ConfigureEmployee);
            modelBuilder.Entity<Role>(ConfigureRole);
        }

        private void ConfigureEmployee(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.Property(t => t.LastName).HasMaxLength(50);
            builder.Property(t => t.FirstName).HasMaxLength(50);
            builder.Property(t => t.Roles).HasMaxLength(50);
        }

        private void ConfigureRole(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.Property(t => t.RoleName).HasMaxLength(50);
        }
    }
}
