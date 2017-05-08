using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MyUserMonitor.Model;


namespace MyUserMonitor.Service
{

    /// <summary>
    /// 用户监测服务.
    /// </summary>
    public interface IUserMonitorService
    {

        /// <summary>
        /// 用户访问.
        /// </summary>
        /// <param name="groupCode"></param>
        /// <param name="userName"></param>
        void UserAccess(string groupCode, string userName);




        /// <summary>
        /// 获取当前用户列表.
        /// </summary>
        /// <returns></returns>
        List<UserAccessInfo> GetCurrentUserList();


    }
}
