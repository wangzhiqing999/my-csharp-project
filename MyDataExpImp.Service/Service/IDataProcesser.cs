using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyDataExpImp.Service
{
    public interface IDataProcesser
    {
        /// <summary>
        /// 数据库联接字符串.
        /// </summary>
        string ConnString { set; get; }



        /// <summary>
        /// 数据导出.
        /// </summary>
        /// <param name="tableName"></param>
        void DoExp(string tableName);



        /// <summary>
        /// 数据导入.
        /// </summary>
        /// <param name="tableName"></param>
        void DoImp(string tableName);
    }
}
