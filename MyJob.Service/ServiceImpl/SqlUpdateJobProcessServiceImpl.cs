using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;


using log4net;

using MyFramework.ServiceModel;

using MyJob.Model;
using MyJob.Service;


namespace MyJob.ServiceImpl
{


    /// <summary>
    /// SQL 更新作业的处理实现.
    /// </summary>
    public class SqlUpdateJobProcessServiceImpl : IJobProcessService
    {


        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        CommonServiceResult IJobProcessService.ExecuteJob(Job job)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(job.JobSetting))
                {
                    conn.Open();

                    // 创建一个 Command.
                    SqlCommand sqlCommand = conn.CreateCommand();

                    // 定义需要执行的SQL语句.
                    sqlCommand.CommandText = job.JobCommand;

                    // ExecuteNonQuery 方法，表明本次操作，不是一个查询的操作。将没有结果集合返回.
                    // 返回的数据，将是 被影响的记录数.
                    int rowCount = sqlCommand.ExecuteNonQuery();

                    // 将更新行数返回出去.
                    return CommonServiceResult.CreateDefaultSuccessResult(rowCount);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                return new CommonServiceResult(ex);
            }
        }


    }



}
