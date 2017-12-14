using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

using MyBanner.DataAccess;


namespace MyBanner.DataAccess.Test
{
    class Program
    {
        static void Main(string[] args)
        {


            // 当 Code First 与数据库结构不一致时
            // 自动升级到最新的版本.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyBannerContext, MyBanner.Migrations.Configuration>());

            using (MyBannerContext context = new MyBannerContext())
            {
                var query =
                    from data in context.BannerTypes
                    select data;

                foreach (var item in query)
                {
                    Console.WriteLine(item.BannerTypeCode);
                }
            }

            Console.WriteLine("Finish!");
            Console.ReadKey();

        }
    }
}
