using CentrvdTest.Models;
using Microsoft.EntityFrameworkCore;

namespace CentrvdTest
{
    public class DataContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<DepartmentSalarySum> DepartmentSalarySum { get; set; }
        public DbSet<ChiefSalary> ChiefSalaries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=centrvd.db");
        }
    }
}
