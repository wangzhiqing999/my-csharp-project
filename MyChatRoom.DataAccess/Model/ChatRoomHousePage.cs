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
    /// 直播室房间页面.
    /// </summary>
    [Serializable]
    [ToString]
    [Table("mcr_house_page")]
    public class ChatRoomHousePage
    {

        /// <summary>
        /// 房间页面代码.
        /// </summary>
        [Column("house_page_code")]
        [Display(Name = "房间页面代码")]
        [Key]
        [StringLength(32)]
        public string HousePageCode { set; get; }




        /// <summary>
        /// 房间页面名称.
        /// </summary>
        [Column("house_page_name")]
        [Display(Name = "房间页面名称")]
        [StringLength(32)]
        public string HousePageName { set; get; }



        /// <summary>
        /// 房间页面描述.
        /// </summary>
        [Column("house_page_desc")]
        [Display(Name = "房间页面描述")]
        [StringLength(32)]
        public string HousePageDesc { set; get; }






        /// <summary>
        /// 房间页面路径.
        /// </summary>
        [Column("house_page_path")]
        [Display(Name = "房间页面路径")]
        [StringLength(256)]
        public string HousePagePath { set; get; }



        /// <summary>
        /// 房间页面路径(手机页面).
        /// </summary>
        [Column("house_page_path_phone")]
        [Display(Name = "房间页面路径(手机页面)")]
        [StringLength(256)]
        public string HousePagePathPhone { set; get; }






        #region 一对多.



        /// <summary>
        /// 使用本页面的房间.
        /// </summary>
        [IgnoreDuringToString]
        public virtual List<ChatRoomHouse> HouseList { set; get; }


        #endregion 一对多.



    }


}
