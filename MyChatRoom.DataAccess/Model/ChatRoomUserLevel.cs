using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace MyChatRoom.Model
{


    /// <summary>
    /// 用户等级
    /// </summary>
    [Serializable]
    [ToString]
    [Table("mcr_user_level")]
    public class ChatRoomUserLevel
    {

        /// <summary>
        /// 等级代码.
        /// </summary>
        [Column("user_level_code")]
        [Display(Name = "等级代码")]
        [Key]
        [StringLength(16)]
        public string UserLevelCode { set; get; }



        /// <summary>
        /// 等级名称
        /// </summary>
        [Column("user_level_name")]
        [Display(Name = "等级名称")]
        [StringLength(32)]
        public string UserLevelName { set; get; }


        /// <summary>
        /// 等级样式.
        /// </summary>
        [Column("user_level_css")]
        [Display(Name = "等级样式")]
        [StringLength(32)]
        public string UserLevelCss { set; get; }


        /// <summary>
        /// 等级图标.
        /// </summary>
        [Column("user_level_icon")]
        [Display(Name = "等级图标")]
        [StringLength(32)]
        public string UserLevelIcon { set; get; }



        /// <summary>
        /// 显示顺序.
        /// </summary>
        [Column("display_index")]
        [Display(Name = "显示顺序")]
        public int DisplayIndex { set; get; }









        #region  消息审核基本设置.

        // 消息审核优先级   用户个人设置 > 用户类型设置


        /// <summary>
        /// 直播室消息自动通过.
        /// </summary>
        [Column("msg_auto_pass")]
        [Display(Name = "直播室消息自动通过")]
        [StringLength(16)]
        public string ChatRoomMessageAutoPass { set; get; }



        /// <summary>
        /// 直播室消息需要关键字检查.
        /// </summary>
        [Column("msg_keyword_check")]
        [Display(Name = "直播室消息需要关键字检查")]
        [StringLength(16)]
        public string ChatRoomMessageNeedLimitedKeywordCheck { set; get; }


        #endregion  消息审核基本设置.







        #region 一对多.


        /// <summary>
        /// 用户列表.
        /// </summary>
        [IgnoreDuringToString]
        public virtual List<ChatRoomUser> UserList { set; get; }



        #endregion 一对多.


    }

}
