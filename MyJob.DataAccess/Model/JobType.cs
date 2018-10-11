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
    /// 作业类型.
    /// </summary>
    [Serializable]
    [Table("mj_job_type")]   
    public class JobType
    {

        /// <summary>
        /// 作业类型代码.
        /// </summary>
        [Column("job_type_code")]
        [Display(Name = "作业类型代码")]
        [StringLength(32)]
        [Key]
        public string JobTypeCode { set; get; }


        /// <summary>
        /// 作业类型名称.
        /// </summary>
        [Column("job_type_name")]
        [Display(Name = "作业类型名称")]
        [StringLength(64)]
        public string JobTypeName { set; get; }






        /// <summary>
        /// 作业类型名称.
        /// </summary>
        [Column("job_type_processer")]
        [Display(Name = "作业类型处理器")]
        [StringLength(256)]
        public string JobTypeProcesser { set; get; }





        #region 一对多.


        /// <summary>
        /// 作业列表.
        /// </summary>
        public List<Job> JobList { set; get; }


        #endregion



    }


}
