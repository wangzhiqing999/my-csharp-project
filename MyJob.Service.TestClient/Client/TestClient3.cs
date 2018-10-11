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
    class TestClient3
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
                JobCommand = "SELECT id, a, b, c FROM test_abc WHERE id = 'TEST'",
                JobSetting = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True",
            };


            string[] runTimeArray = {
                                         "00:00:00", "00:15:00", "00:30:00", "00:45:00",
                                         "01:00:00", "01:15:00", "01:30:00", "01:45:00",
                                         "02:00:00", "02:15:00", "02:30:00", "02:45:00",
                                         "03:00:00", "03:15:00", "03:30:00", "03:45:00",
                                         "04:00:00", "04:15:00", "04:30:00", "04:45:00",
                                         "05:00:00", "05:15:00", "05:30:00", "05:45:00",
                                         "06:00:00", "06:15:00", "06:30:00", "06:45:00",
                                         "07:00:00", "07:15:00", "07:30:00", "07:45:00",
                                         "08:00:00", "08:15:00", "08:30:00", "08:45:00",
                                         "09:00:00", "09:15:00", "09:30:00", "09:45:00",
                                         "10:00:00", "10:15:00", "10:30:00", "10:45:00",
                                         "11:00:00", "11:15:00", "11:30:00", "11:45:00",
                                         "12:00:00", "12:15:00", "12:30:00", "12:45:00",
                                         "13:00:00", "13:15:00", "13:30:00", "13:45:00",
                                         "14:00:00", "14:15:00", "14:30:00", "14:45:00",
                                         "15:00:00", "15:15:00", "15:30:00", "15:45:00",
                                         "16:00:00", "16:15:00", "16:30:00", "16:45:00",
                                         "17:00:00", "17:15:00", "17:30:00", "17:45:00",
                                         "18:00:00", "18:15:00", "18:30:00", "18:45:00",
                                         "19:00:00", "19:15:00", "19:30:00", "19:45:00",
                                         "20:00:00", "20:15:00", "20:30:00", "20:45:00",
                                         "21:00:00", "21:15:00", "21:30:00", "21:45:00",
                                         "22:00:00", "22:15:00", "22:30:00", "22:45:00",
                                         "23:00:00", "23:15:00", "23:30:00", "23:45:00",
                                     };


            // 时间机制， 是 每天的 指定时间点才执行.
            myJob.JobTimeList.Add(new JobTime () {
                JobTimeType = JobTime.JOB_TIME_TYPE_IS_DAILY,
                JobTimeValue = String.Join(";", runTimeArray)
            });


            IJobManager jobManager = new OneJobManager (myJob);

            JobFinishDelegate showResult = new JobFinishDelegate(ShowResult);

            jobManager.JobFinish = showResult;

            jobManager.Start();
        }




        public static void ShowResult(Job job, CommonServiceResult result)
        {
            //Console.WriteLine("### TestClient3 - Result : {0}", result);
            Console.WriteLine("### {0:yyyy-MM-dd HH:mm:ss} TestClient3 - Result Data: {1}", DateTime.Now, result.ResultData);
        }


    }
}
