using EmployeeManager.Models;
using EmployeeManager.Controllers;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Data_Acees
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<SalaryRange> SalaryRanges { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql("host=localhost ;port=5432; Database=Employee Manager; username=postgres; password=MUNIA&12 ;IncludeErrorDetail=true;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>().ToTable("Employees");
        }

    }
}