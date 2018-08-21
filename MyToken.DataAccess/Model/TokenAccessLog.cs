using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Runtime.Serialization;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyToken.Model
{


    /// <summary>
    /// 令牌访问日志.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("mt_token_access_log")]
    //[ToString]
    public class TokenAccessLog
    {

        /// <summary>
        /// 日志代码.
        /// </summary>
        [DataMember]
        [Column("access_log_id")]
        [Key]
        [Display(Name = "令牌ID")]
        public long AccessLogID { set; get; }





        #region 一对多.


        /// <summary>
        /// 令牌ID.
        /// </summary>
        [DataMember]
        [Column("token_id")]
        [Display(Name = "令牌ID")]
        [Required]
        public Guid TokenID { set; get; }


        /// <summary>
        /// 令牌数据
        /// </summary>
        //[IgnoreDuringToString]
        public virtual TokenData TokenData { set; get; }


        #endregion 一对多.





        /// <summary>
        /// 访问时间.
        /// </summary>
        [DataMember]
        [Column("access_time")]
        [Display(Name = "访问时间")]
        public DateTime AccessTime { set; get; }


        /// <summary>
        /// 访问结果.
        /// </summary>
        [DataMember]
        [Column("access_result")]
        [Display(Name = "访问结果")]
        [StringLength(64)]
        public string AccessResult { set; get; }


        /// <summary>
        /// 用户数据.
        /// </summary>
        [DataMember]
        [Column("user_data")]
        public string UserData { set; get; }


        /// <summary>
        /// 用户数据对象.
        /// </summary>
        [NotMapped]
        public Dictionary<string, object> UserDataObject { set; get; }





    }




}
