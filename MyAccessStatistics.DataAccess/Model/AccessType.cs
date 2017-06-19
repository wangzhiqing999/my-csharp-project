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
    /// 访问类型.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("mas_access_type")]
    public class AccessType
    {

        /// <summary>
        /// 访问类型代码.
        /// </summary>
        [DataMember]
        [Column("access_type_code")]
        [Display(Name = "访问类型代码")]
        [StringLength(32)]
        [Key]
        public string AccessTypeCode { set; get; }




        /// <summary>
        /// 访问类型名称.
        /// </summary>
        [DataMember]
        [Column("access_type_name")]
        [Display(Name = "访问类型名称")]
        [StringLength(64)]
        public string AccessTypeName { set; get; }






        #region 一对多.


        /// <summary>
        /// 访问汇总信息.
        /// </summary>
        public virtual List<AccessTypeSummary> AccessSummaryList { set; get; }




        /// <summary>
        /// 访问明细信息.
        /// </summary>
        public virtual List<AccessDetail> AccessDetailList { set; get; }



        /// <summary>
        /// 访问明细汇总.
        /// </summary>
        public virtual List<AccessDetailSummary> AccessDetailSummaryList { set; get; }




        /// <summary>
        /// 访问明细日志.
        /// </summary>
        public virtual List<AccessDetailLog> AccessDetailLogList { set; get; }


        #endregion 一对多.







    }

}
