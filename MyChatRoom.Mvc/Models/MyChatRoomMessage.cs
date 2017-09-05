using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyChatRoom.Mvc.Models
{
    /// <summary>
    /// 直播室消息.
    /// </summary>
    public class MyChatRoomMessage
    {

        /// <summary>
        /// 消息 ID.
        /// </summary>
        public long MessageID { set; get; }


        /// <summary>
        /// 发送者ID.
        /// </summary>
        public long MessageSenderId { set; get; }


        /// <summary>
        /// 接收者ID.
        /// </summary>
        public long MessageReceiverId { set; get; }


        /// <summary>
        /// 发送者昵称.
        /// </summary>
        public string MessageSenderNickName { set; get; }

        /// <summary>
        /// 显示用 发送者昵称
        /// </summary>
        public string DisplayMessageSenderNickName { set; get; }


        /// <summary>
        /// 发送者头像.
        /// </summary>
        public string MessageSenderPhoto { set; get; }



        ///// <summary>
        ///// 发送者等级.
        ///// </summary>
        //public string UserLevelName { set; get; }


        ///// <summary>
        ///// 发送者等级图标.
        ///// </summary>
        //public string UserLevelIcon { set; get; }



        /// <summary>
        /// 是否是管理员.
        /// </summary>
        public bool IsAdmin { set; get; }



        /// <summary>
        /// 接收者昵称.
        /// </summary>
        public string DisplayMessageReceiverNickName { set; get; }


        /// <summary>
        /// 回复的消息内容.
        /// </summary>
        public string ReplyMessageContent { set; get; }




        /// <summary>
        /// 消息是否是图片.
        /// </summary>
        public bool ImageFlag { set; get; }


        /// <summary>
        /// 消息内容.
        /// </summary>
        public string MessageContent { set; get; }



        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { set; get; }
        public string FullCreateTime { set; get; }


        /// <summary>
        /// 审核标志
        /// </summary>
        public string AuditingFlag { set; get; }


        /// <summary>
        /// IP.
        /// </summary>
        public string IpAddress { set; get; }



        /// <summary>
        /// 所有者ID.
        /// </summary>
        public long OwnerID { set; get; }

    }
}