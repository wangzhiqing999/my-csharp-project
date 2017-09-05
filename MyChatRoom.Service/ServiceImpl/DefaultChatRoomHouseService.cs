using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyChatRoom.Model;
using MyChatRoom.DataAccess;
using MyChatRoom.Service;


namespace MyChatRoom.ServiceImpl
{

    public class DefaultChatRoomHouseService : BaseService, IChatRoomHouseService
    {



        /// <summary>
        /// 取得房间列表.
        /// </summary>
        /// <returns></returns>
        public List<ChatRoomHouse> GetChatRoomHouseList()
        {
            using (MyChatRoomContext context = new MyChatRoomContext())
            {
                var query =
                    from data in context.ChatRoomHouses
                    select data;

                var resultList = query.ToList();

                return resultList;
            }
        }



        /// <summary>
        /// 取得房间信息.
        /// </summary>
        /// <param name="houseCode"></param>
        /// <returns></returns>
        public ChatRoomHouse GetChatRoomHouse(string houseCode)
        {
            using (MyChatRoomContext context = new MyChatRoomContext())
            {
                ChatRoomHouse result = context.ChatRoomHouses.Include("HousePageData").FirstOrDefault(p => p.HouseID == houseCode);
                return result;
            }
        }




        /// <summary>
        /// 文字直播室房间列表.
        /// </summary>
        /// <returns></returns>
        public List<ChatRoomHouse> GetTextChatRoomHouseList()
        {
            using (MyChatRoomContext context = new MyChatRoomContext())
            {
                var query =
                    from data in context.ChatRoomHouses
                    where
                        data.MediaType == HouseMediaType.TextChatRoom
                    select data;

                var resultList = query.ToList();

                return resultList;
            }
        }



        /// <summary>
        /// 视频直播室房间列表.
        /// </summary>
        /// <returns></returns>
        public List<ChatRoomHouse> GetVideoChatRoomHouseList()
        {
            using (MyChatRoomContext context = new MyChatRoomContext())
            {
                var query =
                    from data in context.ChatRoomHouses
                    where
                        data.MediaType == HouseMediaType.VideoChatRoom
                    select data;

                var resultList = query.ToList();

                return resultList;
            }
        }





    }

}
