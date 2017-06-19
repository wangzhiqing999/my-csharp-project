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
        /// <param name="accessTypeCode"></param>
        /// <param name="accessDetailCode"></param>
        /// <param name="isSaveDetailLog"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        bool NewAccess(string accessTypeCode, string accessDetailCode, bool isSaveDetailLog, ref string resultMsg);

    }


}
