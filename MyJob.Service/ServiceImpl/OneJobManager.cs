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
using MyJob.Factory;


namespace MyJob.ServiceImpl
{

    /// <summary>
    /// 单一作业管理.
    /// </summary>
    public class OneJobManager : IJobManager
    {
        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 管理的作业.
        /// </summary>
        private Job _Job;

        /// <summary>
        /// 停止处理标志.
        /// </summary>
        private bool done = false;

        /// <summary>
        /// 线程.
        /// </summary>
        private Thread myThread;


        public OneJobManager(long jobID)
        {
            using (MyJobContext context = new MyJobContext())
            {
                var query =
                    from data in context.Jobs.Include("JobTypeData").Include("JobTimeList")
                    where
                        data.JobID == jobID
                    select data;

                this._Job = query.FirstOrDefault();
            }
        }

        public OneJobManager(Job job)
        {
            this._Job = job;
        }


        /// <summary>
        /// 完成作业的处理.
        /// </summary>
        public void DoJob()
        {
            // 作业不存在.
            if (this._Job == null)
            {
                ShowJobReult(CommonServiceResult.DataNotFoundResult);                
                return ;
            }

            while (!done)
            {
                // 运行时间.
                DateTime runTime;

                if (this._Job.NextRunTime != null)
                {
                    // 作业中指定了 下次运行时间.
                    runTime = this._Job.NextRunTime.Value;
                }
                else
                {
                    // 作业中未指定 下次运行时间. 需要通过 配置进行计算.
                    DateTime? nextRunTime = this._Job.GetNextRunTime();
                    if (nextRunTime == null)
                    {
                        // 未得到计算结果.
                        ShowJobReult(CommonServiceResult.DataNotFoundResult);
                    }
                    // 得到计算结果.
                    runTime = nextRunTime.Value;
                }

                if (runTime > DateTime.Now)
                {
                    // 时间未到，需要等待.
                    var timeSpan = runTime - DateTime.Now;
                    // await Task.Delay(timeSpan);
                    Thread.Sleep(timeSpan);
                }

                // 获取处理器.
                IJobProcessService jobProcesser = JobProcessFactory.GetJobProcesser(this._Job.JobTypeData);
                // 处理.
                CommonServiceResult processResult = jobProcesser.ExecuteJob(this._Job);
                // 显示作业处理结果.
                ShowJobReult(processResult);
            }
        }


        /// <summary>
        /// 作业执行完成的委派
        /// </summary>
        public JobFinishDelegate JobFinish { set; get; }


        /// <summary>
        /// 显示作业执行结果.
        /// </summary>
        /// <param name="result"></param>
        private void ShowJobReult(CommonServiceResult result)
        {
            if (this.JobFinish != null)
            {
                // 定义了 委派 的情况下， 执行委派.
                this.JobFinish(this._Job, result);
            }
            else
            {
                // 未定义的情况下， 简单显示.
                Console.WriteLine("Job Result = {0}", result);
            }
        }



        


        CommonServiceResult IJobManager.Start()
        {
            this.myThread = new Thread(new ThreadStart(DoJob));
            this.myThread.Start();

            return CommonServiceResult.DefaultSuccessResult;
        }



        CommonServiceResult IJobManager.Stop()
        {
            done = true;

            // 如果线程还没运行结束，那么 Abort 掉.
            if (this.myThread != null && this.myThread.IsAlive)
            {
                try
                {
                    this.myThread.Abort();
                }
                catch { }
            }

            return CommonServiceResult.DefaultSuccessResult;
        }
    }
}
