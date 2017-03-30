using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using System.Data.Entity;
using System.Data.Entity.Migrations;



using MySystemConfig.Model;
using MySystemConfig.DataAccess;


namespace MySystemConfig.DataAccess.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            // 当 Code First 与数据库结构不一致时
            // 自动升级到最新的版本.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MySystemConfigContext, MySystemConfig.Migrations.Configuration>());


            using (MySystemConfigContext context = new MySystemConfigContext())
            {
                var query =
                    from data in context.SystemConfigTypes
                    select data;

                foreach (var item in query)
                {
                    Console.WriteLine(item.ConfigTypeName);
                }
            }

            Console.WriteLine("Finish!");
            Console.ReadLine();
        }
    }
}
