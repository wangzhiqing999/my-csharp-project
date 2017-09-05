using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.Entity.ModelConfiguration;

using MyChatRoom.Model;



namespace MyChatRoom.Config
{

    /// <summary>
    /// 用户配置.
    /// </summary>
    class ChatRoomUserConfig : EntityTypeConfiguration<ChatRoomUser>
    {



        public ChatRoomUserConfig()
        {

            // 一个 用户  允许 发送多个 消息.
            this.HasMany(s => s.SendMessageDatas)
                // 一个 消息 必须属于 一个 发送的用户 .
                .WithRequired(m => m.MessageSender)
                // 外键的列是  MessageSenderId
                .HasForeignKey(m => m.MessageSenderId)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 用户 的操作比较少. 需要避免误操作)
                .WillCascadeOnDelete(false);


            // 一个 用户  允许 接收多个 消息.
            this.HasMany(s => s.ReceiveMessageDatas)
                // 一个 消息  可选属于 一个 接收的用户 .
                .WithOptional(m => m.MessageReceiver)
                // 外键的列是  MessageReceiverId
                .HasForeignKey(m => m.MessageReceiverId)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 用户 的操作比较少. 需要避免误操作)
                .WillCascadeOnDelete(false);


        }



    }
}
