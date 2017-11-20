using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;


using MyDataExpImp.Service;

namespace MyDataExpImp.ServiceImpl
{


    /// <summary>
    /// 抽象数据处理.
    /// </summary>
    public abstract class AbstractDataProcesser : IDataProcesser
    {


        /// <summary>
        /// 数据库联接字符串.
        /// </summary>
        public string ConnString { set; get; }



        /// <summary>
        /// 取得查询表的 SQL 语句.
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        protected string GetExpSql(string tableName)
        {
            return String.Format("SELECT * FROM {0}", tableName);
        }



        /// <summary>
        /// 取得 XmlSchema 文件名.
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        protected string GetXmlSchema(string tableName)
        {
            return String.Format("{0}_Schema.xml", tableName);
        }



        /// <summary>
        ///  取得 Xml 文件名.
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        protected string GetXml(string tableName)
        {
            return String.Format("{0}.xml", tableName);
        }



        /// <summary>
        /// 取得 数据库联接.
        /// </summary>
        /// <param name="connString"></param>
        /// <returns></returns>
        protected abstract IDbConnection GetDbConnection(string connString);



        /// <summary>
        /// 取得 适配器
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        protected abstract IDbDataAdapter GetDbDataAdapter(string sql, IDbConnection conn);




        /// <summary>
        /// SqlCommandBuilder 设置 DataAdapter 对象的 InsertCommand、UpdateCommand 和 DeleteCommand 属性。
        /// </summary>
        /// <param name="adapter"></param>
        protected abstract void DoSqlCommandBuilder(IDbDataAdapter adapter);




        /// <summary>
        /// 数据导出.
        /// </summary>
        /// <param name="tableName"></param>
        public void DoExp(string tableName)
        {
            using (IDbConnection conn = GetDbConnection(ConnString))
            {
                // 创建一个适配器
                IDbDataAdapter adapter = GetDbDataAdapter(GetExpSql(tableName), conn);

                // 创建DataSet，用于存储数据.
                DataSet resultDataSet = new DataSet();

                // 执行查询，并将数据导入DataSet.
                adapter.Fill(resultDataSet);

                Console.WriteLine("将 DataTable 的数据，写入到 XML 文件中。");
                resultDataSet.Tables[0].WriteXmlSchema(GetXmlSchema(tableName));
                resultDataSet.Tables[0].WriteXml(GetXml(tableName));
                Console.WriteLine("处理完毕！");
            }
        }






        /// <summary>
        /// 数据导入.
        /// </summary>
        /// <param name="tableName"></param>
        public void DoImp(string tableName)
        {
            Console.WriteLine("从 XML 文件中，读取数据到 DataTable 里面。");
            DataTable dtXml = new DataTable();
            dtXml.ReadXmlSchema(GetXmlSchema(tableName));
            dtXml.ReadXml(GetXml(tableName));


            using (IDbConnection conn = GetDbConnection(ConnString))
            {
                // 创建一个适配器
                IDbDataAdapter adapter = GetDbDataAdapter(GetExpSql(tableName), conn);

                // 创建DataSet，用于存储数据.
                DataSet resultDataSet = new DataSet();

                // 表结构定义导入DataSet.
                adapter.FillSchema(resultDataSet, SchemaType.Source);
                // 数据导入DataSet.
                adapter.Fill(resultDataSet);


                // 这些数据此时作为 DataSet 的 Tables 集合内独立的 DataTable 对象来提供。
                // 如果在对 FillSchema 和 Fill 的调用中指定了一个表名，
                // 则可以使用该名称访问您需要的特定表。 
                DataTable dtDatabase = resultDataSet.Tables[0];



                Console.WriteLine("将数据写入到数据库中...");

                // 遍历 xml 文件中的每一行.
                foreach (DataRow xmlRow in dtXml.Rows)
                {
                    // 从 DataTable 获取新的 DataRow 对象。
                    DataRow drCurrent = dtDatabase.NewRow();
                    
                    // 每一列依次赋值.
                    for (int i = 0; i < dtDatabase.Columns.Count; i++)
                    {
                        // 取得列名.
                        string colName = dtDatabase.Columns[i].ColumnName;
                        // 赋值.
                        drCurrent[colName] = xmlRow[colName];
                    }

                    // 将新的对象传递给 DataTable.Rows 集合的 Add 方法。
                    dtDatabase.Rows.Add(drCurrent);
                }


                // 通过 SqlCommandBuilder 设置 DataAdapter 对象的 InsertCommand、UpdateCommand 和 DeleteCommand 属性。
                // 注意：表必须有主键信息
                DoSqlCommandBuilder(adapter);


                // 更新原始数据库，可将 DataSet 传递到 DataAdapter 对象的 Update 方法。
                adapter.Update(resultDataSet);


            }

            Console.WriteLine("处理完毕！");
        }

    }

}
