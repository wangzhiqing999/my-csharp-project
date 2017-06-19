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
    /// 访问明细日志.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("mas_access_detail_log")]
    public class AccessDetailLog
    {



        /// <summary>
        /// 访问明细日志流水.
        /// </summary>
        [DataMember]
        [Column("access_log_id")]
        [Display(Name = "访问明细日志流水")]
        [Key]
        public long LogID { set; get; }




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
        /// 明细代码.
        /// </summary>
        [DataMember]
        [Column("detail_code")]
        [Display(Name = "明细代码")]
        [StringLength(32)]
        public string DetailCode { set; get; }




        /// <summary>
        /// 访问时间
        /// </summary>
        [DataMember]
        [Column("access_time")]
        [Display(Name = "访问时间")]
        public DateTime AccessTime { set; get; }



        /// <summary>
        /// 扩展信息.
        /// </summary>
        [DataMember]
        [Column("exp_info")]
        [Display(Name = "扩展信息")]
        public string ExpInfo { set; get; }

    }


}
