using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyUserMonitor.Model;


namespace MyUserMonitor.Service
{

    /// <summary>
    /// 用户信息写入.
    /// </summary>
    public interface IUserAccessInfoWriter
    {

        /// <summary>
        /// 保存单个用户访问数据.
        /// </summary>
        /// <param name="data"></param>
        void SaveUserAccessInfo(UserAccessInfo data);


        /// <summary>
        /// 保存用户访问数据列表.
        /// </summary>
        /// <param name="dataList"></param>
        void SaveUserAccessInfoList(List<UserAccessInfo> dataList);

    }


}
