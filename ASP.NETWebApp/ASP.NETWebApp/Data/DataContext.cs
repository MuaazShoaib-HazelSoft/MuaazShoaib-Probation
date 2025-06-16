using ASP.NETWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETWebApp.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base (options)
        {
            
        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>(entity =>
            {
                entity.HasKey(e =>  e.Id);

                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(20);

                entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(e => e.Type)
                .IsRequired();

                entity.HasIndex(e => e.Name).IsUnique();
            });
        }
    }
}
