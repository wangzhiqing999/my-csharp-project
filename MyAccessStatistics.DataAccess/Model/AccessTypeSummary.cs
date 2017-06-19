using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Runtime.Serialization;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyAccessStatistics.Model
{


    /// <summary>
    /// 访问汇总.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("mas_access_type_summary")]
    public class AccessTypeSummary
    {


        #region 一对多.

        /// <summary>
        /// 访问类型代码.
        /// </summary>
        [DataMember]
        [Column("access_type_code")]
        [Display(Name = "访问类型代码")]
        [StringLength(32)]
        public string AccessTypeCode { set; get; }



        /// <summary>
        /// 访问类型数据.
        /// </summary>
        public virtual AccessType AccessTypeData { set; get; }


        #endregion 一对多.




        /// <summary>
        /// 访问日期.
        /// </summary>
        [DataMember]
        [Column("access_date")]
        [Display(Name = "访问日期")]
        public DateTime AccessDate { set; get; }




        /// <summary>
        /// 访问次数
        /// </summary>
        [DataMember]
        [Column("access_count")]
        [Display(Name = "访问次数")]
        public int AccessCount { set; get; }


    }


}
