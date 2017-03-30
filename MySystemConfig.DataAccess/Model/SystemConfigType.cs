using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using System.Runtime.Serialization;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace MySystemConfig.Model
{

    /// <summary>
    /// 系统配置类型.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("sc_system_config_type")]    
    public class SystemConfigType
    {

        /// <summary>
        /// 系统配置类型代码
        /// </summary>
        [DataMember]
        [Column("config_type_code")]
        [Display(Name = "系统配置类型代码")]
        [StringLength(32)]
        [Key]
        public string ConfigTypeCode { set; get; }



        /// <summary>
        /// 系统配置类型名称
        /// </summary>
        [DataMember]
        [Column("config_type_name")]
        [Display(Name = "系统配置类型名称")]
        [StringLength(64)]
        public string ConfigTypeName { set; get; }




        /// <summary>
        /// 配置的类名.
        /// </summary>
        [Column("config_type_class_name")]
        [Display(Name = "配置的类名")]
        [StringLength(128)]
        public string ConfigClassName { set; get; }






        #region 一对多.


        /// <summary>
        /// 系统配置属性列表.
        /// </summary>
        public virtual List<SystemConfigProperty> SystemConfigPropertyList { set; get; }



        /// <summary>
        /// 系统配置值列表.
        /// </summary>
        public virtual List<SystemConfigValue> SystemConfigValueList { set; get; }


        #endregion 一对多.



    }


}
