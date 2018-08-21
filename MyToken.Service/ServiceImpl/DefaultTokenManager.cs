using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using MyToken.Model;
using MyToken.DataAccess;


namespace MyToken.ServiceImpl
{


    /// <summary>
    /// 默认的令牌管理.
    /// </summary>
    public class DefaultTokenManager : AbstractTokenManager
    {

        /// <summary>
        /// 移除超时 Token.
        /// </summary>
        public override void RemoveTimeoutToken()
        {
            try
            {
                using (MyTokenContext context = new MyTokenContext())
                {
                    var timeoutQuery =
                        from data in context.TokenDatas
                        where
                            data.ExpiredTime < DateTime.Now
                        select data;

                    List<TokenData> removeList = timeoutQuery.ToList();

                    foreach (var item in removeList)
                    {
                        context.TokenDatas.Remove(item);
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // 日志.
                logger.Error(ex.Message, ex);
            }
        }


        /// <summary>
        /// 获取访问日志.
        /// </summary>
        /// <param name="tokenID"></param>
        /// <returns></returns>
        protected override List<TokenAccessLog> GetTokenAccessLogList(Guid tokenID)
        {
            using (MyTokenContext context = new MyTokenContext())
            {
                var query =
                    from data in context.TokenAccessLogs
                    where
                        data.TokenID == tokenID
                    select data;

                List<TokenAccessLog> resultList = query.ToList();

                return resultList;
            }
        }




        /// <summary>
        /// 取得 令牌类型.
        /// </summary>
        /// <param name="typeCode"></param>
        /// <returns></returns>
        protected override TokenType GetTokenType(string typeCode)
        {
            using (MyTokenContext context = new MyTokenContext())
            {
                TokenType result = context.TokenTypes.Find(typeCode);
                return result;
            }
        }


        /// <summary>
        /// 保存令牌数据.
        /// </summary>
        /// <param name="data"></param>
        protected override void SaveTokenData(TokenData data)
        {
            using (MyTokenContext context = new MyTokenContext())
            {
                // 获取数据库数据.
                TokenData dbData = context.TokenDatas.Find(data.TokenID);

                if (dbData == null)
                {
                    // 新增.
                    context.TokenDatas.Add(data);
                }
                else
                {
                    // 编辑.

                    // 更新次数.
                    dbData.AccessCount = data.AccessCount;
                }
                

                context.SaveChanges();
            }
        }



        /// <summary>
        /// 取得令牌数据.
        /// </summary>
        /// <param name="tokenID"></param>
        /// <returns></returns>
        protected override TokenData GetTokenData(Guid tokenID)
        {
            using (MyTokenContext context = new MyTokenContext())
            {
                TokenData result = context.TokenDatas.Find(tokenID);
                return result;
            }
        }


        /// <summary>
        /// 保存访问日志.
        /// </summary>
        /// <param name="log"></param>
        protected override void SaveTokenAccessLog(TokenAccessLog log)
        {
            using (MyTokenContext context = new MyTokenContext())
            {
                context.TokenAccessLogs.Add(log);
                context.SaveChanges();
            }
        }



        
    }

}
