using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using log4net;

using MyBallot.Model;
using MyBallot.DataAccess;
using MyBallot.Service;


namespace MyBallot.ServiceImpl
{
    public class DefaultUserBallotService : IUserBallotService
    {

        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        /// 结果消息.
        /// </summary>
        public string ResultMessage
        {
            set;
            get;
        }


        /// <summary>
        /// 用户投票
        /// </summary>
        /// <param name="userBallot"></param>
        /// <returns></returns>
        public bool TakeUserBallot(UserBallot userBallot)
        {
            // 预期结果.
            bool result = false;
            try
            {
                using (MyBallotContext context = new MyBallotContext())
                {

                    // 先检查. 是否存在 重复提交.
                    var existQuery =
                        from data in context.UserBallots
                        where
                            // 同一个 投票主数据.
                            data.BallotMasterID == userBallot.BallotMasterID
                            // ip 一致.
                            && data.UserIp == userBallot.UserIp
                            // cookie 一致.
                            && data.UserCookie == userBallot.UserCookie
                            // 今天.
                            && data.BallotTime >= DateTime.Today
                        select
                            data;

                    if (existQuery.Count() > 0)
                    {
                        // 存在 重复提交.
                        ResultMessage = "一天只能投票一次！";
                        return false;
                    }


                    // 检查， 避免传入 不存在的  投票主表  与 投票明细.
                    BallotMaster master = context.BallotMasters.Find(userBallot.BallotMasterID);
                    if (master == null)
                    {
                        ResultMessage = "投票主数据不存在！";
                        return false;
                    }

                    BallotDetail detail = context.BallotDetails.Find(userBallot.BallotDetailID);
                    if (detail == null)
                    {
                        ResultMessage = "投票明细数据不存在！";
                        return false;
                    }



                    // 数据检查完毕.
                    // 投票明细的 投票数 + 1.
                    detail.BallotCount = detail.BallotCount + 1;


                    // 插入用户投票数据.
                    context.UserBallots.Add(userBallot);


                    // 物理保存.
                    context.SaveChanges();
                }

                result = true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbErr)
            {
                logger.Info(userBallot);
                foreach (var errItem in dbErr.EntityValidationErrors)
                {
                    foreach (var err in errItem.ValidationErrors)
                    {
                        logger.InfoFormat("{0} : {1}", err.PropertyName, err.ErrorMessage);
                    }
                }
                logger.Error(dbErr.Message, dbErr);
                result = false;
                ResultMessage = dbErr.Message;
            }
            catch (Exception ex)
            {
                result = false;
                ResultMessage = ex.Message;                
            }
            return result;
        }


    }
}
