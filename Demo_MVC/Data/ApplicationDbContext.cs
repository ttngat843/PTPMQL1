using Demo_MVC.Models.Entities;
using Demo_MVC.Models.Process;
using Microsoft.EntityFrameworkCore;

namespace Demo_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<GenCode> GenCodes { get; set; }
    }
}
