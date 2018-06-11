using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.Migrations;


namespace MyHelp.DataAccess.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            // 当 Code First 与数据库结构不一致时
            // 自动升级到最新的版本.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyHelpContext, MyHelp.Migrations.Configuration>());

            using (MyHelpContext context = new MyHelpContext())
            {
                var query =
                    from data in context.HelpKeywords
                    select data;

                foreach (var item in query.Take(3))
                {
                    Console.WriteLine(item.KeywordText);
                }
            }

            Console.WriteLine("Finish!");
            Console.ReadLine();
        }
    }
}
