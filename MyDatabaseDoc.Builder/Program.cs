using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MyDatabaseDoc.Builder
{
    class Program
    {
        static void Main(string[] args)
        {

            // 当 Code First 与数据库结构不一致时， 忽略.
            Database.SetInitializer(new NullDatabaseInitializer<MyDatabaseDoc.DataAccess.MyDatabaseDocContext>());


            DocBuilder docBuilder = new DocBuilder();
            docBuilder.BuildAllPage();

            Console.WriteLine("Finish!");
        }
    }
}
