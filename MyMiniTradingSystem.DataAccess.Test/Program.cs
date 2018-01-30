using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.Migrations;

using MyMiniTradingSystem.DataAccess;



namespace MyMiniTradingSystem.DataAccess.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            // 当 Code First 与数据库结构不一致时
            // 自动升级到最新的版本.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyMiniTradingSystemContext, MyMiniTradingSystem.Migrations.Configuration>());


            using(MyMiniTradingSystemContext context = new MyMiniTradingSystemContext ())
            {
                var query =
                    from data in context.TradableCommoditys
                    select data;


                foreach(var item in query )
                {
                    Console.WriteLine(item.CommodityCode);
                }

                Console.WriteLine("Finish !!!");

                Console.ReadLine();
            }

        }
    }
}
