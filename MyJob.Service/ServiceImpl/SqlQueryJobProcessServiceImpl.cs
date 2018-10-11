using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using Newtonsoft.Json;

using log4net;

using MyFramework.ServiceModel;

using MyJob.Model;
using MyJob.Service;


namespace MyJob.ServiceImpl
{


    /// <summary>
    /// SQL 查询作业的处理实现.
    /// </summary>
    public class SqlQueryJobProcessServiceImpl : IJobProcessService
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

                    // 创建DataSet，用于存储数据.
                    DataSet resultDataSet = new DataSet();

                    // 创建一个适配器
                    SqlDataAdapter adapter = new SqlDataAdapter(job.JobCommand, conn);
                    // 执行查询，并将数据导入DataSet.
                    adapter.Fill(resultDataSet, "result_data");

                    // 取得 DataTable.
                    DataTable dt = resultDataSet.Tables["result_data"];

                    string json = JsonConvert.SerializeObject(dt);

                    // 将 DataTable 返回出去.
                    return CommonServiceResult.CreateDefaultSuccessResult(json);
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
