using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.Entity;
using System.Data.Entity.Migrations;



using MyMoney.Model;
using MyMoney.DataAccess;




namespace MyMoney.DataAccess.Test
{
    class Program
    {
        static void Main(string[] args)
        {


            // 当 Code First 与数据库结构不一致时
            // 自动升级到最新的版本.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyMoneyContext, MyMoney.Migrations.Configuration>());


            using (MyMoneyContext context = new MyMoneyContext())
            {
                var query =
                    from data in context.AccountOperationTypes
                    select data;

                foreach (var item in query)
                {
                    Console.WriteLine(item.OperationTypeName);
                }
            }

            Console.WriteLine("Finish!");
            Console.ReadLine();


        }
    }
}
