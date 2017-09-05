using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MyChatRoom.Model;



namespace MyChatRoom.Service
{


    /// <summary>
    /// 直播室房间服务.
    /// </summary>
    public interface IChatRoomHouseService
    {

        
        /// <summary>
        /// 取得房间列表.
        /// </summary>
        /// <returns></returns>
        List<ChatRoomHouse> GetChatRoomHouseList();



        /// <summary>
        /// 取得房间信息.
        /// </summary>
        /// <param name="houseCode"></param>
        /// <returns></returns>
        ChatRoomHouse GetChatRoomHouse(string houseCode);




        /// <summary>
        /// 文字直播室房间列表.
        /// </summary>
        /// <returns></returns>
        List<ChatRoomHouse> GetTextChatRoomHouseList();



        /// <summary>
        /// 视频直播室房间列表.
        /// </summary>
        /// <returns></returns>
        List<ChatRoomHouse> GetVideoChatRoomHouseList();
    }
}
