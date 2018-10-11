using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.Entity;
using System.Data.Entity.Migrations;


namespace MyJob.DataAccess.Test
{
    class Program
    {
        static void Main(string[] args)
        {


            // 当 Code First 与数据库结构不一致时
            // 自动升级到最新的版本.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyJobContext, MyJob.Migrations.Configuration>());



            using (MyJobContext context = new MyJobContext())
            {
                var query =
                    from data in context.JobTypes
                    select data;

                foreach (var item in query)
                {
                    Console.WriteLine(item.JobTypeName);
                }
            }


            Console.WriteLine("Finish!");
            Console.ReadKey();
        }
    }
}
