using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;
using System.Data.OleDb;


namespace MyDataExpImp.ServiceImpl
{
    public class OleDbDataProcesser : AbstractDataProcesser
    {

        /// <summary>
        /// 取得 数据库联接.
        /// </summary>
        /// <param name="connString"></param>
        /// <returns></returns>
        protected override IDbConnection GetDbConnection(string connString)
        {
            OleDbConnection conn = new OleDbConnection(connString);
            return conn;
        }



        /// <summary>
        /// 取得 适配器
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        protected override IDbDataAdapter GetDbDataAdapter(string sql, IDbConnection conn)
        {
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, (OleDbConnection)conn);
            return dataAdapter;
        }



        /// <summary>
        /// SqlCommandBuilder 设置 DataAdapter 对象的 InsertCommand、UpdateCommand 和 DeleteCommand 属性。
        /// </summary>
        /// <param name="adapter"></param>
        protected override void DoSqlCommandBuilder(IDbDataAdapter adapter)
        {
            OleDbCommandBuilder objCommandBuilder = new OleDbCommandBuilder((OleDbDataAdapter)adapter);
        }

    }
}
