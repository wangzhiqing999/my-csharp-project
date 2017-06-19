using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.Migrations;

using MyAccessStatistics.DataAccess;
using MyAccessStatistics.Model;


namespace MyAccessStatistics.DataAccess.Test
{


    class Program
    {
        static void Main(string[] args)
        {


            // 当 Code First 与数据库结构不一致时
            // 自动升级到最新的版本.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyAccessStatisticsContext, MyAccessStatistics.Migrations.Configuration>());



            using (MyAccessStatisticsContext context = new MyAccessStatisticsContext())
            {
                var query =
                    from data in context.AccessTypes
                    select data;

                foreach (var item in query)
                {
                    Console.WriteLine(item.AccessTypeCode);
                }
            }

            Console.WriteLine("Finish!");
            Console.ReadLine();
        }

    }


}
