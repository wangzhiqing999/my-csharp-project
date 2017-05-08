using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using log4net;


using MyUserMonitor.Model;
using MyUserMonitor.DataAccess;

using MyUserMonitor.Service;


namespace MyUserMonitor.ServiceImpl
{

    /// <summary>
    /// 默认的用户监测服务.
    /// </summary>
    public class DefaultUserMonitorService : IUserMonitorService
    {

        #region 单例的相关代码.

        /// <summary>
        /// 静态单例.
        /// </summary>
        private static DefaultUserMonitorService me = new DefaultUserMonitorService();


        /// <summary>
        /// 私有构造函数.
        /// </summary>
        private DefaultUserMonitorService()
        {

        }


        /// <summary>
        /// 获取实例.
        /// </summary>
        /// <returns></returns>
        public static DefaultUserMonitorService GetUserMonitorService()
        {
            return me;
        }



        #endregion 单例的相关代码.




        






        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        /// <summary>
        /// 用户访问数据列表.
        /// </summary>
        public List<UserAccessInfo> userAccessDataList = new List<UserAccessInfo>();



        /// <summary>
        /// 超时设置.
        /// </summary>
        private int timeout = 300;


        /// <summary>
        /// 超时（单位：秒）
        /// </summary>
        public int Timeout {
            set
            {
                timeout = value;
            }
            get
            {
                return timeout;
            }
        }



        /// <summary>
        /// 是否保存日志到数据库.
        /// </summary>
        public bool IsSaveLogToDatabase { set; get; }




        /// <summary>
        /// 用户访问.
        /// </summary>
        /// <param name="groupCode"></param>
        /// <param name="userName"></param>
        public void UserAccess(string groupCode, string userName)
        {

            var query =
                from data in this.userAccessDataList
                where
                    data.GroupCode == groupCode
                    && data.UserName == userName
                select
                    data;

            var userAccessInfo = query.FirstOrDefault();

            if (userAccessInfo == null)
            {
                lock (this.userAccessDataList)
                {
                    // 首次访问.
                    userAccessInfo = new UserAccessInfo()
                    {
                        GroupCode = groupCode,
                        UserName = userName,
                        AccessCount = 0,
                        EnterTime = DateTime.Now,
                    };

                    this.userAccessDataList.Add(userAccessInfo);
                }
            }

            // 共通处理.
            userAccessInfo.LastAccessTime = DateTime.Now;
            userAccessInfo.AccessCount++;

            // 处理完成.

        }




        /// <summary>
        /// 获取当前用户列表.
        /// </summary>
        /// <returns></returns>
        public List<UserAccessInfo> GetCurrentUserList()
        {
            return this.userAccessDataList.ToList();
        }









        #region 线程处理相关代码.



        /// <summary>
        /// 超时线程运行模式.
        /// </summary>
        private bool timeoutRunning;


        /// <summary>
        /// 开始线程处理.
        /// </summary>
        public void StartTimeoutClean()
        {
            timeoutRunning = true;

            ThreadStart ts = new ThreadStart(this.TimeoutClean);
            Thread t = new Thread(ts);
            t.Start();
        }


        // 结束线程处理.
        public void StopTimeoutClean()
        {
            timeoutRunning = false;
        }



        /// <summary>
        /// 超时清除处理.
        /// </summary>
        protected virtual void TimeoutClean() 
        {
            while (timeoutRunning)
            {
                try
                {
                    // 查询超时的数据.
                    var removeQuery =
                            from data in this.userAccessDataList
                            where
                                data.LastAccessTime.AddSeconds(this.timeout) < DateTime.Now
                            select
                                data;
                    var removeList = removeQuery.ToList();


                    // 从列表中删除.
                    if (removeList.Count > 0)
                    {
                        lock (this.userAccessDataList)
                        {
                            foreach (var item in removeList)
                            {
                                this.userAccessDataList.Remove(item);
                            }
                        }


                        if (this.IsSaveLogToDatabase)
                        {
                            // 超时的数据，存储到数据库.
                            using (MyUserMonitorContext context = new MyUserMonitorContext())
                            {
                                foreach (var item in removeList)
                                {
                                    context.UserAccessInfos.Add(item);
                                }
                                context.SaveChanges();
                            }
                        }

                    }

                    

                    
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message, ex);
                }


                Thread.Sleep(this.timeout);
            }
        }




        #endregion 线程处理相关代码.



    }


}
