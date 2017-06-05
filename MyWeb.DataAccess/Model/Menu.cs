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


namespace MyWeb.Model
{


    /// <summary>
    /// 菜单.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("mw_menu")]
    [ToString]
    public class Menu
    {


        /// <summary>
        /// 菜单代码
        /// </summary>
        [DataMember]
        [Column("menu_code")]
        [Key]
        [Display(Name = "菜单代码")]
        [StringLength(32)]
        [Required]
        public string MenuCode { set; get; }



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
        /// 菜单所属的网站.
        /// </summary>
        [IgnoreDuringToString]
        public virtual WebSite MenuWebSite { set; get; }



        #endregion 一对多.







        #region 一对多的部分.  (自己对自己 一对多， 实现树形结构)


        /// <summary>
        /// 父菜单编号
        /// </summary>
        [DataMember]
        [Column("parent_menu_code")]
        [ForeignKey("ParentMenu")]
        [Display(Name = "父菜单编号")]
        [StringLength(32)]
        public string ParentMenuCode { set; get; }



        /// <summary>
        /// 父菜单.
        /// </summary>
        [InverseProperty("SubMenus")]
        [XmlIgnoreAttribute]
        [IgnoreDuringToString]
        public Menu ParentMenu { set; get; }



        /// <summary>
        /// 子菜单列表.
        /// </summary>
        [XmlIgnoreAttribute]
        [IgnoreDuringToString]
        public virtual List<Menu> SubMenus { set; get; }



        #endregion











        /// <summary>
        /// 显示顺序.
        /// </summary>
        [DataMember]
        [Column("display_index")]
        [Display(Name = "显示顺序")]
        public int DisplayIndex { set; get; }



        /// <summary>
        /// 菜单文本
        /// </summary>
        [DataMember]
        [Column("menu_text")]
        [Display(Name = "菜单文本")]
        [Required]
        [StringLength(32)]
        public string MenuText { set; get; }



        /// <summary>
        /// 菜单备注
        /// </summary>
        [DataMember]
        [Column("menu_desc")]
        [Display(Name = "菜单备注")]
        [StringLength(256)]
        public string MenuDesc { set; get; }





        /// <summary>
        /// 菜单目标.
        /// </summary>
        [DataMember]
        [Column("menu_target")]
        [Display(Name = "菜单目标")]
        [StringLength(32)]
        public string MenuTarget { set; get; }




        /// <summary>
        /// 是否是外部链接
        /// </summary>
        [DataMember]
        [Column("is_outer_href")]
        [Display(Name = "是否是外部链接")]
        public bool IsOuterHref { set; get; }



        /// <summary>
        /// 菜单跳转地址.
        /// </summary>
        [DataMember]
        [Column("menu_href")]
        [Display(Name = "菜单跳转地址 (仅仅当外部链接的时候填写)")]
        [StringLength(512)]
        public string MenuHref { set; get; }




        #region  一对多.  (指向页面， 仅仅当 IsOuterHref == false 时使用.)


        /// <summary>
        /// 页面代码
        /// </summary>
        [DataMember]
        [Column("page_code")]
        [Display(Name = "页面代码 (仅仅当非外部链接的时候填写)")]
        [StringLength(64)]
        public string PageCode { set; get; }



        /// <summary>
        /// 菜单需要跳转的页面.
        /// </summary>
        public virtual Page MenuPage { set; get; }


        #endregion




        /// <summary>
        /// 菜单扩展信息
        /// </summary>
        [DataMember]
        [Column("menu_expand")]
        [Display(Name = "菜单扩展信息")]
        [StringLength(512)]
        public string MenuExpand { set; get; }





        
        public string GetHtmlMenuHref()
        {
            if (this.IsOuterHref)
            {
                // 外部链接的情况下，直接返回外部链接.
                return this.MenuHref;
            }

            // 非外部链接的情况下，返回页面的链接.
            if (!String.IsNullOrEmpty(this.PageCode) && this.MenuPage != null)
            {
                // 有页面数据的情况下.
                return this.MenuPage.PagePath;
            }

            // 其他情况下.
            return "#";
        }




        #region


        /// <summary>
        /// 菜单层次.
        /// 
        /// 计算时使用，不存储在数据库中.
        /// </summary>
        [NotMapped]
        [XmlIgnoreAttribute]
        public int MenuLevel { set; get; }



        /// <summary>
        /// 子菜单列表.
        /// 
        /// 计算时使用，不存储在数据库中.
        /// </summary>
        [NotMapped]
        [XmlIgnoreAttribute]
        public List<Menu> MenuSubMenuList { set; get; }


        #endregion

    }

}
