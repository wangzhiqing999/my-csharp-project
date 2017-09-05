using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyChatRoom.Model;
using MyChatRoom.DataAccess;
using MyChatRoom.Service;
using MyChatRoom.Util;


namespace MyChatRoom.ServiceImpl
{
    public class DefaultChatRoomUserService : BaseService, IChatRoomUserService
    {



        private const string KeyWord = "QWERTYUIOP{0}ASDFGHJKL{1}ZXCVBNM";


        public bool Login(string userName, string password, ref string resultMsg)
        {
            // 用户名， 去空格，小写.
            userName = userName.Trim().ToLower();

            using (MyChatRoomContext context = new MyChatRoomContext())
            {
                // 检查 用户.
                ChatRoomUser user = context.ChatRoomUsers.FirstOrDefault(p => p.UserName == userName);

                if (user == null)
                {
                    if (logger.IsInfoEnabled)
                    {
                        logger.InfoFormat("用户 {0} 不存在！", userName);
                    }

                    resultMsg = "用户名或密码不正确？";

                    // 用户不存在.
                    return false;
                }

                string key = String.Format(KeyWord, userName, password);

                string pass = SHA512Process.GetSHA512String(key);

                if (user.UserPassword != pass)
                {
                    if (logger.IsInfoEnabled)
                    {
                        logger.InfoFormat("用户 {0} 登录，密码 {1} 输入错误！", userName, password);
                    }

                    resultMsg = "用户名或密码不正确！";

                    // 密码错误.
                    return false;
                }

                return true;
            }
        }




        /// <summary>
        /// 取得用户类型.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public ChatRoomUserLevel GetChatRoomUserLevelByCode(string code)
        {
            using (MyChatRoomContext context = new MyChatRoomContext())
            {
                // 检查 用户等级.
                ChatRoomUserLevel userLevel = context.ChatRoomUserLevels.FirstOrDefault(p => p.UserLevelCode == code);

                // 返回.
                return userLevel;
            }
        }



        /// <summary>
        /// 取得用户.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public ChatRoomUser GetChatRoomUserByName(string userName)
        {
            using (MyChatRoomContext context = new MyChatRoomContext())
            {
                // 检查 用户.
                ChatRoomUser user = context.ChatRoomUsers.Include("UserLevel").FirstOrDefault(p => p.UserName == userName);

                // 返回.
                return user;
            }

        }



        /// <summary>
        /// 取得用户.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public ChatRoomUser GetChatRoomUser(long userID)
        {
            using (MyChatRoomContext context = new MyChatRoomContext())
            {
                // 检查 用户.
                ChatRoomUser user = context.ChatRoomUsers.Find(userID);

                // 返回.
                return user;
            }

        }


        /// <summary>
        /// 创建或更新用户
        /// </summary>
        /// <param name="userData"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public bool InsertOrUpdateChatRoomUser(ChatRoomUser userData, ref string resultMsg)
        {
            try
            {
                using (MyChatRoomContext context = new MyChatRoomContext())
                {
                    // 先判断本次操作， 是插入， 还是更新.
                    ChatRoomUser dbUserData = context.ChatRoomUsers.Find(userData.UserID);

                    if (dbUserData == null)
                    {
                        // 插入.
                        context.ChatRoomUsers.Add(userData);
                    }
                    else
                    {
                        // 更新.

                        // 昵称.
                        dbUserData.UserNickName = userData.UserNickName;

                        // 等级.
                        dbUserData.UserLevelCode = userData.UserLevelCode;

                        // 头像.
                        dbUserData.UserPhoto = userData.UserPhoto;

                    }

                    context.SaveChanges();
                }

                return true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbErr)
            {
                foreach (var errItem in dbErr.EntityValidationErrors)
                {
                    foreach (var err in errItem.ValidationErrors)
                    {
                        logger.InfoFormat("{0} : {1}", err.PropertyName, err.ErrorMessage);
                    }
                }

                logger.Error(dbErr.Message, dbErr);
                resultMsg = dbErr.Message;
                return false;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                resultMsg = ex.Message;
                return false;
            }


        }


    }


}
