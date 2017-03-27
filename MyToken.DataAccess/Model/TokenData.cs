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
    /// 令牌数据.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("mt_token_data")]
    [ToString]
    public class TokenData
    {

        /// <summary>
        /// 令牌.  (C# 端生成， 不在数据库段生成)
        /// </summary>
        [DataMember]
        [Column("token_id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "令牌ID")]
        [Required]  
        public Guid TokenID { set; get; }




        #region 一对多.


        /// <summary>
        /// 令牌类型代码.
        /// </summary>
        [DataMember]
        [Column("token_type_code")]
        [Display(Name = "令牌类型代码")]
        [StringLength(32)]
        public string TokenTypeCode { set; get; }



        /// <summary>
        /// 令牌类型.
        /// </summary>
        [IgnoreDuringToString]
        public virtual TokenType TokenTypeData { set; get; }


        #endregion 一对多.




        /// <summary>
        /// 用户数据.
        /// </summary>
        [DataMember]
        [Column("user_data")]
        public string UserData { set; get; }



        /// <summary>
        /// 令牌启用时间.
        /// </summary>
        [DataMember]
        [Column("start_time")]
        [Display(Name = "令牌启用时间")]
        public DateTime StartTime { set; get; }



        /// <summary>
        /// 令牌过期时间
        /// </summary>
        [DataMember]
        [Column("expired_time")]
        [Display(Name = "令牌过期时间")]
        public DateTime ExpiredTime { set; get; }



        /// <summary>
        /// 令牌是否可用.
        /// </summary>
        [NotMapped]
        public bool IsUseable
        {
            get
            {
                if (DateTime.Now < this.StartTime)
                {
                    // 尚未开始. (理论上不会执行到这里.)
                    return false;
                }

                if (DateTime.Now > this.ExpiredTime)
                {
                    // 已经结束.
                    return false;
                }

                // 能执行到这里， 认为是有效.
                return true;
            }
        }



        /// <summary>
        /// 访问次数.
        /// </summary>
        [DataMember]
        [Column("access_count")]
        [Display(Name = "访问次数")]
        public int AccessCount { set; get; }









        #region 一对多.


        /// <summary>
        /// 令牌访问日志.
        /// </summary>
        public virtual List<TokenAccessLog> TokenAccessLogList { set; get; }


        #endregion 一对多.



    }

}
