using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyChatRoom.Model;



namespace MyChatRoom.Service
{

    /// <summary>
    /// 直播室用户服务.
    /// </summary>
    public interface IChatRoomUserService
    {





        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        bool Login(string userName, string password, ref string resultMsg);





        /// <summary>
        /// 取得用户类型.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        ChatRoomUserLevel GetChatRoomUserLevelByCode(string code);



        /// <summary>
        /// 取得用户.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        ChatRoomUser GetChatRoomUserByName(string userName);


        /// <summary>
        /// 取得用户.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        ChatRoomUser GetChatRoomUser(long userID);




        /// <summary>
        /// 创建或更新用户
        /// </summary>
        /// <param name="userData"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        bool InsertOrUpdateChatRoomUser(ChatRoomUser userData, ref string resultMsg);




    }


}
