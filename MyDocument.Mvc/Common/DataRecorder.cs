using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MyFramework.Model;



namespace MyDocument.Mvc.Common
{
    public class DataRecorder
    {

        /// <summary>
        /// 数据插入前的处理.
        /// </summary>
        /// <param name="data"></param>
        public static void BeforeInsertOperation(HttpSessionStateBase session, AbstractCommonData data ) 
        {
            // 更新插入时间.
            data.BeforeInsertOperation();
        }




        /// <summary>
        /// 数据更新前的处理.
        /// </summary>
        /// <param name="data"></param>
        public static void BeforeUpdateOperation(HttpSessionStateBase session, AbstractCommonData data)
        {
            // 更新 最后修改时间.
            data.BeforeUpdateOperation();
        }


    }
}