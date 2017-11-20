using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using MyDataExpImp.Service;
using MyDataExpImp.ServiceImpl;


namespace MyDataExpImp.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length != 3)
            {
                ShowHelp();
                return;
            }



            MyDataExpImp.Cmd.Properties.Settings config = MyDataExpImp.Cmd.Properties.Settings.Default;

            
            IDataProcesser dataProcesser = null;


            switch (args[0].ToUpper())
            {
                case "MYSQL":
                    dataProcesser = new MySqlDataProcesser()
                    {
                        ConnString = config.MySqlConnString
                    };
                    break;

                case "SQL":
                    dataProcesser = new SqlDataProcesser()
                    {
                        ConnString = config.SqlConnString
                    };
                    break;

                case "OLEDB":
                    dataProcesser = new OleDbDataProcesser()
                    {
                        ConnString = config.OleDbConnString
                    };
                    break;

                case "ODBC":
                    dataProcesser = new OdbcDataProcesser()
                    {
                        ConnString = config.OdbcConnString
                    };
                    break;

                case "ORACLE":
                    dataProcesser = new OracleDataProcesser()
                    {
                        ConnString = config.OracleConnString
                    };
                    break;

                default:
                    Console.WriteLine("暂时不支持的数据库名：{0}", args[0]);
                    ShowHelp();
                    return;
            }






            char[] divChar = { ',',  ';' };
            string[] tableNameArray = args[2].Split(divChar);

            foreach (string tableName in tableNameArray)
            {
                string realTableName = tableName.Trim();
                if (!String.IsNullOrEmpty(realTableName))
                {
                    if (args[1].Equals("exp", StringComparison.CurrentCultureIgnoreCase))
                    {
                        dataProcesser.DoExp(realTableName);
                    }
                    else if (args[1].Equals("imp", StringComparison.CurrentCultureIgnoreCase))
                    {
                        dataProcesser.DoImp(realTableName);
                    }
                    else
                    {
                        Console.WriteLine("命令格式不正确！!");
                        ShowHelp();
                        return;
                    }
                }
            }
        }




        static void ShowHelp()
        {

            Console.WriteLine("调用方式.");
            Console.WriteLine("MyDataExpImp.Cmd.exe 数据库类型  导入/导出标志 表名称");


            Console.WriteLine("例如：");
            Console.WriteLine("MySQL exp tablename");
            Console.WriteLine("  从 MySQL 导出 tablename");

            Console.WriteLine("SQL imp tablename");
            Console.WriteLine("  将 tablename 导入到 SQL Server 当中.");


            Console.WriteLine("按回车键结束.");

            Console.ReadLine();

        }


    }
}
