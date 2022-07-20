using Microsoft.EntityFrameworkCore;
using WebAPICRUD1.Models;

namespace WebAPICRUD1
{
    public class ApplicationDbContext : DbContext
    {
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
                
        }



        public DbSet<Employee> Employees { get; set; }

    }

    
}
