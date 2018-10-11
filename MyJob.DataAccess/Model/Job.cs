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
    /// 作业.
    /// </summary>
    [Serializable]
    [Table("mj_job")]   
    public class Job
    {

        /// <summary>
        /// 作业流水.
        /// </summary>
        [Column("job_id")]
        [Display(Name = "作业流水")]
        [Key]
        public long JobID { set; get; }





        #region 一对多 - 作业类型


        /// <summary>
        /// 作业类型代码.
        /// </summary>
        [Column("job_type_code")]
        [Display(Name = "作业类型代码")]
        [StringLength(32)]
        [Required]
        public string JobTypeCode { set; get; }



        /// <summary>
        /// 作业类型数据.
        /// </summary>
        public JobType JobTypeData { set; get; }



        #endregion






        /// <summary>
        /// 作业名称.
        /// </summary>
        [Column("job_name")]
        [Display(Name = "作业名称")]
        [StringLength(32)]
        public string JobName { set; get; }


        /// <summary>
        /// 作业描述.
        /// </summary>
        [Column("job_desc")]
        [Display(Name = "作业描述")]
        public string JobDesc { set; get; }



        /// <summary>
        /// 上次运行时间.
        /// </summary>
        [Column("prev_run_time")]
        [Display(Name = "上次运行时间")]
        public DateTime? PrevRunTime { set; get; }


        /// <summary>
        /// 下次运行时间.
        /// </summary>
        [Column("next_run_time")]
        [Display(Name = "下次运行时间")]
        public DateTime? NextRunTime { set; get; }



        public DateTime? GetNextRunTime()
        {
            if (this.JobTimeList == null || this.JobTimeList.Count == 0)
            {
                return null;
            }

            List<DateTime> dtList = new List<DateTime>();
            foreach (var jobTime in this.JobTimeList)
            {
                var oneTime = jobTime.GetNextRunTime();
                if (oneTime != null)
                {
                    dtList.Add(oneTime.Value);
                }
            }

            if (dtList.Count == 0)
            {
                return null;
            }

            return dtList.OrderBy(p => p).First();
        }




        /// <summary>
        /// 作业设置.
        /// </summary>
        [Column("job_setting")]
        [Display(Name = "作业设置")]
        public string JobSetting { set; get; }



        /// <summary>
        /// 作业命令
        /// </summary>
        [Column("job_command")]
        [Display(Name = "作业命令")]
        public string JobCommand { set; get; }








        #region 一对多.


        /// <summary>
        /// 作业时间
        /// </summary>
        public List<JobTime> JobTimeList { set; get; }



        /// <summary>
        /// 作业日志
        /// </summary>
        public List<JobLog> JobLogList { set; get; }


        #endregion


    }
}
