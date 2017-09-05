using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.Entity;

using MyChatRoom.Config;
using MyChatRoom.Model;




namespace MyChatRoom.DataAccess
{



    //  Enable-Migrations -ProjectName MyChatRoom.DataAccess  -EnableAutomaticMigrations
    public class MyChatRoomContext : DbContext
    {

        public MyChatRoomContext()
            : base("name=MyChatRoomContext")
        {
        }



        /// <summary>
        /// 房间页面.
        /// </summary>
        public DbSet<ChatRoomHousePage> ChatRoomHousePages { get; set; }


        /// <summary>
        /// 房间.
        /// </summary>
        public DbSet<ChatRoomHouse> ChatRoomHouses { get; set; }


        /// <summary>
        /// 用户等级.
        /// </summary>
        public DbSet<ChatRoomUserLevel> ChatRoomUserLevels { get; set; }



        /// <summary>
        /// 用户.
        /// </summary>
        public DbSet<ChatRoomUser> ChatRoomUsers { get; set; }


        /// <summary>
        /// 消息.
        /// </summary>
        public DbSet<ChatRoomMessage> ChatRoomMessages { get; set; }





        /// <summary>
        /// 指定如何创建 表的处理.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // 房间页面 配置信息.
            modelBuilder.Configurations.Add(new ChatRoomHousePageConfig());


            // 房间 配置信息.
            modelBuilder.Configurations.Add(new ChatRoomHouseConfig());


            // 用户等级 配置信息.
            modelBuilder.Configurations.Add(new ChatRoomUserLevelConfig());


            // 用户 配置信息.
            modelBuilder.Configurations.Add(new ChatRoomUserConfig());


            // 消息. 
            modelBuilder.Configurations.Add(new ChatRoomMessageConfig());


        }

    }

}
