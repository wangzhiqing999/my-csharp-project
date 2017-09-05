using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MyChatRoom.Model;



namespace MyChatRoom.Service
{

    /// <summary>
    /// 直播室消息服务.
    /// </summary>
    public interface IChatRoomMessageService
    {

        /// <summary>
        /// 创建一个消息.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        bool CreateNewMessage(ChatRoomMessage message, ref string resultMsg);




        /// <summary>
        /// 审核通过消息
        /// </summary>
        /// <param name="messageID"></param>
        /// <param name="user"></param>
        /// <param name="ip"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        bool PassMessage(long messageID, string user, string ip, ref string resultMsg);



        /// <summary>
        /// 审核拒绝消息
        /// </summary>
        /// <param name="messageID"></param>
        /// <param name="user"></param>
        /// <param name="ip"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        bool RefuseMessage(long messageID, string user, string ip, ref string resultMsg);





        /// <summary>
        /// 取得指定房间的消息列表
        /// </summary>
        /// <param name="houseID"></param>
        /// <param name="auditingFlag"></param>
        /// <param name="lastID"></param>
        /// <param name="lastN"></param>
        /// <param name="nearMin"></param>
        /// <returns></returns>
        List<ChatRoomMessage> GetChatRoomMessageList(string houseID, string auditingFlag = null, long lastID = 0, int lastN = 50, int nearMin = 120);



        /// <summary>
        /// 取得指定消息.
        /// </summary>
        /// <param name="msgId"></param>
        /// <returns></returns>
        ChatRoomMessage GetChatRoomMessage(long msgId);



        /// <summary>
        /// 取得我的消息.
        /// </summary>
        /// <param name="houseID"></param>
        /// <param name="userID"></param>
        /// <param name="userNickName"></param>
        /// <returns></returns>
        List<ChatRoomMessage> GetMyChatRoomMessageList(string houseID, long userID, string userNickName);

    }
}
