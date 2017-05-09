using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyUserMonitor.Model;
using MyUserMonitor.DataAccess;

using MyUserMonitor.Service;


namespace MyUserMonitor.ServiceImpl
{

    /// <summary>
    /// 用户信息写入 -- 数据库版本实现.
    /// </summary>
    public class DatabaseUserAccessInfoWriter : IUserAccessInfoWriter
    {

        /// <summary>
        /// 保存单个用户访问数据.
        /// </summary>
        /// <param name="data"></param>
        public void SaveUserAccessInfo(UserAccessInfo data)
        {
            using (MyUserMonitorContext context = new MyUserMonitorContext())
            {
                context.UserAccessInfos.Add(data);                
                context.SaveChanges();
            }
        }


        /// <summary>
        /// 保存用户访问数据列表.
        /// </summary>
        /// <param name="dataList"></param>
        public void SaveUserAccessInfoList(List<UserAccessInfo> dataList)
        {
            using (MyUserMonitorContext context = new MyUserMonitorContext())
            {
                foreach (var data in dataList)
                {
                    context.UserAccessInfos.Add(data);
                }                
                context.SaveChanges();
            }
        }

    }
}
