using Demo_MVC.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Demo_MVC.Models.Process;

namespace Demo_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        

        // Khai báo DbSet cho các bảng
        public DbSet<Person> Persons { get; set; }
        public DbSet<GenCode> GenCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Map entity Person vào bảng "Person" (không bị EF tự động đổi thành Persons)
            modelBuilder.Entity<Person>().ToTable("Person");
            
            modelBuilder.Entity<GenCode>().ToTable("GenCode");
        }
    }
}
