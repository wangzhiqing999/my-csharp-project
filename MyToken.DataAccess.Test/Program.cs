using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using System.Data.Entity;
using System.Data.Entity.Migrations;



using MyToken.Model;
using MyToken.DataAccess;


namespace MyToken.DataAccess.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            // 当 Code First 与数据库结构不一致时
            // 自动升级到最新的版本.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyTokenContext, MyToken.Migrations.Configuration>());


            using (MyTokenContext context = new MyTokenContext())
            {
                var query =
                    from data in context.TokenTypes
                    select data;


                foreach (var item in query)
                {
                    Console.WriteLine(item);
                }

            }


            Console.WriteLine("Finish!");
            Console.ReadLine();
        }
    }
}
