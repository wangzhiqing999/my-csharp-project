using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.Entity;
using System.Data.Entity.Migrations;

using MyCustomAction.Model;
using MyCustomAction.DataAccess;



namespace MyCustomAction.DataAccess.Test
{
    class Program
    {
        static void Main(string[] args)
        {


            // 当 Code First 与数据库结构不一致时
            // 自动升级到最新的版本.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyCustomActionContext, MyCustomAction.Migrations.Configuration>());


            using (MyCustomActionContext context = new MyCustomActionContext())
            {
                var query =
                    from data in context.ServiceModules
                    select data;


                foreach (var item in query)
                {
                    Console.WriteLine(item.ModuleCode);
                }

            }


            Console.WriteLine("Finish!");
            Console.ReadLine();
        }
    }
}
