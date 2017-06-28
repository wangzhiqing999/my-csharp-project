using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


using System.Runtime.Serialization;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyArea.Model
{



    /// <summary>
    /// 区域.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("ma_area_info")]
    public class AreaInfo
    {


        /// <summary>
        /// 区域代码
        /// </summary>
        [DataMember]
        [Column("area_code")]
        [Key]
        [Display(Name = "区域代码")]
        [StringLength(16)]
        [Required]
        public string AreaCode { set; get; }







        #region 一对多.


        /// <summary>
        /// 父区域代码
        /// </summary>
        [DataMember]
        [Column("parent_area_code")]
        [ForeignKey("ParentAreaInfo")]
        [Display(Name = "父区域代码")]
        [StringLength(16)]
        public string ParentAreaCode { set; get; }



        /// <summary>
        /// 父区域.
        /// </summary>
        [InverseProperty("SubAreaInfos")]
        [XmlIgnoreAttribute()]
        public virtual AreaInfo ParentAreaInfo { set; get; }



        /// <summary>
        /// 子区域列表.
        /// </summary>
        [XmlIgnoreAttribute()]
        public virtual List<AreaInfo> SubAreaInfos { set; get; }



        #endregion 一对多.






        /// <summary>
        /// 区域名称
        /// </summary>
        [DataMember]
        [Column("area_name")]
        [Display(Name = "区域名称")]
        [StringLength(64)]
        [Required]
        public string AreaName { set; get; }




    }

}
