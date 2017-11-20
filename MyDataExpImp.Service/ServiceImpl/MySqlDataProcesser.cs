using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;
using MySql.Data.MySqlClient;



namespace MyDataExpImp.ServiceImpl
{

    public class MySqlDataProcesser : AbstractDataProcesser
    {


        /// <summary>
        /// 取得 数据库联接.
        /// </summary>
        /// <param name="connString"></param>
        /// <returns></returns>
        protected override IDbConnection GetDbConnection(string connString)
        {
            MySqlConnection conn = new MySqlConnection(connString);
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
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, (MySqlConnection)conn);
            return dataAdapter;
        }



        /// <summary>
        /// SqlCommandBuilder 设置 DataAdapter 对象的 InsertCommand、UpdateCommand 和 DeleteCommand 属性。
        /// </summary>
        /// <param name="adapter"></param>
        protected override void DoSqlCommandBuilder(IDbDataAdapter adapter)
        {
            MySqlCommandBuilder objCommandBuilder = new MySqlCommandBuilder((MySqlDataAdapter)adapter);
        }
    }

}
