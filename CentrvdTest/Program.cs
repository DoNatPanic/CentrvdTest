using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CentrvdTest
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            using (var context = new DataContext())
            {
                context.Database.Migrate();
                await Seed.SeedData(context);

                /*1*/
                Console.WriteLine("Суммарная зарплата в разрезе департаментов с руководителями и без:");
                var salariesWithoutChiefs = context.DepartmentSalarySum.FromSqlRaw(
                   "SELECT extTbl1.Id, Sum1, Sum2 FROM " +
                   "(SELECT Id, Sum1 FROM Departments " +
                   "LEFT JOIN " +
                   "(SELECT Department_id, SUM(Salary) AS Sum1 " +
                   "FROM Employees " +
                   "GROUP BY Department_id) AS innerTbl1 " +
                   "ON Departments.Id = innerTbl1.Department_id) AS extTbl1 " +
                   "LEFT JOIN " +
                   "(SELECT Id, Sum2 FROM Departments " +
                   "LEFT JOIN " +
                   "(SELECT Department_id, SUM(Salary) AS Sum2 " +
                   "FROM (SELECT * FROM Employees WHERE id NOT IN " +
                   "(SELECT DISTINCT chief_id FROM Employees)) " +
                   "GROUP BY Department_id) AS innerTbl2 " +
                   "ON Departments.Id = innerTbl2.Department_id) AS extTbl2 " +
                   "ON extTbl1.Id = extTbl2.Id")
                   .ToList();
                Console.WriteLine("Id\tSum1\tSum2");
                foreach (var s in salariesWithoutChiefs)
                {
                    if (s.Sum2 == null)
                        Console.WriteLine($"{s.Id}\t{s.Sum1}\t---");
                    else
                        Console.WriteLine($"{s.Id}\t{s.Sum1}\t{s.Sum2}");
                }

                /*2*/
                Console.WriteLine("\nДепартамент, в котором у сотрудника зарплата максимальна:");
                var maxSalaryDepartment = context.Employees.FromSqlRaw(
                    "SELECT * FROM Employees WHERE Salary = (SELECT MAX(Salary) FROM Employees)")
                    .ToList();
                Console.WriteLine("Id");
                foreach (var s in maxSalaryDepartment)
                    Console.WriteLine(s.Department_id);

                /*3*/
                Console.WriteLine("\nЗарплаты руководителей департаментов(по убыванию):");
                var chiefSalaries = context.ChiefSalaries.FromSqlRaw(
                    "SELECT * FROM Employees WHERE id IN (SELECT DISTINCT chief_id FROM Employees) ORDER BY Salary desc")
                    .ToList();
                Console.WriteLine("Chief salary");
                foreach (var s in chiefSalaries)
                    Console.WriteLine(s.Salary);

            }
            Console.ReadLine();
        }
    }
}
