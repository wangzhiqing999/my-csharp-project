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
    /// 消息 配置
    /// </summary>
    class ChatRoomMessageConfig : EntityTypeConfiguration<ChatRoomMessage>
    {

        public ChatRoomMessageConfig()
        {
            // 一个 消息  允许 被多个  消息 所回复.
            this.HasMany(s => s.ReplyMeMessageList)
                // 一个 消息  可选  回复一个 消息 .
                .WithOptional(m => m.ReplyMessage)
                // 外键的列是  ReplyMessageId
                .HasForeignKey(m => m.ReplyMessageId)
                // 关闭 外键的 ON DELETE CASCADE 
                .WillCascadeOnDelete(false);
        }



    }
}
