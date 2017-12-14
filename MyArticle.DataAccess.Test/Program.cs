using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

using MyArticle.DataAccess;

namespace MyArticle.DataAccess.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            // 当 Code First 与数据库结构不一致时
            // 自动升级到最新的版本.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyArticleContext, MyArticle.Migrations.Configuration>());

            using (MyArticleContext context = new MyArticleContext())
            {
                var query =
                    from data in context.ArticleCategorys
                    select data;

                foreach (var item in query)
                {
                    Console.WriteLine(item.ArticleCategoryCode);
                }
            }

            Console.WriteLine("Finish!");
            Console.ReadKey();
        }
    }
}
