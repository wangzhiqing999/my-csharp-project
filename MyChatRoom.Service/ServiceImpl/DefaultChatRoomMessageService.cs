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
    public class DefaultChatRoomMessageService : BaseService, IChatRoomMessageService
    {


        /// <summary>
        /// 两条短消息之间的间隔 秒数.
        /// </summary>
        public static int TwoMessageSecondLimit = 5;



        /// <summary>
        /// 创建一个消息.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public bool CreateNewMessage(ChatRoomMessage message, ref string resultMsg)
        {
            bool result = false;

            try
            {
                using (MyChatRoomContext context = new MyChatRoomContext())
                {
                    // 检查 发消息用户.
                    ChatRoomUser user = context.ChatRoomUsers.Find(message.MessageSenderId);

                    if (user == null)
                    {
                        resultMsg = String.Format("用户 {0} 不存在！", message.MessageSenderId);
                        return result;
                    }


                    if (user.IsGag)
                    {
                        resultMsg = String.Format("用户 {0} 已经被禁言！", user.UserName);
                        return result;
                    }




                    // 如果指定了 接受者， 那么检查是否存在.
                    if (message.MessageReceiverId != null)
                    {
                        ChatRoomUser userTo = context.ChatRoomUsers.Find(message.MessageReceiverId);

                        if (userTo == null)
                        {
                            resultMsg = String.Format("用户 {0} 不存在！", message.MessageReceiverId);
                            return result;
                        }
                    }


                    // 如果指定了 回复消息。 检查 回复消息是否存在.
                    if (message.ReplyMessageId != null)
                    {
                        ChatRoomMessage replyMessag = context.ChatRoomMessages.Find(message.ReplyMessageId.Value);
                        if (replyMessag == null)
                        {
                            resultMsg = String.Format("回复的消息 {0} 不存在！", message.ReplyMessageId);
                            return result;
                        }

                        // 填写回复的  用户ID 与 昵称.
                        message.MessageReceiverId = replyMessag.MessageSenderId;
                        message.MessageReceiverNickName = replyMessag.MessageSenderNickName;
                    }



                    // 获取消息发送的房间.
                    var house = context.ChatRoomHouses.Find(message.HouseID);
                    if (house == null)
                    {
                        resultMsg = String.Format("直播室房间 {0} 不存在！", message.HouseID);
                        return result;
                    }

                    // 判断指定房间， 消息是否需要审核.
                    if (house.IsChatRoomMessageAutoPass)
                    {
                        // 直播室房间， 自动审核通过.
                        message.AuditingPass();

                        message.AuditingIp = "-";
                        message.AuditingBy = "AUTO";
                    }
                    else
                    {
                        // 直播室房间， 要求审核.

                        // 检查用户的属性.
                        if (user.IsAutoPass)
                        {
                            // 帐户能够直接审核通过.
                            message.AuditingPass();

                            message.AuditingIp = "-";
                            message.AuditingBy = "AUTO";
                        }
                        else
                        {
                            // 待审核.
                            message.AuditingFlag = "WAIT";
                        }
                    }


                    // 发送者头像， 按照用户等级来处理.
                    message.MessageSenderPhoto = "/images/level/" + user.UserLevel.UserLevelIcon;


                    // 发信人昵称.
                    if (String.IsNullOrEmpty(message.MessageSenderNickName))
                    {
                        message.MessageSenderNickName = user.UserNickName;
                    }



                    // 当前时间 - 两条短消息之间的间隔 秒数.
                    DateTime disableTime = DateTime.Now.AddSeconds(-1 * TwoMessageSecondLimit);

                    // 两条短消息之间的间隔 秒数.
                    var prevMessageQuery =
                        from data in context.ChatRoomMessages
                        where
                            // 同一 发送人.
                            data.MessageSenderId == message.MessageSenderId
                            && data.MessageSenderNickName == message.MessageSenderNickName
                            // 仅仅判断今天的.
                            && data.CreateTime > disableTime
                        orderby
                            data.CreateTime descending
                        select data;


                    if (prevMessageQuery.Count() > 0)
                    {
                        // 存在有重复提交的情况.
                        resultMsg = "您消息发送得太频繁了......";
                        return result;
                    }


                    message.BeforeInsertOperation("Web");

                    // 插入.
                    context.ChatRoomMessages.Add(message);


                    // 物理保存.
                    context.SaveChanges();

                    // 如果能执行到这里， 认为处理成功.
                    result = true;
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbErr)
            {
                logger.Info(message);

                foreach (var errItem in dbErr.EntityValidationErrors)
                {
                    foreach (var err in errItem.ValidationErrors)
                    {
                        logger.InfoFormat("{0} : {1}", err.PropertyName, err.ErrorMessage);
                    }
                }

                logger.Error(dbErr.Message, dbErr);
                result = false;
                resultMsg = dbErr.Message;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                result = false;
                resultMsg = ex.Message;
            }
            return result;
        }




        public bool PassMessage(long messageID, string user, string ip, ref string resultMsg)
        {
            bool result = false;

            try
            {
                using (MyChatRoomContext context = new MyChatRoomContext())
                {

                    ChatRoomMessage message = context.ChatRoomMessages.Find(messageID);

                    if (message == null)
                    {
                        resultMsg = String.Format("消息 {0} 不存在！", messageID);
                        return result;
                    }

                    message.AuditingBy = user;
                    message.AuditingIp = ip;

                    message.AuditingPass();
                    message.BeforeUpdateOperation(user);


                    // 物理保存.
                    context.SaveChanges();

                    // 如果能执行到这里， 认为处理成功.
                    result = true;
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                result = false;
                resultMsg = ex.Message;
            }
            return result;
        
        }

        public bool RefuseMessage(long messageID, string user, string ip, ref string resultMsg)
        {
            bool result = false;

            try
            {
                using (MyChatRoomContext context = new MyChatRoomContext())
                {


                    ChatRoomMessage message = context.ChatRoomMessages.Find(messageID);

                    if (message == null)
                    {
                        resultMsg = String.Format("消息 {0} 不存在！", messageID);
                        return result;
                    }


                    message.AuditingBy = user;
                    message.AuditingIp = ip;

                    message.AuditingRefuse();
                    message.BeforeUpdateOperation(user);



                    // 物理保存.
                    context.SaveChanges();

                    // 如果能执行到这里， 认为处理成功.
                    result = true;
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                result = false;
                resultMsg = ex.Message;
            }
            return result;
        }




        public List<ChatRoomMessage> GetChatRoomMessageList(string houseID, string auditingFlag = null, long lastID = 0, int lastN = 50, int nearMin = 120)
        {
            using (MyChatRoomContext context = new MyChatRoomContext())
            {

                // 只查询 最近2小时的数据.
                DateTime minDateTime = DateTime.Now.AddMinutes(-1 * nearMin);


                var query =
                    from data in context.ChatRoomMessages
                        .Include("MessageSender.UserLevel").Include("ReplyMessage")
                    where
                        // 有效数据.
                        data.Status == ChatRoomMessage.STATUS_IS_ACTIVE
                        // 指定房间.
                        && data.HouseID == houseID
                        // 时间范围.
                        && data.LastUpdateTime > minDateTime
                    // 仅仅获取 全部的消息，忽略点对点消息。
                    // && data.MessageReceiverId == null
                    select data;



                // 最近一条消息.
                if (lastID > 0)
                {
                    ChatRoomMessage lastData = context.ChatRoomMessages.Find(lastID);

                    if (lastData != null)
                    {
                        // 最近一条数据存在.
                        DateTime lastDateTime = lastData.LastUpdateTime;
                        query = query.Where(p => p.LastUpdateTime >= lastDateTime && p.MessageID != lastID);
                    }
                }


                // 审核标志.
                if (auditingFlag != null)
                {
                    query = query.Where(p => p.AuditingFlag == auditingFlag);
                }

                // 创建时间逆序.
                query = query.OrderByDescending(p => p.LastUpdateTime);


                // 查询.
                List<ChatRoomMessage> resultList = query.Take(lastN).ToList();


                // 顺序反转. 
                // 查询的时候， 是时间逆序， 取前 lastN  行.
                // 但是显示的时候， 还是需要 旧的消息放上面， 新的消息放下面.
                resultList.Reverse();


                return resultList;
            }
        }



        public ChatRoomMessage GetChatRoomMessage(long msgId)
        {
            using (MyChatRoomContext context = new MyChatRoomContext())
            {
                var query =
                    from data in context.ChatRoomMessages
                        .Include("MessageSender.UserLevel").Include("ReplyMessage")
                    where
                        data.MessageID == msgId
                        && data.Status == ChatRoomMessage.STATUS_IS_ACTIVE
                    select
                        data;

                ChatRoomMessage result = query.FirstOrDefault();

                return result;
            }
        }




        public List<ChatRoomMessage> GetMyChatRoomMessageList(string houseID, long userID, string userNickName)
        {
            using (MyChatRoomContext context = new MyChatRoomContext())
            {

                // 只查询 最近2小时的数据.
                DateTime minDateTime = DateTime.Now.AddHours(-2);

                var query =
                    from data in context.ChatRoomMessages
                        .Include("MessageSender.UserLevel").Include("ReplyMessage")
                    where
                        // 有效数据.
                        data.Status == ChatRoomMessage.STATUS_IS_ACTIVE
                        // 指定房间.
                        && data.HouseID == houseID
                        // 点对点消息.
                        && data.MessageReceiverId != null
                        &&
                        (
                        // 我发送的消息.
                        (data.MessageSenderId == userID && data.MessageSenderNickName == userNickName)
                        ||
                        // 或者是我接收的消息.
                        (data.MessageReceiverId == userID && data.MessageReceiverNickName == userNickName)
                        )
                        && data.LastUpdateTime > minDateTime
                    select data;

                // 查询.
                List<ChatRoomMessage> resultList = query.ToList();

                // 返回.
                return resultList;
            }

        }


    }
}
