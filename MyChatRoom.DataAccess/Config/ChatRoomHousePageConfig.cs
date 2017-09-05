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
    /// 直播室房间页面 配置.
    /// </summary>
    class ChatRoomHousePageConfig : EntityTypeConfiguration<ChatRoomHousePage>
    {

        public ChatRoomHousePageConfig()
        {
            // 一个 直播室房间页面  允许 多个 直播室房间使用
            this.HasMany(s => s.HouseList)
                // 一个 直播室房间 可选 指定 一个 直播室房间页面 .
                // （也就是初始创建的时候， 允许暂时先不指定页面， 等后面确定后， 再指定）
                .WithOptional(m => m.HousePageData)
                // 外键的列是  HousePageCode
                .HasForeignKey(m => m.HousePageCode)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 房间页面， 就把直播室删除的话， 会出一些问题. 需要避免误操作)
                .WillCascadeOnDelete(false);
        }

    }
}
