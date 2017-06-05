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
    /// 网站模块.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("mw_module")]
    [ToString]
    public class Module
    {


        /// <summary>
        /// 模块代码
        /// </summary>
        [DataMember]
        [Column("module_code")]
        [Display(Name = "模块代码")]
        [Key]
        [Required]
        [StringLength(64)]
        public string ModuleCode { set; get; }



        #region 一对多.  （归属网站）


        /// <summary>
        /// 网站代码
        /// </summary>
        [DataMember]
        [Column("web_site_code")]
        [Display(Name = "网站代码")]
        [Required]
        [StringLength(64)]
        public string WebSiteCode { set; get; }


        /// <summary>
        /// 模块所属的网站.
        /// </summary>
        [IgnoreDuringToString]
        public virtual WebSite ModuleWebSite { set; get; }



        #endregion 一对多.




        /// <summary>
        /// 模块名称
        /// </summary>
        [DataMember]
        [Column("module_name")]
        [Display(Name = "模块名称")]
        [Required]
        [StringLength(256)]
        public string ModuleName { set; get; }






        #region 一对多.


        /// <summary>
        /// 模块中的页面.
        /// </summary>
        [IgnoreDuringToString]
        public virtual List<Page> ModulePages { set; get; }


        #endregion 一对多.

    }

}
