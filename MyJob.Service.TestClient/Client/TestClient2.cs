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
    class TestClient2
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
                JobCommand = "SELECT id, a, b, c FROM test_abc WHERE id = 'TEST2'",
                JobSetting = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True",
            };


            string [] runTimeArray = {
                                         "00:00", "30:30",
                                         "01:00", "31:30",
                                         "02:00", "32:30",
                                         "03:00", "33:30",
                                         "04:00", "34:30",
                                         "05:00", "35:30",
                                         "06:00", "36:30",
                                         "07:00", "37:30",
                                         "08:00", "38:30",
                                         "09:00", "39:30",
                                         "10:00", "40:30",
                                         "11:00", "41:30",
                                         "12:00", "42:30",
                                         "13:00", "43:30",
                                         "14:00", "44:30",
                                         "15:00", "45:30",
                                         "16:00", "46:30",
                                         "17:00", "47:30",
                                         "18:00", "48:30",
                                         "19:00", "49:30",
                                         "20:00", "50:30",
                                         "21:00", "51:30",
                                         "22:00", "52:30",
                                         "23:00", "53:30",
                                         "24:00", "54:30",
                                         "25:00", "55:30",
                                         "26:00", "56:30",
                                         "27:00", "57:30",
                                         "28:00", "58:30",
                                         "29:00", "59:30",
                                     };

            // 时间机制， 是 每个小时的 指定时间点才执行.
            myJob.JobTimeList.Add(new JobTime () {
                JobTimeType = JobTime.JOB_TIME_TYPE_IS_HOURLY,
                JobTimeValue = String.Join(";", runTimeArray)
            });


            IJobManager jobManager = new OneJobManager (myJob);

            JobFinishDelegate showResult = new JobFinishDelegate(ShowResult);

            jobManager.JobFinish = showResult;

            jobManager.Start();
        }




        public static void ShowResult(Job job, CommonServiceResult result)
        {
            //Console.WriteLine("### TestClient2 - Result : {0}", result);
            Console.WriteLine("### {0:yyyy-MM-dd HH:mm:ss} TestClient2 - Result Data: {1}", DateTime.Now, result.ResultData);
        }


    }
}
