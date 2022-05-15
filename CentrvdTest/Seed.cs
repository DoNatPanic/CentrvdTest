using CentrvdTest.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentrvdTest
{
	public static class Seed
	{
        public static async Task SeedData(DataContext context)
        {
            if (context.Departments.Any() || context.Employees.Any())
                return;

            var departments = new List<Department>
                {
                    new Department{ Id = 1, Name = "D1"},
                    new Department{ Id = 2, Name = "D2"},
                    new Department{ Id = 3, Name = "D3"},
                };


            var employees = new List<Employee>{
                new Employee
                {
                    Id = 1,
                    Department_id = 1,
                    chief_id = 5,
                    Name = "John",
                    Salary = 100
                },
                new Employee
                {
                    Id = 2,
                    Department_id = 1,
                    chief_id = 5,
                    Name = "Misha",
                    Salary = 600
                },
                 new Employee
                {
                    Id = 3,
                    Department_id = 2,
                    chief_id = 6,
                    Name = "Eugen",
                    Salary = 300
                },
                new Employee
                {
                    Id = 4,
                    Department_id = 2,
                    chief_id = 6,
                    Name = "Tolya",
                    Salary = 400
                },
                 new Employee
                {
                    Id = 5,
                    Department_id = 3,
                    chief_id = 7,
                    Name = "Stepan",
                    Salary = 500
                },
                new Employee
                {
                    Id = 6,
                    Department_id = 3,
                    chief_id = 7,
                    Name = "Alex",
                    Salary = 1000
                },
                 new Employee
                {
                    Id = 7,
                    Department_id = 3,
					chief_id = 0,
                    Name = "Ivan",
                    Salary = 1100
                },
            };

            await context.Departments.AddRangeAsync(departments);
            await context.Employees.AddRangeAsync(employees);
            await context.SaveChangesAsync();
        }
    }
}
