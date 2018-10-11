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
    /// 作业日志.
    /// </summary>
    [Serializable]
    [Table("mj_job_log")]   
    public class JobLog
    {

        /// <summary>
        /// 日志流水.
        /// </summary>
        [Column("log_id")]
        [Display(Name = "日志流水")]
        [Key]
        public long LogID { set; get; }




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










    }
}
