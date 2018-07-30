using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAccessStatistics.Service
{


    /// <summary>
    /// 访问汇总服务.
    /// </summary>
    public interface IAccessStatisticsService
    {


        /// <summary>
        /// 新的访问.
        /// </summary>
        /// <param name="accessTypeCode">访问类型代码</param>
        /// <param name="accessDetailCode">访问明细代码</param>
        /// <param name="isSaveDetailLog">是否存储明细日志</param>
        /// <param name="userID">用户代码</param>
        /// <param name="resultMsg">返回消息</param>
        /// <returns></returns>
        bool NewAccess(string accessTypeCode, string accessDetailCode, bool isSaveDetailLog, long? userID,  ref string resultMsg);


    }


}
