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
    /// 令牌类型.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("mt_token_type")]
    [ToString]
    public class TokenType
    {

        /// <summary>
        /// 令牌类型代码.
        /// </summary>
        [DataMember]
        [Column("token_type_code")]
        [Key]
        [Display(Name = "令牌类型代码")]
        [StringLength(32)]
        public string TokenTypeCode { set; get; }



        /// <summary>
        /// 令牌类型名称.
        /// </summary>
        [DataMember]
        [Column("token_type_name")]
        [Display(Name = "令牌类型名称")]
        [StringLength(32)]
        public string TokenTypeName { set; get; }



        /// <summary>
        /// 令牌类型描述.
        /// </summary>
        [DataMember]
        [Column("token_type_desc")]
        [Display(Name = "令牌类型描述")]
        [StringLength(128)]
        public string TokenTypeDesc { set; get; }







        #region 配置参数.



        /// <summary>
        /// 默认的超时秒数
        /// </summary>
        [DataMember]
        [Column("default_timeout_seconds")]
        [Display(Name = "默认的超时秒数")]
        public int DefaultTimeoutSeconds { set; get; }



        /// <summary>
        /// 单个令牌，可访问次数限制（0为不限制）.
        /// </summary>
        [DataMember]
        [Column("access_able_times_limit")]
        [Display(Name = "单个令牌，可访问次数限制（0为不限制）")]
        public int AccessAbleTimesLimit { set; get; }



        /// <summary>
        /// 是否需要记录访问日志.
        /// </summary>
        [DataMember]
        [Column("is_require_access_log")]
        [Display(Name = "是否需要记录访问日志")]
        public bool IsRequireAccessLog { set; get; }




        #endregion 配置参数.







        #region 一对多.


        /// <summary>
        /// 令牌数据.
        /// </summary>
        public virtual List<TokenData> TokenDataList { set; get; }


        #endregion



    }
}
