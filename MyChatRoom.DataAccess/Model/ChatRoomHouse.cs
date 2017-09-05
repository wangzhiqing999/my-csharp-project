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
    /// 直播室房间.
    /// </summary>
    [Serializable]
    [ToString]
    [Table("mcr_house")]
    public class ChatRoomHouse
    {

        /// <summary>
        /// 房间代码.
        /// </summary>
        [Column("house_id")]
        [Display(Name = "房间代码")]
        [Key]
        [StringLength(32)]
        public string HouseID { set; get; }




        #region 一对多 （直播室房间页面）.

        /// <summary>
        /// 直播室房间页面代码.
        /// </summary>
        [Column("house_page_code")]
        [Display(Name = "直播室房间页面代码")]
        [StringLength(32)]
        public string HousePageCode { set; get; }



        /// <summary>
        /// 直播室房间页面
        /// </summary>
        [IgnoreDuringToString]
        public virtual ChatRoomHousePage HousePageData { set; get; }


        #endregion 一对多.



        /// <summary>
        /// 直播室媒体类型.
        /// </summary>
        [Column("media_type")]
        [Display(Name = "直播室媒体类型")]
        public HouseMediaType MediaType { set; get; }



        /// <summary>
        /// 直播室登录模式.
        /// </summary>
        [Column("login_mode")]
        [Display(Name = "直播室登录模式")]
        public HouseLoginMode LoginMode { set; get; }


        



        /// <summary>
        /// 房间名.
        /// </summary>
        [Column("house_name")]
        [Display(Name = "房间名")]
        [StringLength(32)]
        public string HouseName { set; get; }



        /// <summary>
        /// 房间介绍.
        /// </summary>
        [Column("house_desc")]
        [Display(Name = "房间介绍")]
        [StringLength(512)]
        public string HouseDesc { set; get; }



        /// <summary>
        /// 房间Logo
        /// </summary>
        [Column("house_logo")]
        [Display(Name = "房间Logo")]
        [StringLength(32)]
        public string HouseLogo { set; get; }




        /// <summary>
        /// 房间密码
        /// </summary>
        [Column("house_password")]
        [Display(Name = "房间密码")]
        [StringLength(128)]
        public string HousePassword { set; get; }





        /// <summary>
        /// 房间主视频地址.
        /// </summary>
        [Column("house_master_video_address")]
        [Display(Name = "房间主视频地址")]
        [StringLength(256)]
        public string HouseMasterVideoAddress { set; get; }




        /// <summary>
        /// 房间次视频地址.
        /// </summary>
        [Column("house_second_video_address")]
        [Display(Name = "房间次视频地址")]
        [StringLength(256)]
        public string HouseSecondVideoAddress { set; get; }






        #region  消息审核基本设置.


        /// <summary>
        /// 直播室消息自动通过.
        /// </summary>
        [Column("msg_auto_pass")]
        [Display(Name = "直播室消息自动通过")]
        [StringLength(16)]
        public string ChatRoomMessageAutoPass { set; get; }


        /// <summary>
        /// 是否自动通过.
        /// </summary>
        [NotMapped]
        public bool IsChatRoomMessageAutoPass
        {
            get
            {
                return this.ChatRoomMessageAutoPass == "ACTIVE";
            }
        }


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
        /// 该直播室房间的消息.
        /// </summary>
        [IgnoreDuringToString]
        public virtual List<ChatRoomMessage> MessageList { set; get; }


        #endregion 一对多.



    }







    /// <summary>
    /// 直播室房间类型.
    /// </summary>
    public enum HouseMediaType
    {

        /// <summary>
        /// 未设定.
        /// </summary>
        Unkonw = 0,


        /// <summary>
        /// 文字直播室.
        /// </summary>
        TextChatRoom = 1,


        /// <summary>
        /// 视频直播室.
        /// </summary>
        VideoChatRoom = 2,

    }




    /// <summary>
    /// 直播室房间登录模式.
    /// </summary>
    public enum HouseLoginMode
    {

        /// <summary>
        /// 未设定.
        /// </summary>
        Unkonw = 0,


        /// <summary>
        /// 不需要登录.
        /// </summary>
        None = 1,


        /// <summary>
        /// 使用房间密码登录.
        /// </summary>
        HousePassword = 2,


        /// <summary>
        /// 使用本地用户密码登录.
        /// </summary>
        LocalUserPassword = 4,


        /// <summary>
        /// 使用外部用户Token登录.
        /// </summary>
        RemoteUserToken = 8,
    }



}
