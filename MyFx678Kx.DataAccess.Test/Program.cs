using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

using MyFx678Kx.DataAccess;

namespace MyFx678Kx.DataAccess.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            // 当 Code First 与数据库结构不一致时
            // 自动升级到最新的版本.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyFx678KxContext, MyFx678Kx.Migrations.Configuration>());

            using (MyFx678KxContext context = new MyFx678KxContext())
            {
                var query =
                    from data in context.Fx678Kxs
                    select data;

                foreach (var item in query.Take(3))
                {
                    Console.WriteLine(item.Title);
                }
            }

            Console.WriteLine("Finish!");
            Console.ReadKey();
        }
    }
}
