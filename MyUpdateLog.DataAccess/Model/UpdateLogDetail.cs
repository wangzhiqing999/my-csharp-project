using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace MyUpdateLog.Model
{


    /// <summary>
    /// 更新日志明细.
    /// </summary>
    [Serializable]
    [Table("mul_update_log_detail")]
    public class UpdateLogDetail
    {

        /// <summary>
        /// 日志流水.
        /// </summary>
        [Column("log_id")]
        [Key]
        [Display(Name = "日志流水")]
        public long LogID { set; get; }





        #region 一对多.


        /// <summary>
        /// 分类代码.
        /// </summary>
        [Column("category_code")]
        [Display(Name = "分类代码")]
        [StringLength(256)]
        [Required]
        public string CategoryCode { set; get; }



        /// <summary>
        /// 日志分类.
        /// </summary>
        public virtual UpdateLogCategory UpdateLogCategoryData { set; get; }


        #endregion 一对多.



        /// <summary>
        /// 主键数据
        /// </summary>
        [Column("key_data")]
        [Display(Name = "主键数据")]
        [StringLength(1024)]
        public string KeyData { set; get; }




        /// <summary>
        /// 何时更新的
        /// </summary>
        [Column("when_update")]
        [Display(Name = "何时更新的")]
        public DateTime WhenUpdate { set; get; }



        /// <summary>
        /// 谁更新的
        /// </summary>
        [Column("who_update")]
        [Display(Name = "谁更新的")]
        [StringLength(256)]
        public string WhoUpdate { set; get; }



        /// <summary>
        /// 更新了什么
        /// </summary>
        [Column("what_update")]
        [Display(Name = "更新了什么")]
        public string WhatUpdate { set; get; }




    }

}
