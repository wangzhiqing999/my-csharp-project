using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyFramework.ServiceModel;
using MyJob.Model;
using MyJob.Service;
using MyJob.ServiceImpl;


namespace MyJob.Service.TestClient.Client
{
    class TestClient1
    {

        public static void Start()
        {

            Job myJob = new Job()
            {
                JobTypeData = new JobType () {
                    JobTypeCode = "SQL_QUERY",
                    JobTypeName = "数据库查询",
                    JobTypeProcesser = "MyJob.ServiceImpl.SqlQueryJobProcessServiceImpl"
                },
                JobTimeList = new List<JobTime>(),
                JobTypeCode = "SQL_QUERY",
                JobCommand = "SELECT id, a, b, c FROM test_abc",
                JobSetting = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True",
            };


            // 时间机制， 是 每 10 秒处理一次.
            myJob.JobTimeList.Add(new JobTime () {
                JobTimeType = JobTime.JOB_TIME_TYPE_IS_DELAY_SECOND,
                JobTimeValue = "10"
            });


            IJobManager jobManager = new OneJobManager (myJob);

            JobFinishDelegate showResult = new JobFinishDelegate(ShowResult);

            jobManager.JobFinish = showResult;

            jobManager.Start();
        }




        public static void ShowResult(Job job, CommonServiceResult result)
        {
            //Console.WriteLine("### TestClient1 - Result : {0}", result);
            Console.WriteLine("### {0:yyyy-MM-dd HH:mm:ss} TestClient1 - Result Data: {1}", DateTime.Now, result.ResultData);
        }


    }
}
