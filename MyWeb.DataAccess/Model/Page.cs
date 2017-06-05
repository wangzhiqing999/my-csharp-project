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
    /// 网站页面.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("mw_page")]
    [ToString]
    public class Page
    {

        /// <summary>
        /// 页面代码
        /// </summary>
        [DataMember]
        [Column("page_code")]
        [Display(Name = "页面代码")]
        [Key]
        [Required]
        [StringLength(64)]
        public string PageCode { set; get; }




        #region 一对多. （归属模块）


        /// <summary>
        /// 模块代码
        /// </summary>
        [DataMember]
        [Column("module_code")]
        [Display(Name = "模块代码")]
        [Required]
        [StringLength(64)]
        public string ModuleCode { set; get; }



        /// <summary>
        /// 页面所属的模块.
        /// </summary>
        [IgnoreDuringToString]
        public virtual Module PageModule { set; get; }



        #endregion 一对多.





        #region 一对多.  (自己对自己 一对多， 实现树形结构)


        /// <summary>
        /// 父页面代码
        /// </summary>
        [DataMember]
        [Column("parent_page_code")]
        [ForeignKey("ParentPage")]
        [Display(Name = "父页面代码")]
        [StringLength(64)]
        public string ParentPageCode { set; get; }



        /// <summary>
        /// 父页面.
        /// </summary>
        [InverseProperty("SubPages")]
        [IgnoreDuringToString]
        public Page ParentPage { set; get; }



        /// <summary>
        /// 子页面列表.
        /// </summary>
        [IgnoreDuringToString]
        public virtual List<Page> SubPages { set; get; }



        #endregion




        /// <summary>
        /// 页面名称
        /// </summary>
        [DataMember]
        [Column("page_name")]
        [Display(Name = "页面名称")]
        [Required]
        [StringLength(256)]
        public string PageName { set; get; }




        /// <summary>
        /// 页面路径
        /// </summary>
        [DataMember]
        [Column("page_path")]
        [Display(Name = "页面路径")]
        [StringLength(256)]
        public string PagePath { set; get; }




        /// <summary>
        /// 是否是部分页面.
        /// </summary>
        [DataMember]
        [Column("is_partial")]
        [Display(Name = "是否是部分页面(非独立页面)")]
        public bool IsPartial { set; get; }



        /// <summary>
        /// 显示顺序.
        /// </summary>
        [DataMember]
        [Column("display_index")]
        [Display(Name = "显示顺序")]
        public int DisplayIndex { set; get; }





        #region 一对多.


        /// <summary>
        /// 哪些菜单跳转至本页面.
        /// </summary>
        [IgnoreDuringToString]
        public virtual List<Menu> PageMenus { set; get; }


        #endregion 一对多.




    }


}
