using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data.Entity;
using System.Data.Entity.Migrations;


namespace MyBallot.DataAccess.Test
{
    class Program
    {
        static void Main(string[] args)
        {


            // 当 Code First 与数据库结构不一致时
            // 自动升级到最新的版本.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyBallotContext, MyBallot.Migrations.Configuration>());


            using (MyBallotContext context = new MyBallotContext())
            {
                var query =
                    from data in context.BallotTypes
                    select data;


                foreach (var item in query)
                {
                    Console.WriteLine(item.BallotTypeCode);
                }

            }

            Console.WriteLine("Finish!");
            Console.ReadLine();


        }
    }
}
