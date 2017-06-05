using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyWeb.Model
{

    /// <summary>
    /// 网站.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("mw_web_site")]
    [ToString]
    public class WebSite
    {


        /// <summary>
        /// 网站代码
        /// </summary>
        [DataMember]
        [Column("web_site_code")]
        [Display(Name = "网站代码")]
        [Key]
        [Required]
        [StringLength(64)]
        public string WebSiteCode { set; get; }



        /// <summary>
        /// 网站名称
        /// </summary>
        [DataMember]
        [Column("web_site_name")]
        [Display(Name = "网站名称")]
        [Required]
        [StringLength(256)]
        public string WebSiteName { set; get; }



        /// <summary>
        /// 网站主机
        /// </summary>
        [DataMember]
        [Column("web_site_host")]
        [Display(Name = "网站主机")]
        [StringLength(256)]
        public string WebSiteHost { set; get; }



        /// <summary>
        /// 网站端口
        /// </summary>
        [DataMember]
        [Column("web_site_port")]
        [Display(Name = "网站端口")]
        public int WebSitePort { set; get; }



        /// <summary>
        /// 是否是使用 https.
        /// </summary>
        [DataMember]
        [Column("web_site_use_https")]
        [Display(Name = "是否是使用 https")]
        public bool IsHttps { set; get; }





        #region 一对多.


        /// <summary>
        /// 网站下的模块.
        /// </summary>
        [IgnoreDuringToString]
        public virtual List<Module> WebSiteModules { set; get; }



        /// <summary>
        /// 网站下的菜单.
        /// </summary>
        [IgnoreDuringToString]
        public virtual List<Menu> WebSiteMenus { set; get; }



        #endregion 一对多.


    }


}
