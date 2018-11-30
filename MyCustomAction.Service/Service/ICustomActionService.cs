using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyCustomAction.Model;


namespace MyCustomAction.Service
{

    /// <summary>
    /// 客户行为服务.
    /// </summary>
    public interface ICustomActionService
    {

        /// <summary>
        /// 新的行为
        /// </summary>
        /// <param name="customID">客户代码</param>
        /// <param name="moduleCode">模块代码</param>
        /// <param name="expData">附加数据</param>
        /// <returns></returns>
        long NewAction(long customID, string moduleCode, string expData);


        /// <summary>
        /// 后续的行为.
        /// </summary>
        /// <param name="actionID">行为ID.</param>
        /// <param name="customID">客户代码（数据检查时使用）</param>
        /// <param name="moduleCode">模块代码（数据检查时使用）</param>
        bool ContinueAction(long actionID, long customID, string moduleCode);



        /// <summary>
        /// 查询指定客户， 在指定的时间， 都做了哪些操作.
        /// </summary>
        /// <param name="customID"></param>
        /// <param name="fromTime"></param>
        /// <param name="toTime"></param>
        /// <returns></returns>
        List<CustomAction> QueryCustomAction(long? customID, DateTime? fromTime, DateTime? toTime);

    }

}
