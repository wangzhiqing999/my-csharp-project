using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using MyFinanceCalendar.Model;



namespace MyFinanceCalendar.Service
{
    public interface IFinanceDataReader
    {
        
        /// <summary>
        /// 查询指定日期的财经日历数据.
        /// </summary>
        /// <param name="myDate"></param>
        /// <returns></returns>
        List<FinanceData> ReadFinanceDataInfo(DateTime myDate);
    }
}
