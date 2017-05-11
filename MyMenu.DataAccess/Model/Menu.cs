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

using System.Web.Script.Serialization;


namespace MyMenu.Model
{


    /// <summary>
    /// 菜单.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("mm_menu")]
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
        [ScriptIgnore]
        public Menu ParentMenu { set; get; }



        /// <summary>
        /// 子菜单列表.
        /// </summary>
        [XmlIgnoreAttribute]
        [ScriptIgnore]
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
        /// 菜单扩展信息
        /// </summary>
        [DataMember]
        [Column("menu_expand")]
        [Display(Name = "菜单扩展信息")]
        [StringLength(512)]
        public string MenuExpand { set; get; }










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
