using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System.Runtime.Serialization;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace MyUserMonitor.Model
{


    /// <summary>
    /// 用户访问信息.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("user_access_info")]
    public class UserAccessInfo
    {

        /// <summary>
        /// 流水号.
        /// </summary>
        [DataMember]
        [Column("id")]
        [Display(Name = "流水号")]
        [Key]
        public long ID { set; get; }



        /// <summary>
        /// 分组代码.
        /// </summary>
        [DataMember]
        [Column("group_code")]
        [Display(Name = "分组代码")]
        [StringLength(32)]  
        public string GroupCode { set; get; }



        /// <summary>
        /// 用户名.
        /// </summary>
        [DataMember]
        [Column("user_name")]
        [Display(Name = "用户名")]
        [StringLength(128)]    
        public string UserName { set; get; }



        /// <summary>
        /// 进入时间.
        /// </summary>
        [DataMember]
        [Column("enter_time")]
        [Display(Name = "进入时间")]
        public DateTime EnterTime { set; get; }



        /// <summary>
        /// 最后访问时间.
        /// </summary>
        [DataMember]
        [Column("last_access_time")]
        [Display(Name = "最后访问时间")]
        public DateTime LastAccessTime { set; get; }



        /// <summary>
        /// 访问次数
        /// </summary>
        [DataMember]
        [Column("access_count")]
        [Display(Name = "访问次数")]
        public int AccessCount { set; get; }



        /// <summary>
        /// 扩展数据
        /// </summary>
        [DataMember]
        [Column("exp_data")]
        [Display(Name = "扩展数据")]
        public string ExpData { set; get; }

    }


}
