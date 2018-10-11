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
    /// 作业管理.
    /// </summary>
    public interface IJobManager
    {

        /// <summary>
        /// 开始管理操作.
        /// </summary>
        /// <returns></returns>
        CommonServiceResult Start();



        /// <summary>
        /// 停止管理操作.
        /// </summary>
        /// <returns></returns>
        CommonServiceResult Stop();


        /// <summary>
        /// 作业执行完成的委派
        /// </summary>
        JobFinishDelegate JobFinish { set; get; }


    }


    /// <summary>
    /// 单次作业执行完成的委派.
    /// </summary>
    /// <param name="job">作业</param>
    /// <param name="result">执行结果</param>
    public delegate void JobFinishDelegate(Job job, CommonServiceResult result);

}
