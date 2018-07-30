using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Runtime.Serialization;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace MyAccessStatistics.Model
{

    /// <summary>
    /// 访问明细日志.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("mas_access_detail_log")]
    public class AccessDetailLog
    {



        /// <summary>
        /// 访问明细日志流水.
        /// </summary>
        [DataMember]
        [Column("access_log_id")]
        [Display(Name = "访问明细日志流水")]
        [Key]
        public long LogID { set; get; }




        #region 一对多.


        /// <summary>
        /// 访问类型代码.
        /// </summary>
        [DataMember]
        [Column("access_type_code")]
        [Display(Name = "访问类型代码")]
        [StringLength(32)]
        public string AccessTypeCode { set; get; }



        /// <summary>
        /// 访问类型数据.
        /// </summary>
        public virtual AccessType AccessTypeData { set; get; }


        #endregion 一对多.




        /// <summary>
        /// 明细代码.
        /// </summary>
        [DataMember]
        [Column("detail_code")]
        [Display(Name = "明细代码")]
        [StringLength(32)]
        public string DetailCode { set; get; }




        /// <summary>
        /// 访问时间
        /// </summary>
        [DataMember]
        [Column("access_time")]
        [Display(Name = "访问时间")]
        public DateTime AccessTime { set; get; }



        /// <summary>
        /// 扩展信息.
        /// </summary>
        [DataMember]
        [Column("exp_info")]
        [Display(Name = "扩展信息")]
        public string ExpInfo { set; get; }




    
        // 这里的用户代码是新增的列
        // 目的是用于明确 具体的用户， 具体在什么时间点上，访问了哪些模块。
        // 最初的计划，是将用户代码，与其他附加的数据，以 json 的格式，存储在 ExpInfo 列的。
        // 但是，如果遇到有特殊/复杂的业务需求，需要查询特定用户的具体操作。
        // 查询起来，用 like 操作，效率就底下了.
        // 例如，某个 业务员， 需要查询， 归属于他的 客户的  相关业务操作。
        // 如果有10个 客户.
        // exp_info like '%客户代码1%' OR exp_info like '%客户代码2%' ...
        // 执行起来，效率实在是太感人了.


        // 这里是例子代码。 用户代码的数据类型是 long?
        // 也就是 已经登录的用户， 能够记录具体操作。
        // 未登录的用户， 也能记录具体操作。

        // 使用到实际的项目中去的时候， 需要把下面的 用户代码 的数据类型
        // 修改成 主系统中， 具体的 用户代码的数据类型。

        // 当前模块，仅仅完成记录日志的操作。
        // 不判断用户的有效性， 以及 用户归属于哪个业务员这样的操作。

        /// <summary>
        /// 用户代码.
        /// </summary>
        [DataMember]
        [Column("user_id")]
        [Display(Name = "用户代码")]
        public long? UserID { set; get; }



    }


}
