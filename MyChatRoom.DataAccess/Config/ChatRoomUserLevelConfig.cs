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
    /// 用户等级配置.
    /// </summary>
    class  ChatRoomUserLevelConfig : EntityTypeConfiguration<ChatRoomUserLevel>
    {

        public ChatRoomUserLevelConfig()
        {
            // 一个 等级  允许 多个 用户.
            this.HasMany(s => s.UserList)
                // 一个 用户 必须属于 一个 等级  .
                .WithRequired(m => m.UserLevel)
                // 外键的列是  UserLevelCode
                .HasForeignKey(m => m.UserLevelCode)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 等级 的操作比较少. 需要避免误操作)
                .WillCascadeOnDelete(false);
        }

    }

}
