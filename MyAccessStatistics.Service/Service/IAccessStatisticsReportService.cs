using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyAccessStatistics.Model;


namespace MyAccessStatistics.Service
{


    /// <summary>
    /// 报表查询
    /// </summary>
    public interface IAccessStatisticsReportService
    {


        /// <summary>
        /// 取得访问汇总.
        /// </summary>
        /// <param name="accessTypeCode">访问类型代码</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="finishDate">结束日期</param>
        /// <returns></returns>
        List<AccessTypeSummary> GetAccessTypeSummary(string accessTypeCode = null, DateTime? startDate = null, DateTime? finishDate = null);




        /// <summary>
        /// 取得访问明细汇总.
        /// </summary>
        /// <param name="accessTypeCode">访问类型代码</param>
        /// <param name="accessDetailCode">访问明细代码</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="finishDate">结束日期</param>
        /// <returns></returns>
        List<AccessDetailSummary> GetAccessDetailSummary(string accessTypeCode = null, string accessDetailCode = null, DateTime? startDate = null, DateTime? finishDate = null);




        /// <summary>
        /// 取得访问明细日志.
        /// </summary>
        /// <param name="accessTypeCode">访问类型代码</param>
        /// <param name="accessDetailCode">访问明细代码</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="finishDate">结束日期</param>
        /// <param name="userID">用户代码</param>
        /// <returns></returns>
        List<AccessDetailLog> GetAccessDetailLog(string accessTypeCode = null, string accessDetailCode = null, DateTime? startDate = null, DateTime? finishDate = null, long? userID = null);





    }
}
