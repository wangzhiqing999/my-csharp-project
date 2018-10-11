using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyFramework.ServiceModel;

using MyJob.Model;

namespace MyJob.Service
{
    /// <summary>
    /// 作业处理服务.
    /// </summary>
    public interface IJobProcessService
    {



        /// <summary>
        /// 执行作业.
        /// </summary>
        /// <param name="job"></param>
        CommonServiceResult ExecuteJob(Job job);



    }
}
