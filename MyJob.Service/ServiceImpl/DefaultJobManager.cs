using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



using log4net;

using MyFramework.ServiceModel;

using MyJob.Model;
using MyJob.DataAccess;
using MyJob.Service;


namespace MyJob.ServiceImpl
{

    /// <summary>
    /// 作业管理器.
    /// </summary>
    public class DefaultJobManager : IJobManager
    {

        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        /// <summary>
        /// 作业列表.
        /// </summary>
        private List<Job> jobList;



        /// <summary>
        /// 初始化所有的作业.
        /// </summary>
        private void InitAllJobs()
        {
            using (MyJobContext context = new MyJobContext())
            {
                var query =
                    from data in context.Jobs.Include("JobTypeData").Include("JobTimeList")
                    // 按下次运行时间排序.
                    orderby data.NextRunTime
                    select data;

                jobList = query.ToList();
            }
        }


        /// <summary>
        /// 服务线程.
        /// </summary>
        private Thread serviceThread;

        /// <summary>
        /// 线程停止运行的标志位.
        /// </summary>
        private bool done = false;



        /// <summary>
        /// 完成作业处理.
        /// </summary>
        public void DoJobProcess()
        {
            while (!done)
            {





            }
        }





        CommonServiceResult IJobManager.Start()
        {
            try
            {
                InitAllJobs();

                done = false;
                ThreadStart ts = new ThreadStart(DoJobProcess);
                serviceThread = new Thread(ts);

                // 启动.
                serviceThread.Start();

                return CommonServiceResult.DefaultSuccessResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                return new CommonServiceResult(ex);
            }

        }



        CommonServiceResult IJobManager.Stop()
        {
            try
            {
                done = true;

                // 休眠3秒，等待正在处理的操作完成.
                Thread.Sleep(3000);


                // 如果服务线程， 正在运行过程中的， 那么强制停止掉.
                if (serviceThread != null && serviceThread.IsAlive)
                {
                    serviceThread.Abort();
                }

                return CommonServiceResult.DefaultSuccessResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                return new CommonServiceResult(ex);
            }
        }




        JobFinishDelegate IJobManager.JobFinish
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }

}
