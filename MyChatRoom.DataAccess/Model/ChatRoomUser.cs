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
    /// 直播室用户.
    /// </summary>
    [Serializable]
    [ToString]
    [Table("mcr_user")]
    public class ChatRoomUser
    {

        /// <summary>
        /// 用户ID.
        /// </summary>
        [Column("user_id")]
        [Display(Name = "用户ID")]
        [Key]
        public long UserID { set; get; }




        #region  一对多  用户等级



        /// <summary>
        /// 等级代码.
        /// </summary>
        [Column("user_level_code")]
        [Display(Name = "等级代码")]
        [StringLength(16)]
        public string UserLevelCode { set; get; }




        /// <summary>
        /// 用户等级.
        /// </summary>
        [IgnoreDuringToString]
        public virtual ChatRoomUserLevel UserLevel { set; get; }



        #endregion  一对多  用户等级







        /// <summary>
        /// 用户名.
        /// </summary>
        [Column("user_name")]
        [Display(Name = "用户名")]
        [StringLength(32)]
        public string UserName { set; get; }


        /// <summary>
        /// 用户昵称.
        /// </summary>
        [Column("user_nick_name")]
        [Display(Name = "用户昵称")]
        [StringLength(32)]
        public string UserNickName { set; get; }

        /// <summary>
        /// 昵称数据检查.
        /// </summary>
        /// <param name="nickName"></param>
        /// <returns></returns>
        public static bool UserNickNameCheck(string nickName, ref string resultMessage)
        {
            if (String.IsNullOrEmpty(nickName))
            {
                resultMessage = "昵称不能为空";
                return false;
            }

            if (nickName.Contains(" "))
            {
                resultMessage = "昵称中不能包含空格！";
                return false;
            }

            foreach (char c in nickName)
            {
                if (Char.IsPunctuation(c))
                {
                    resultMessage = "昵称中不能使用标点符号！";
                    return false;
                }

                if (Char.IsSymbol(c))
                {
                    resultMessage = "昵称中不能使用标点符号！";
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// 用于显示的 用户昵称.
        /// </summary>
        [NotMapped]
        public string DisplayUserNickName
        {
            get
            {
                if (this.UserID != 1)
                {
                    // 不是 游客.
                    return this.UserNickName;
                }

                // 是游客.
                int messageLength = this.UserNickName.Length;
                if (messageLength < 8)
                {
                    // 数据可能有误.
                    return "游客" + this.UserNickName;
                }

                return "游客" + this.UserNickName.Substring(0, 4) + this.UserNickName.Substring(messageLength - 4);
            }
        }




        /// <summary>
        /// 用户头像.
        /// </summary>
        [Column("user_photo")]
        [Display(Name = "用户头像")]
        [StringLength(512)]
        public string UserPhoto { set; get; }





        /// <summary>
        /// 用户密码
        /// </summary>
        [Column("user_password")]
        [Display(Name = "用户密码")]
        [StringLength(512)]
        public string UserPassword { set; get; }



        /// <summary>
        /// 用户输入的密码.
        /// </summary>
        [Display(Name = "用户密码")]
        [NotMapped]
        public string UserInputPassword { set; get; }



        /// <summary>
        /// 是否是管理员
        /// </summary>
        [Column("is_admin")]
        [Display(Name = "是否是管理员")]
        public bool IsAdmin { set; get; }



        /// <summary>
        /// 是否被禁言.
        /// </summary>
        [Column("is_gag")]
        [Display(Name = "是否被禁言")]
        public bool IsGag { set; get; }




        #region 一对多 (与消息).


        /// <summary>
        /// 用户发的消息.
        /// </summary>
        [IgnoreDuringToString]
        public virtual List<ChatRoomMessage> SendMessageDatas { set; get; }



        /// <summary>
        /// 用户收到的消息.
        /// </summary>
        [IgnoreDuringToString]
        public virtual List<ChatRoomMessage> ReceiveMessageDatas { set; get; }




        #endregion 一对多 (与消息).









        #region  消息审核基本设置.


        // 消息审核优先级  用户个人设置 > 用户类型设置


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







        /// <summary>
        /// 是否自动通过.
        /// </summary>
        [NotMapped]
        public bool IsAutoPass
        {
            get
            {
                if (this.IsAdmin)
                {
                    //  管理员， 自动通过.
                    return true;
                }

                if (this.ChatRoomMessageAutoPass == "ACTIVE")
                {
                    // 属性中配置了  指定用户：直播室消息自动通过
                    return true;
                }

                if (String.IsNullOrEmpty(this.ChatRoomMessageAutoPass))
                {
                    // 自己未配置的情况下， 尝试检测 用户分类的配置.
                    if (this.UserLevel != null && this.UserLevel.ChatRoomMessageAutoPass == "ACTIVE")
                    {
                        // 属性中配置了  指定用户等级： 直播室消息自动通过
                        return true;
                    }
                }

                // 其他情况， 认为不自动通过.
                return false;
            }
        }




        /// <summary>
        /// 是否敏感词检查.
        /// </summary>
        [NotMapped]
        public bool IsLimitedKeywordCheck
        {
            get
            {

                if (this.IsAdmin)
                {
                    //  管理员， 不检查.
                    return false;
                }


                if (this.ChatRoomMessageNeedLimitedKeywordCheck == "ACTIVE")
                {
                    // 属性中配置了  指定用户：需要检查关键字.
                    return true;
                }


                if (String.IsNullOrEmpty(this.ChatRoomMessageNeedLimitedKeywordCheck))
                {
                    // 自己未配置的情况下， 尝试检测 用户分类的配置.
                    if (this.UserLevel != null && this.UserLevel.ChatRoomMessageNeedLimitedKeywordCheck == "ACTIVE")
                    {
                        // 属性中配置了  指定用户等级： 需要检查关键字
                        return true;
                    }
                }

                // 其他情况， 认为不检查.
                return false;
            }
        }




    }


}
