using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.Migrations;



using MyExamination.Model;
using MyExamination.DataAccess;


namespace MyExamination.DataAccess.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // 当 Code First 与数据库结构不一致时
            // 自动升级到最新的版本.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyExaminationContext, MyExamination.Migrations.Configuration>());


            using (MyExaminationContext context = new MyExaminationContext())
            {
                var query =
                    from data in context.Examinations
                    select data;

                foreach (var item in query)
                {
                    Console.WriteLine("{0} : {1}", item.ExaminationID, item.ExaminationName);
                }
            }


            Console.WriteLine("Finish!");
            Console.ReadLine();
        }
    }
}
