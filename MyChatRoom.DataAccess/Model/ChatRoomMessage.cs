using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



using MyFramework.Model;



namespace MyChatRoom.Model
{


    /// <summary>
    /// 直播室消息.
    /// </summary>
    [Serializable]
    [ToString]
    [Table("mcr_message")]
    public class ChatRoomMessage : AbstractCommonData
    {

        /// <summary>
        /// 消息 ID.
        /// </summary>
        [Column("message_id")]
        [Display(Name = "消息 ID")]
        [Key]
        public long MessageID { set; get; }






        #region  一对多 (与房间)

        /// <summary>
        /// 直播室房间代码.
        /// </summary>
        [Column("house_id")]
        [Display(Name = "直播室房间代码")]
        [StringLength(32)]
        [Required]
        public string HouseID { set; get; }



        /// <summary>
        /// 直播室房间.
        /// </summary>
        [IgnoreDuringToString]
        public virtual ChatRoomHouse House { set; get; }


        #endregion  一对多 (与房间)





        #region  一对多 (与回复)


        /// <summary>
        /// 回复消息ID.
        /// </summary>
        [Column("reply_message_id")]
        [Display(Name = "消息 ID")]
        public long? ReplyMessageId { set; get; }



        /// <summary>
        /// 本消息， 所回复的消息.
        /// </summary>
        [IgnoreDuringToString]
        public virtual ChatRoomMessage ReplyMessage { set; get; }



        /// <summary>
        /// 回复本消息的  消息列表.
        /// </summary>
        [IgnoreDuringToString]
        public virtual List<ChatRoomMessage> ReplyMeMessageList { set; get; }




        #endregion  一对多 (与回复)






        #region 一对多 （发送者 / 接收者）


        /// <summary>
        /// 消息发送者.
        /// </summary>
        [Column("message_sender")]
        [Display(Name = "消息发送者")]
        [Required]
        public long MessageSenderId { set; get; }

        /// <summary>
        /// 消息发送者.
        /// </summary>
        [IgnoreDuringToString]
        public virtual ChatRoomUser MessageSender { set; get; }


        /// <summary>
        /// 消息发送者昵称.
        /// </summary>
        [Column("message_sender_nickname")]
        [Display(Name = "消息发送者昵称")]
        [StringLength(32)]
        public string MessageSenderNickName { set; get; }


        /// <summary>
        /// 用于显示的 发送者昵称.
        /// </summary>
        [NotMapped]
        public string DisplayMessageSenderNickName
        {
            get
            {
                if (this.MessageSenderId != 1)
                {
                    // 不是 游客.
                    return this.MessageSenderNickName;
                }

                // 是游客.
                int messageLength = this.MessageSenderNickName.Length;
                if (messageLength < 8)
                {
                    // 数据可能有误.
                    return "游客" + this.MessageSenderNickName;
                }

                return "游客" + this.MessageSenderNickName.Substring(0, 4) + this.MessageSenderNickName.Substring(messageLength - 4);
            }
        }





        /// <summary>
        /// 发送者头像.
        /// </summary>
        [Column("message_sender_photo")]
        [Display(Name = "发送者头像")]
        [StringLength(512)]
        public string MessageSenderPhoto { set; get; }






        /// <summary>
        /// 接收者用户名.
        /// （为空的情况下， 表示 发送给聊天室全部用户的）
        /// </summary>
        [Column("message_receiver")]
        [Display(Name = "消息接收者")]
        public long? MessageReceiverId { set; get; }

        /// <summary>
        /// 消息接收者.
        /// </summary>
        [IgnoreDuringToString]
        public virtual ChatRoomUser MessageReceiver { set; get; }

        /// <summary>
        /// 消息接收者昵称.
        /// </summary>
        [Column("message_receiver_nickname")]
        [Display(Name = "消息接收者昵称")]
        [StringLength(32)]
        public string MessageReceiverNickName { set; get; }



        /// <summary>
        /// 用于显示的 消息接收者昵称.
        /// </summary>
        [NotMapped]
        public string DisplayMessageReceiverNickName
        {
            get
            {
                if (this.MessageReceiverId == null)
                {
                    // 全局消息，未指定  收件人.
                    return "";
                }

                if (this.MessageReceiverId != 1)
                {
                    // 不是 游客.
                    return this.MessageReceiverNickName;
                }

                // 是游客.
                int messageLength = this.MessageReceiverNickName.Length;
                if (messageLength < 8)
                {
                    // 数据可能有误.
                    return "游客" + this.MessageReceiverNickName;
                }

                return "游客" + this.MessageReceiverNickName.Substring(0, 4) + this.MessageReceiverNickName.Substring(messageLength - 4);
            }
        }



        #endregion 一对多 （发送者 / 接收者）





        /// <summary>
        /// 消息是否是图片.
        /// </summary>
        [Column("message_image_flag")]
        [Display(Name = "消息是否是图片")]
        public bool ImageFlag { set; get; }


        /// <summary>
        /// 消息内容.
        /// </summary>
        [Column("message_content")]
        [Display(Name = "消息内容")]
        [Required]
        public string MessageContent { set; get; }



        /// <summary>
        /// IP地址
        /// </summary>
        [Column("ip_address")]
        [Display(Name = "IP地址")]
        [StringLength(32)]
        public string IpAddress { set; get; }





        /// <summary>
        /// 审核标志.
        /// </summary>
        [Column("auditing_flag")]
        [Display(Name = "审核标志")]
        [StringLength(16)]
        public string AuditingFlag { set; get; }





        /// <summary>
        /// 待审核. 
        /// </summary>
        public const string AUDITING_IS_WAIT = "WAIT";

        /// <summary>
        /// 审核通过. 
        /// </summary>
        public const string AUDITING_IS_PASS = "PASS";


        /// <summary>
        /// 审核拒绝.
        /// </summary>
        public const string AUDITING_IS_REFUSE = "REFUSE";

        /// <summary>
        /// 审核通过.
        /// </summary>
        public void AuditingPass()
        {
            this.AuditingFlag = AUDITING_IS_PASS;
        }

        /// <summary>
        /// 审核拒绝.
        /// </summary>
        public void AuditingRefuse()
        {
            this.AuditingFlag = AUDITING_IS_REFUSE;
        }




        /// <summary>
        /// 审核人.
        /// </summary>
        [Column("auditing_user")]
        [Display(Name = "审核人")]
        [StringLength(64)]
        public string AuditingBy { set; get; }

        /// <summary>
        /// 审核IP.
        /// </summary>
        [Column("auditing_ip")]
        [Display(Name = "审核IP.")]
        [StringLength(64)]
        public string AuditingIp { set; get; }



    }
}
