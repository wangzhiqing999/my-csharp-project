using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyJob.Model
{

    /// <summary>
    /// 作业时间.
    /// </summary>
    [Serializable]
    [Table("mj_job_time")]
    public class JobTime
    {


        /// <summary>
        /// 作业时间流水.
        /// </summary>
        [Column("time_id")]
        [Display(Name = "作业时间流水")]
        [Key]
        public long TimeID { set; get; }





        #region 一对多.


        /// <summary>
        /// 作业流水.
        /// </summary>
        [Column("job_id")]
        [Display(Name = "作业流水")]
        public long JobID { set; get; }




        /// <summary>
        /// 作业数据.
        /// </summary>
        public Job JobData { set; get; }



        #endregion






        /// <summary>
        /// 单次运行，不重复.
        /// 这种情况下， 作业时间数值 = yyyy-MM-dd HH:mm:ss
        /// </summary>
        public const string JOB_TIME_TYPE_IS_ONE_TIME = "ONE_TIME";


        /// <summary>
        /// 每天指定时间运行.
        /// 这种情况下， 作业时间数值 = HH:mm:ss
        /// 一天执行多次的情况下，作业时间数值 = HH:mm:ss;HH:mm:ss;HH:mm:ss
        /// </summary>
        public const string JOB_TIME_TYPE_IS_DAILY = "DAILY";


        /// <summary>
        /// 每小时指定时刻运行.
        /// 这种情况下， 作业时间数值 = mm:ss
        /// 一小时执行多次的情况下，作业时间数值 = mm:ss;mm:ss;mm:ss
        /// </summary>
        public const string JOB_TIME_TYPE_IS_HOURLY = "HOURLY";


        /// <summary>
        /// 延迟运行.
        /// 也就是作业执行完毕后，延迟指定的秒数后，再次执行.
        /// 这种情况下， 作业时间数值 = 延迟的秒数.
        /// </summary>
        public const string JOB_TIME_TYPE_IS_DELAY_SECOND = "DELAY_SECOND";



        /// <summary>
        /// 作业时间类型.
        /// </summary>
        [Column("job_time_type")]
        [Display(Name = "作业时间类型")]
        [StringLength(32)]
        public string JobTimeType { set; get; }



        /// <summary>
        /// 作业时间数值.
        /// </summary>
        [Column("job_time_value")]
        [Display(Name = "作业时间数值")]
        public string JobTimeValue { set; get; }




        /// <summary>
        /// 获取下次运行时间.
        /// </summary>
        /// <returns></returns>
        public DateTime? GetNextRunTime()
        {
            switch (this.JobTimeType)
            {

                case JOB_TIME_TYPE_IS_ONE_TIME:
                    // 单次运行，不重复.
                    // 这种情况下， 作业时间数值 = yyyy-MM-dd HH:mm:ss
                    return Convert.ToDateTime(this.JobTimeValue);
                    

                case JOB_TIME_TYPE_IS_DAILY:
                    // 每天指定时间运行.
                    // 这种情况下， 作业时间数值 = HH:mm:ss
                    // 一天执行多次的情况下，作业时间数值 = HH:mm:ss;HH:mm:ss;HH:mm:ss
                    string[] timesArray = this.JobTimeValue.Split(';', ',');

                    List<DateTime> dtList = new List<DateTime>();
                    foreach (string time in timesArray)
                    {
                        string[] timeValue = time.Split(':');

                        int hour = Convert.ToInt32(timeValue[0]);
                        int min = Convert.ToInt32(timeValue[1]);
                        int second = Convert.ToInt32(timeValue[2]);

                        // 今天的时间数据.
                        DateTime dt = DateTime.Today.AddHours(hour).AddMinutes(min).AddSeconds(second);
                        dtList.Add(dt);

                        // 为了避免 00:00:00 这样的时间出现.
                        // 把明天的时间， 也加入列表
                        DateTime dt2 = DateTime.Today.AddDays(1).AddHours(hour).AddMinutes(min).AddSeconds(second);
                        dtList.Add(dt2);                        
                    }

                    var query =
                        from data in dtList
                        where
                            // 时间尚未过去.
                            data > DateTime.Now
                        orderby
                            // 按时间先后排序.
                            data
                        select data;

                    // 返回满足条件的首条.
                    return query.FirstOrDefault();


                case JOB_TIME_TYPE_IS_HOURLY :
                    // 每小时指定时刻运行.
                    // 这种情况下， 作业时间数值 = mm:ss
                    // 一小时执行多次的情况下，作业时间数值 = mm:ss;mm:ss;mm:ss

                    string[] timesArray2 = this.JobTimeValue.Split(';', ',');

                    List<DateTime> dtList2 = new List<DateTime>();
                    foreach (string time in timesArray2)
                    {
                        string[] timeValue = time.Split(':');

                        int hour = DateTime.Now.Hour;
                        int min = Convert.ToInt32(timeValue[0]);
                        int second = Convert.ToInt32(timeValue[1]);

                        // 这个小时的时间数据.
                        DateTime dt = DateTime.Today.AddHours(hour).AddMinutes(min).AddSeconds(second);
                        dtList2.Add(dt);

                        // 为了避免 00:00 这样的时间出现.
                        // 把下一个小时的数据， 也加入列表
                        DateTime dt2 = DateTime.Today.AddHours(1).AddHours(hour).AddMinutes(min).AddSeconds(second);
                        dtList2.Add(dt2);                        
                    }

                    var query2 =
                        from data in dtList2
                        where
                            // 时间尚未过去.
                            data > DateTime.Now
                        orderby
                            // 按时间先后排序.
                            data
                        select data;

                    // 返回满足条件的首条.
                    return query2.FirstOrDefault();


                case JOB_TIME_TYPE_IS_DELAY_SECOND:
                    // 延迟运行.
                    // 也就是作业执行完毕后，延迟指定的秒数后，再次执行.
                    // 这种情况下， 作业时间数值 = 延迟的秒数.

                    int sec = Convert.ToInt32(this.JobTimeValue);

                    // 当前时间， 指定秒数后.
                    DateTime result = DateTime.Now.AddSeconds(sec);

                    return result;

                default:
                    // 未知的情况下.
                    return null;
            }
        }







    }


}
