using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

using Newtonsoft.Json;


using log4net;


using MyChatRoom.Model;
using MyChatRoom.Service;
using MyChatRoom.ServiceImpl;

using MyChatRoom.Mvc.Models;
using MyChatRoom.Mvc.Common;


namespace MyChatRoom.Mvc
{


    /// <summary>
    /// 消息 Hub.
    /// </summary>
    [HubName("messageService")]
    public class MyMessageHub : Hub
    {


        /// <summary>
        /// 房间列表.
        /// </summary>
        public static List<ChatRoomHouse> HouserList;


        static MyMessageHub()
        {
            // 获取 直播室 房间列表.
            IChatRoomHouseService chatRoomHouseService = new DefaultChatRoomHouseService();
            HouserList = chatRoomHouseService.GetChatRoomHouseList();
        }


        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);




        /// <summary>
        /// 用户列表.
        /// </summary>
        public static List<OnlineUser> UserList = new List<OnlineUser>();





        /// <summary>
        /// 房间服务.
        /// </summary>
        private IChatRoomHouseService chatRoomHouseService;


        /// <summary>
        /// 用户服务.
        /// </summary>
        private IChatRoomUserService chatRoomUserService;


        /// <summary>
        /// 聊天室消息服务.
        /// </summary>
        private IChatRoomMessageService chatRoomMessageService;






        /// <summary>
        /// 房间列表.
        /// </summary>
        private static List<ChatRoomHouse> chatRoomHouseList = new List<ChatRoomHouse>();






        public MyMessageHub()
        {
            this.chatRoomHouseService = new DefaultChatRoomHouseService();

            this.chatRoomUserService = new DefaultChatRoomUserService();

            this.chatRoomMessageService = new DefaultChatRoomMessageService();
        }


        public MyMessageHub(
            IChatRoomHouseService chatRoomHouseService,
            IChatRoomUserService chatRoomUserService,
            IChatRoomMessageService chatRoomMessageService)
        {

            logger.Debug("MyMessageHub ......");

            this.chatRoomHouseService = chatRoomHouseService;
            this.chatRoomUserService = chatRoomUserService;
            this.chatRoomMessageService = chatRoomMessageService;
            
        }








        #region  获取用户信息.


        /// <summary>
        /// 获取当前用户.
        /// </summary>
        /// <returns></returns>
        private ChatRoomUser GetCurrentChatRoomUser()
        {
            var webUser = Context.User;


            ChatRoomUser user = null;

            if (!webUser.Identity.IsAuthenticated)
            {
                // 未登录用户， 使用默认值.
                user = GetNewRandomUser();
            }
            else
            {
                // 已登录用户.
                user = this.chatRoomUserService.GetChatRoomUserByName(webUser.Identity.Name);


                if (user == null)
                {
                    logger.WarnFormat("尝试重新加载用户 {0} 的数据，结果加载失败！", webUser.Identity.Name);
                    user = GetNewRandomUser();
                }
            }
            return user;
        }


        /// <summary>
        /// 创建一个随机用户.
        /// </summary>
        /// <returns></returns>
        private ChatRoomUser GetNewRandomUser()
        {
            ChatRoomUser user = new ChatRoomUser()
            {
                UserID = 1,
                UserName = "Guest",
                UserNickName = GetRandomGuestCode(),
                IsAdmin = false,
            };

            return user;
        }



        /// <summary>
        /// 获取随机用户代码.
        /// </summary>
        /// <returns></returns>
        private string GetRandomGuestCode()
        {
            // 游客的情况下， 昵称需要追加 随机代码.

            // 通过Request对象读取得到Cookies的值
            HttpCookie newCookie = HttpContext.Current.Request.Cookies["ChatRoomUser"];

            if (newCookie != null)
            {
                string username = newCookie.Values["Name"];

                if (!String.IsNullOrEmpty(username))
                {
                    //3。如果不设置Expires属性，即为临时Cookie，浏览器关闭即消失
                    newCookie.Expires = DateTime.Now.AddDays(15);  //设置过期天数为15天

                    //4。写入Cookies集合
                    HttpContext.Current.Response.AppendCookie(newCookie);

                    return username;
                }
            }
            else
            {
                newCookie = new HttpCookie("ChatRoomUser");
            }

            Guid newValue = Guid.NewGuid();
            string result = newValue.ToString("N");
            // result = result.Substring(0, 8);

            //2。Cookie中添加信息项：为键值对，key/value
            newCookie.Values.Add("Name", result);

            //3。如果不设置Expires属性，即为临时Cookie，浏览器关闭即消失
            newCookie.Expires = DateTime.Now.AddDays(15);  //设置过期天数为15天

            //4。写入Cookies集合
            HttpContext.Current.Response.AppendCookie(newCookie);

            return result;
        }



        #endregion













        #region  链接/断开的事件



        /// <summary>
        /// 重写链接事件
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {

            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("聊天Hub：外部建立新连接 {0} OnConnected Start.", Context.ConnectionId);
            }


            // 查询用户。
            var user = UserList.SingleOrDefault(u => u.ContextID == Context.ConnectionId);


            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("尝试从 当前用户列表中， 查询当前连接用户 {0},  结果：{1}", Context.ConnectionId, user);
            }

            // 判断用户是否存在,否则添加进集合
            if (user == null)
            {
                ChatRoomUser chatRoomUser = GetCurrentChatRoomUser();
                user = new OnlineUser()
                {
                    // 用户ID.
                    UserID = chatRoomUser.UserID,
                    // 用户名
                    Name = chatRoomUser.UserName,
                    // 昵称.
                    NickName = chatRoomUser.UserNickName,
                    // 会话ID.
                    ContextID = Context.ConnectionId,

                    // 进入时间.
                    EnterTime = DateTime.Now,
                };



                lock (UserList)
                {
                    if (DateTime.Now.Hour == 8 && DateTime.Now.Minute < 10)
                    {
                        var query =
                        from data in UserList
                        where
                            data.EnterTime < DateTime.Now.AddDays(-1)
                        select
                            data;

                        List<OnlineUser> removeList = query.ToList();

                        foreach (var removeItem in removeList)
                        {
                            UserList.Remove(removeItem);
                        }
                    }

                    // 加入用户列表.
                    UserList.Add(user);
                }




                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("检测到当前连接用户 {0} 为新用户， 将其加入在线用户列表：{1}", Context.ConnectionId, user);
                }
            }



            if (logger.IsDebugEnabled)
            {
                logger.Debug("聊天Hub：外部建立新连接 OnConnected Finish!");
            }

            return base.OnConnected();
        }


        /// <summary>
        /// 重写断开的事件
        /// </summary>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {

            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("聊天Hub：外部断开连接 {0} OnDisconnected Start!", Context.ConnectionId);
            }


            // 查询用户.
            var user = UserList.Where(u => u.ContextID == Context.ConnectionId).FirstOrDefault();


            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("尝试从 当前用户列表中， 查询当前连接用户 {0},  结果：{1}", Context.ConnectionId, user);
            }


            // 判断用户是否存在,存在则删除
            if (user != null)
            {
                //删除用户
                UserList.Remove(user);
            }

            // 更新所有用户的列表
            UpdateUserCount(user);



            if (logger.IsDebugEnabled)
            {
                logger.Debug("聊天Hub：外部断开连接 OnDisconnected Finish!");
            }

            return base.OnDisconnected(stopCalled);
        }



        #endregion  链接/断开的事件










        #region 私有业务处理逻辑.


        /// <summary>
        /// 取得管理组代码.
        /// </summary>
        /// <param name="groupCode"></param>
        /// <returns></returns>
        private static string GetAdminGroupCode(string groupCode)
        {
            return String.Format("{0}_Admin", groupCode);
        }



        /// <summary>
        /// 更新用户的在线列表
        /// </summary>
        private void UpdateUserCount(OnlineUser user, bool reloadFlag = false)
        {
            if (user == null)
            {
                // 用户不存在. 忽略.
                return;
            }

            if (String.IsNullOrEmpty(user.RoomCode))
            {
                // 不知道属于哪一个房间的，忽略.
                return;
            }

            var query =
                from a in UserList
                where a.RoomCode == user.RoomCode
                select a;
            int userCount = query.Count();



            // 在线用户数，计算虚的.
            var house = chatRoomHouseList.FirstOrDefault(p => p.HouseID == user.RoomCode);
            int dummyUserCount = userCount;

            //if (house != null)
            //{
            //    dummyUserCount = Math.Abs(house.InitOnlineUserCount) + userCount * (1 + Math.Abs(house.InitUserStepNum));
            //}


            if (!reloadFlag)
            {
                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("尝试向 {0} 房间的用户， 通知 在线人数为 {1} 的处理. ", user.RoomCode, dummyUserCount);
                }

                // 通知 同一房间的人.
                Clients.Group(user.RoomCode).updateUserCount(dummyUserCount);




                string adminGroup = GetAdminGroupCode(user.RoomCode);

                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("尝试向 {0} 组的用户， 通知 在线人数为 {1} 的处理. ", adminGroup, userCount);
                }

                // 通知 管理员组， 真实用户数.
                Clients.Group(adminGroup).updateRealUserCount(userCount);

            }
            else
            {

                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("尝试向 {0} 用户， 通知 在线人数为 {1} 的处理. ", user.ContextID, dummyUserCount);
                }


                // 只通知当前用户.
                Clients.Client(user.ContextID).updateUserCount(dummyUserCount);
            }
        }



        #endregion 私有业务处理逻辑.








        #region 提供给客户调用的公共方法.




        /// <summary>
        /// 加入房间.
        /// </summary>
        /// <param name="roomCode"></param>
        public void InRoom(string roomCode)
        {
            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("InRoom {0} Start!", roomCode);
            }

            // 检查 roomCode 是否存在.
            if (!HouserList.Exists(p => p.HouseID == roomCode))
            {
                // 房间不存在，忽略.
                logger.WarnFormat("尝试进入不存在的房间 {0}", roomCode);
                return;
            }

            // 查询用户。
            OnlineUser user = UserList.SingleOrDefault(u => u.ContextID == Context.ConnectionId);

            if (user == null)
            {
                // 可能发生异常.
                logger.WarnFormat("不存在的用户 {0} 尝试进入的房间 {1}", Context.ConnectionId, roomCode);
                return;
            }



            // 设置用户所属房间.
            user.RoomCode = roomCode;

            // 将当前用户， 加入指定分组.
            Groups.Add(Context.ConnectionId, roomCode);


            // 更新用户的在线列表
            UpdateUserCount(user);


            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("InRoom {0} Finish!", roomCode);
            }




        }





        /// <summary>
        /// 管理员进入房间.
        /// </summary>
        /// <param name="roomCode"></param>
        public void AdminInRoom(string roomCode)
        {
            InRoom(roomCode);


            // 查询用户。
            OnlineUser user = UserList.SingleOrDefault(u => u.ContextID == Context.ConnectionId);

            // 非游客的情况下， 判断是不是管理员.
            if (user.UserID == 1)
            {
                // 可能发生异常.
                logger.WarnFormat("一个游客 {0}， 尝试以管理员的方式，进入房间 {1}", Context.ConnectionId, roomCode);
                return;
            }


            ChatRoomUser chatRoomUser = GetCurrentChatRoomUser();
            if (!chatRoomUser.IsAdmin)
            {
                // 可能发生错误.
                logger.WarnFormat("一个普通用户 {0}， 尝试以管理员的方式，进入房间 {1}", chatRoomUser.UserName, roomCode);


                Clients.Client(Context.ConnectionId).showErrorMessage("您没有管理员的权限!");

                return;
            }


            // 是管理员， 加入 “管理员组”
            Groups.Add(Context.ConnectionId, GetAdminGroupCode(roomCode));
        }







        #region  消息相关


        /// <summary>
        /// 发送消息.
        /// </summary>
        /// <param name="group"></param>
        /// <param name="message"></param>
        public void NewMessage(string group, string message, long? replyMessageId = null)
        {

            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("NewMessage ( {0}, {1}, {2} ) Start!", group, message, replyMessageId);
            }


            if (String.IsNullOrEmpty(message) || String.IsNullOrWhiteSpace(message))
            {
                Clients.Client(Context.ConnectionId).showErrorMessage("消息为空!");
                return;
            }

            message = message.Trim();
            message = message.Replace("\n", "<br/>\n");

            if (message.Length > 500)
            {
                Clients.Client(Context.ConnectionId).showErrorMessage("消息超长!");
                return;
            }



            // 取得当前用户.
            // 查询用户。
            var user = UserList.SingleOrDefault(u => u.ContextID == Context.ConnectionId);

            // 取得用户 ip地址.
            string ipAddress = IpGetter.GetIpAddress(HttpContext.Current.Request);


            // 匿名用户的情况下，需要检查黑名单.
            //if (user.UserID == 1)
            //{
            //    if (this.chatRoomBlackNameList.Contains(ipAddress))
            //    {
            //        // 在黑名单里面.
            //        Clients.Client(Context.ConnectionId).showErrorMessage("网络连接上存在一些问题，请稍候再尝试！");

            //        if (logger.IsInfoEnabled)
            //        {
            //            logger.InfoFormat("黑名单用户 {0}，尝试发送消息：{1} ", ipAddress, message);
            //        }
            //        return;
            //    }
            //}



            ChatRoomMessage chatroomMessage = new ChatRoomMessage()
            {
                // 房间ID.
                HouseID = group,

                // 发信人.
                MessageSenderId = user.UserID,

                // 发件人昵称.
                MessageSenderNickName = user.NickName,

                // 回复消息ID.
                ReplyMessageId = replyMessageId,

                // 消息内容.
                MessageContent = message,

                // IP.
                IpAddress = ipAddress,


                // 数据有效.
                IsActive = true,
            };


            string resultMsg = null;
            bool result = chatRoomMessageService.CreateNewMessage(chatroomMessage, ref resultMsg);

            if (!result)
            {
                // 消息发送失败.
                Clients.Client(Context.ConnectionId).showErrorMessage(resultMsg);
                return;
            }



            // 查询数据库中的指定消息， 目的， 查询出关联信息.
            ChatRoomMessage dbMsg = chatRoomMessageService.GetChatRoomMessage(chatroomMessage.MessageID);
            // 类型转换.
            var clientMsg = GetClientMessage(dbMsg);


            // 消息发送成功
            if (dbMsg.AuditingFlag == ChatRoomMessage.AUDITING_IS_PASS)
            {

                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("房间{0}, 用户{1}, 昵称{2}, 发送的消息{3}, 自动审核通过了！",
                        group, user.UserID, user.NickName, message);
                }


                // 调用 客户端的 showNewMessage 方法. 
                Clients.Group(group).showNewMessage(clientMsg);
            }
            else
            {
                // 需要审核的.

                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("房间{0}, 用户{1}, 昵称{2}, 发送的消息{3}, 等待审核通过！",
                        group, user.UserID, user.NickName, message);
                }


                // 调用 管理员组端的 showTodoMessage 方法. 
                Clients.Group(GetAdminGroupCode(group)).showTodoMessage(clientMsg);
            }


        }




        /// <summary>
        /// 发送图片消息.
        /// </summary>
        /// <param name="group"></param>
        /// <param name="messageID"></param>
        public void NewImageMessage(string group, long id)
        {
            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("NewImageMessage ( {0}, {1}) Start!", group, id);
            }

            if (id <= 0)
            {
                logger.WarnFormat("可能存在有恶意的用户， 尝试提交错误的 图片信息！ (id = {0})", id);
                return;
            }


            // 查询数据库中的指定消息， 目的， 查询出关联信息.
            ChatRoomMessage dbMsg = chatRoomMessageService.GetChatRoomMessage(id);

            if (dbMsg == null)
            {
                logger.WarnFormat("可能存在有恶意的用户， 尝试提交不存在的 图片信息！ (id = {0})", id);
                return;
            }

            // 类型转换.
            var clientMsg = GetClientMessage(dbMsg);


            // 消息发送成功
            if (dbMsg.AuditingFlag == ChatRoomMessage.AUDITING_IS_PASS)
            {
                // 调用 客户端的 showNewMessage 方法. 
                Clients.Group(group).showNewMessage(clientMsg);
            }
            else
            {
                // 需要审核的.
                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("房间{0}, 图片消息{1}, 等待审核通过！",
                        group, id);
                }

                // 调用 管理员组端的 showTodoMessage 方法. 
                Clients.Group(GetAdminGroupCode(group)).showTodoMessage(clientMsg);
            }



        }




        /// <summary>
        /// 取得 发送给最终用户的消息.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private MyChatRoomMessage GetClientMessage(ChatRoomMessage data)
        {
            MyChatRoomMessage result = new MyChatRoomMessage()
            {
                // 消息ID.
                MessageID = data.MessageID,

                // 发送时间.
                CreateTime = data.LastUpdateTime.ToString("t", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")),
                FullCreateTime = data.LastUpdateTime.ToString("yyyy-MM-dd HH:mm"),

                // 发送人.
                MessageSenderId = data.MessageSenderId,
                MessageSenderNickName = data.MessageSenderNickName,
                DisplayMessageSenderNickName = data.DisplayMessageSenderNickName,


                // 发送者头像
                MessageSenderPhoto = data.MessageSenderPhoto,

                // 是否是管理员.
                IsAdmin = data.MessageSender.IsAdmin,

                //// 发送人等级
                //UserLevelName = data.MessageSender.UserLevel.UserLevelName,
                //// 发送人等级图标.
                //UserLevelIcon = data.MessageSender.UserLevel.UserLevelIcon,


                // 接受人.
                DisplayMessageReceiverNickName = data.MessageReceiverId == null ? "" : data.DisplayMessageReceiverNickName,

                // 回复的消息内容.
                ReplyMessageContent = data.ReplyMessageId == null ? "" : data.ReplyMessage.MessageContent,



                // 图片标志.
                ImageFlag = data.ImageFlag,

                // 内容.
                MessageContent = data.MessageContent,

                // 审核状态.
                AuditingFlag = data.AuditingFlag,

                // ip.
                IpAddress = data.IpAddress,

            };

            return result;
        }





        /// <summary>
        /// 通过审核.
        /// </summary>
        /// <param name="group"></param>
        /// <param name="messageID"></param>
        public void PassMessage(string group, long messageID)
        {
            // 取得当前用户.
            // 查询用户。
            var user = GetCurrentChatRoomUser();

            // 取得用户 ip地址.
            string ipAddress = IpGetter.GetIpAddress(HttpContext.Current.Request);

            if (!user.IsAdmin)
            {
                Clients.Client(Context.ConnectionId).showErrorMessage("权限不足!");
                return;
            }


            string resultMsg = null;

            // 通过审核.
            bool result = chatRoomMessageService.PassMessage(messageID, user.DisplayUserNickName, ipAddress, ref resultMsg);

            if (!result)
            {
                // 失败的情况下.
                Clients.Client(Context.ConnectionId).showErrorMessage(resultMsg);
                return;
            }
            // 成功的情况下， 通知所有的 客户端， 显示消息.


            // 查询数据库中的指定消息， 目的， 查询出关联信息.
            ChatRoomMessage dbMsg = chatRoomMessageService.GetChatRoomMessage(messageID);
            // 类型转换.
            var clientMsg = GetClientMessage(dbMsg);


            // 调用 客户端的 showNewMessage 方法. 
            Clients.Group(group).showNewMessage(clientMsg);

            // 调用 管理员组的 PassMessageFinish(messageID) 方法. 
            Clients.Group(GetAdminGroupCode(group)).passMessageFinish(messageID);
        }



        /// <summary>
        /// 拒绝审核.
        /// </summary>
        /// <param name="group"></param>
        /// <param name="messageID"></param>
        public void RefuseMessage(string group, long messageID)
        {
            // 取得当前用户.
            // 查询用户。
            var user = GetCurrentChatRoomUser();

            // 取得用户 ip地址.
            string ipAddress = IpGetter.GetIpAddress(HttpContext.Current.Request);


            if (!user.IsAdmin)
            {
                Clients.Client(Context.ConnectionId).showErrorMessage("权限不足!");
                return;
            }

            string resultMsg = null;

            // 拒绝消息.
            bool result = chatRoomMessageService.RefuseMessage(messageID, user.DisplayUserNickName, ipAddress, ref resultMsg);

            if (!result)
            {
                // 失败的情况下.
                Clients.Client(Context.ConnectionId).showErrorMessage(resultMsg);
                return;
            }


            // 成功的情况下， 通知所有的 管理员组， 移除消息.

            // 调用 管理员组的 RefuseMessageFinish(messageID) 方法. 
            Clients.Group(GetAdminGroupCode(group)).refuseMessageFinish(messageID);
        }




        /// <summary>
        /// 移除消息.
        /// </summary>
        /// <param name="group"></param>
        /// <param name="messageID"></param>
        public void RemoveMessage(string group, long messageID)
        {
            // 取得当前用户.
            // 查询用户。
            var user = GetCurrentChatRoomUser();

            // 取得用户 ip地址.
            string ipAddress = IpGetter.GetIpAddress(HttpContext.Current.Request);


            if (!user.IsAdmin)
            {
                Clients.Client(Context.ConnectionId).showErrorMessage("权限不足!");
                return;
            }

            string resultMsg = null;

            // 拒绝消息.
            bool result = chatRoomMessageService.RefuseMessage(messageID, user.DisplayUserNickName, ipAddress, ref resultMsg);

            if (!result)
            {
                // 失败的情况下.
                Clients.Client(Context.ConnectionId).showErrorMessage(resultMsg);
                return;
            }

            // 成功的情况下， 通知所有的 客户端， 移除消息.

            // 调用 客户端的 removeMessage 方法. 
            Clients.Group(group).removeMessage(messageID);
        }



        #endregion  消息相关






        #endregion 提供给客户调用的公共方法.





    }
}