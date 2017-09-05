using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MyChatRoom.Mvc.Models
{

    /// <summary>
    /// 在线用户.
    /// </summary>
    public class OnlineUser
    {


        /// <summary>
        /// 在线用户 ContextID
        /// </summary>
        public string ContextID { get; set; }



        /// <summary>
        /// 用户ID.
        /// </summary>
        public long UserID { set; get; }

        /// <summary>
        /// 用户IP.
        /// </summary>
        public string UserIp { set; get; }



        /// <summary>
        /// 在线用户名.
        /// </summary>
        public string Name { get; set; }




        /// <summary>
        /// 用户昵称.
        /// </summary>
        public string NickName { get; set; }


        /// <summary>
        /// 用于显示的 用户昵称.
        /// </summary>
        public string DisplayUserNickName
        {
            get
            {
                if (this.UserID != 1)
                {
                    // 不是 游客.
                    return this.NickName;
                }

                // 是游客.
                int messageLength = this.NickName.Length;
                if (messageLength < 8)
                {
                    // 数据可能有误.
                    return "游客" + this.NickName;
                }

                return "游客" + this.NickName.Substring(0, 4) + this.NickName.Substring(messageLength - 4);
            }
        }



        /// <summary>
        /// 所在房间代码.
        /// </summary>
        public string RoomCode { set; get; }




        /// <summary>
        /// 进入时间.
        /// </summary>
        public DateTime EnterTime { set; get; }





        public override string ToString()
        {
            StringBuilder buff = new StringBuilder("在线用户 : [");


            buff.AppendFormat("ContextID = {0}; ", this.ContextID);
            buff.AppendFormat("UserID = {0}; ", this.UserID);
            buff.AppendFormat("UserIp = {0}; ", this.UserIp);
            buff.AppendFormat("Name = {0}; ", this.Name);
            buff.AppendFormat("NickName = {0}; ", this.NickName);

            buff.AppendFormat("RoomCode = {0}; ", this.RoomCode);

            buff.Append("]");

            return buff.ToString();
        }




    }
}