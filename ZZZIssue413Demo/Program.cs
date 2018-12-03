using System;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace ZZZIssue413Demo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Try update");
            try
            {
                using (var dbContext = new DbContext())
                {
                    await dbContext.Database.EnsureCreatedAsync();
                    
                    Console.WriteLine("Update with constant value");
                    await dbContext.Models.Where(m => m.Test == TestEnum.Foo)
                        .UpdateAsync(m => new Model {Test2 = TestEnum.Foo});
                    
                    Console.WriteLine("Update with value from variable");
                    var bar = TestEnum.Bar;
                    await dbContext.Models.Where(m => m.Test == bar)
                        .UpdateAsync(m => new Model {Test2 = TestEnum.Foo}); // exception
                    
                    await dbContext.Database.EnsureDeletedAsync();
                    Console.WriteLine("Success");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}