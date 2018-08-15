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
    /// 系统配置.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("sc_system_config_value")]    
    public class SystemConfigValue 
    {



        #region 一对多.

        /// <summary>
        /// 系统配置类型代码
        /// </summary>
        [DataMember]
        [Column("config_type_code")]
        [Display(Name = "系统配置类型代码")]
        [StringLength(32)]
        [Required]
        public string ConfigTypeCode { set; get; }


        /// <summary>
        /// 系统配置类型
        /// </summary>
        public virtual SystemConfigType SystemConfigTypeData { set; get; }


        #endregion 一对多.



        /// <summary>
        /// 系统配置代码
        /// </summary>
        [DataMember]
        [Column("config_code")]
        [Display(Name = "系统配置代码")]
        [StringLength(32)]
        public string ConfigCode { set; get; }



        /// <summary>
        /// 系统配置名称
        /// </summary>
        [DataMember]
        [Column("config_name")]
        [Display(Name = "系统配置名称")]
        [StringLength(64)]
        public string ConfigName { set; get; }




        /// <summary>
        /// 系统配置数值.
        /// </summary>
        [DataMember]
        [Column("config_value")]
        [Display(Name = "系统配置数值")]
        public string ConfigValue { set; get; }



        /// <summary>
        /// 配置对象.
        /// </summary>
        [NotMapped]
        public dynamic ConfigValueObject { set; get; }


    }


}
