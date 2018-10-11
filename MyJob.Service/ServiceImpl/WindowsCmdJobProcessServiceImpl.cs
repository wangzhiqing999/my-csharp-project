using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Diagnostics;


using log4net;

using MyFramework.ServiceModel;

using MyJob.Model;
using MyJob.Service;



namespace MyJob.ServiceImpl
{

    /// <summary>
    /// Windows 命令行作业.
    /// </summary>
    public class WindowsCmdJobProcessServiceImpl : IJobProcessService
    {
        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        CommonServiceResult IJobProcessService.ExecuteJob(Job job)
        {
            try
            {
                Process process = new Process();

                // 命令.
                process.StartInfo.FileName = job.JobCommand;

                // 参数.
                if (!String.IsNullOrEmpty(job.JobSetting))
                {
                    process.StartInfo.Arguments = job.JobSetting;
                }
                

                // 运行.
                process.Start();

                return CommonServiceResult.DefaultSuccessResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                return new CommonServiceResult(ex);
            }
        }


    }
}
