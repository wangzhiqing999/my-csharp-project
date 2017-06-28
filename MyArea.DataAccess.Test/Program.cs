using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml;
using System.Xml.Serialization;


using System.Data.Entity;
using System.Data.Entity.Migrations;


using MyArea.Model;


namespace MyArea.DataAccess.Test
{
    class Program
    {
        static void Main(string[] args)
        {


            // 当 Code First 与数据库结构不一致时
            // 自动升级到最新的版本.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyAreaContext, MyArea.Migrations.Configuration>());


            List<AreaInfo> dataList = new List<AreaInfo>();

            using (MyAreaContext context = new MyAreaContext())
            {
                var query =
                    from data in context.AreaInfos
                    select data;

                foreach (var item in query)
                {
                    Console.WriteLine(item.AreaName);
                    dataList.Add(new AreaInfo() { AreaCode = item.AreaCode, ParentAreaCode = item.ParentAreaCode, AreaName = item.AreaName});
                }
            }


            // 输出 UTF-8 的 XML 文件.
            XmlSerializer xs = new XmlSerializer(typeof(List<AreaInfo>));
            using (StreamWriter sw = new StreamWriter("AreaInfo.xml"))
            {
                xs.Serialize(sw, dataList);
            }            

            Console.WriteLine("Finish!");
            Console.ReadLine();

        }
    }
}
