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
    /// 访问明细.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("mas_access_detail")]
    public class AccessDetail
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
        /// 明细代码.
        /// </summary>
        [DataMember]
        [Column("detail_code")]
        [Display(Name = "明细代码")]
        [StringLength(32)]
        public string DetailCode { set; get; }



        /// <summary>
        /// 明细名称
        /// </summary>
        [DataMember]
        [Column("detail_name")]
        [Display(Name = "明细名称")]
        [StringLength(128)]
        public string DetailName { set; get; }


    }
}
