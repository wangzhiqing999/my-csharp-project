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
    /// 更新日志类别.
    /// </summary>
    [Serializable]
    [Table("mul_update_log_category")]
    public class UpdateLogCategory
    {

        /// <summary>
        /// 分类代码.
        /// </summary>
        [Column("category_code")]
        [Key]
        [Display(Name = "分类代码")]
        [StringLength(256)]
        [Required]
        public string CategoryCode { set; get; }



        /// <summary>
        /// 分类名称.
        /// </summary>
        [Column("category_name")]
        [Display(Name = "分类名称")]
        [StringLength(256)]
        public string CategoryName { set; get; }





        #region 一对多.


        public virtual List<UpdateLogDetail> UpdateLogDetails { set; get; }

        #endregion 一对多.
    }

}
