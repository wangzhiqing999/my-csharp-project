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
    /// 直播室房间 配置.
    /// </summary>
    public class ChatRoomHouseConfig : EntityTypeConfiguration<ChatRoomHouse>
    {

        public ChatRoomHouseConfig()
        {
            // 一个 直播室房间  允许 多个 直播室消息
            this.HasMany(s => s.MessageList)
                // 一个 直播室消息 必须 指定 一个 直播室房间 .
                .WithRequired(m => m.House)
                // 外键的列是  HouseID
                .HasForeignKey(m => m.HouseID)
                // 打开 外键的 ON DELETE CASCADE 
                // 删除直播室的情况下， 自动删除该直播室的消息.
                .WillCascadeOnDelete(true);
        }

    }
}
