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
        /// <param name="accessTypeCode"></param>
        /// <param name="startDate"></param>
        /// <param name="finishDate"></param>
        /// <returns></returns>
        List<AccessTypeSummary> GetAccessTypeSummary(string accessTypeCode = null, DateTime? startDate = null, DateTime? finishDate = null);




        /// <summary>
        /// 取得访问明细汇总.
        /// </summary>
        /// <param name="accessTypeCode"></param>
        /// <param name="accessDetailCode"></param>
        /// <param name="startDate"></param>
        /// <param name="finishDate"></param>
        /// <returns></returns>
        List<AccessDetailSummary> GetAccessDetailSummary(string accessTypeCode = null, string accessDetailCode = null, DateTime? startDate = null, DateTime? finishDate = null);




        /// <summary>
        /// 取得访问明细日志.
        /// </summary>
        /// <param name="accessTypeCode"></param>
        /// <param name="accessDetailCode"></param>
        /// <param name="startDate"></param>
        /// <param name="finishDate"></param>
        /// <returns></returns>
        List<AccessDetailLog> GetAccessDetailLog(string accessTypeCode = null, string accessDetailCode = null, DateTime? startDate = null, DateTime? finishDate = null);

    }
}
