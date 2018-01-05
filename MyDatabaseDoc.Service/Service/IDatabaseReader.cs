using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyDatabaseDoc.Model;


namespace MyDatabaseDoc.Service
{
    public interface IDatabaseReader
    {

        /// <summary>
        /// 获取表.
        /// </summary>
        /// <returns></returns>
        List<Table> GetTableList();



        /// <summary>
        /// 获取列.
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        List<Column> GetColumnList(string tableName);

    }
}
