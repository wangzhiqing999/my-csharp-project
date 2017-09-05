using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System.Data.Entity;
using System.Data.Entity.Migrations;


using MyChatRoom.DataAccess;
using MyChatRoom.Model;



namespace MyChatRoom.DataAccess.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            // 当 Code First 与数据库结构不一致时
            // 自动升级到最新的版本.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyChatRoomContext, MyChatRoom.Migrations.Configuration>());



            using (MyChatRoomContext context = new MyChatRoomContext())
            {

                var query =
                    from data in context.ChatRoomHouses
                    select
                        data;


                foreach (var house in query)
                {
                    Console.WriteLine(house.HouseID);
                }


            }


            Console.WriteLine("Finish!");
            Console.ReadLine();

        }
    }
}
