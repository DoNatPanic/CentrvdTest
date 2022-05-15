using System;
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

                Console.WriteLine("Суммарная зарплата в разрезе департаментов(без руководителей и с руководителями)");
                //TODO

                Console.WriteLine("Департамент, в котором у сотрудника зарплата максимальна");
                //TODO

                Console.WriteLine("Зарплаты руководителей департаментов(по убыванию)");
                //TODO

            }
            Console.ReadLine();
        }
    }
}
