using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Runtime.Serialization;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



using MyFramework.Model;



namespace MyBanner.Model
{

    /// <summary>
    /// 网站横幅类型.
    /// </summary>
    [Serializable]
    [Table("my_banner_type")]
    public class BannerType : AbstractCommonData
    {


        /// <summary>
        /// 网站横幅类型代码.
        /// </summary>
        [Column("banner_type_code")]
        [Display(Name = "网站横幅类型代码")]
        [StringLength(32)]
        [Key]
        public string BannerTypeCode { set; get; }




        /// <summary>
        /// 网站横幅类型名称.
        /// </summary>
        [Column("banner_type_name")]
        [Display(Name = "网站横幅类型名称")]
        [StringLength(64)]
        [Required]
        public string BannerTypeName { set; get; }





        #region 一对多.


        /// <summary>
        /// 横幅列表.
        /// </summary>
        public virtual List<Banner> BannerList { set; get; }


        #endregion





    }
}
