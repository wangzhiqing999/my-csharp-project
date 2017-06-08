using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.Entity;
using System.Data.Entity.Migrations;


namespace MyDocument.DataAccess.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            // 当 Code First 与数据库结构不一致时
            // 自动升级到最新的版本.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyDocumentContext, MyDocument.Migrations.Configuration>());


            using (MyDocumentContext context = new MyDocumentContext())
            {
                var query =
                    from data in context.DocumentTypes
                    select data;


                foreach (var item in query)
                {
                    Console.WriteLine(item.DocumentTypeName);
                }

            }

            Console.WriteLine("Finish!");
            Console.ReadLine();
        }
    }
}
