using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using MyDatabaseDoc.Service;
using MyDatabaseDoc.ServiceImpl;
using MyDatabaseDoc.Model;



using RazorEngine;
using RazorEngine.Templating;


namespace MyDatabaseDoc.Builder
{
    class DocBuilder
    {

        /// <summary>
        /// 数据库读取.
        /// </summary>
        private IDatabaseReader databaseReader = new MySqlDatabaseReader();


        /// <summary>
        /// 创建数据库表列表页.
        /// </summary>
        public void BuildAllPage()
        {
            // 表列表.
            List<Table> tableList = this.databaseReader.GetTableList();

            string tableTemplate = File.ReadAllText(@"Template\Index.cshtml", System.Text.Encoding.UTF8);
            Engine.Razor.AddTemplate("table", tableTemplate);

            string columnTemplate = File.ReadAllText(@"Template\Details.cshtml", System.Text.Encoding.UTF8);
            Engine.Razor.AddTemplate("column", columnTemplate);


            string tableHtml = Engine.Razor.RunCompile(
                name: "table", 
                modelType: typeof(List<Table>),
                model: tableList);

            if (!Directory.Exists("output"))
            {
                Directory.CreateDirectory("output");
            }
            File.WriteAllText(@"output\index.html", tableHtml);



            foreach (var oneTable in tableList)
            {
                List<Column> columnList = this.databaseReader.GetColumnList(oneTable.TableName);

                string columnHtml = Engine.Razor.RunCompile(
                    name: "column",
                    modelType: typeof(List<Column>),
                    model: columnList);

                string fileName = String.Format("output\\{0}.html", oneTable.TableName);

                File.WriteAllText(fileName, columnHtml);
            }
        }




    }
}
