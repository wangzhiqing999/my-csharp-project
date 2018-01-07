using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.Entity;
using System.Data.Entity.Migrations;

using MyDatabaseDoc.DataAccess;


namespace MyDatabaseDoc.DataAccess.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            // 当 Code First 与数据库结构不一致时
            // 自动升级到最新的版本.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyDatabaseDocContext, MyDatabaseDoc.Migrations.Configuration>());

            using (MyDatabaseDocContext context = new MyDatabaseDocContext())
            {
                var query =
                    from data in context.Tables
                    select data;

                foreach (var item in query)
                {
                    Console.WriteLine(item.TableName);
                }
            }

            Console.WriteLine("Finish!");
            Console.ReadLine();
        }
    }
}
