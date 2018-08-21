using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using log4net;
using Newtonsoft.Json;


using MyToken.Model;
using MyToken.Service;



namespace MyToken.ServiceImpl
{

    /// <summary>
    /// 抽象令牌管理.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbstractTokenManager : ITokenManager
    {

        /// <summary>
        /// 成功的消息.
        /// </summary>
        public const string SUCCESS_MESSAGE = "success";


        /// <summary>
        /// 日志处理类.
        /// </summary>
        protected static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        /// <summary>
        /// 新增令牌.
        /// </summary>
        /// <param name="typeCode">分类代码</param>
        /// <param name="userData">用户数据</param>
        /// <param name="resultMsg">结果消息</param>
        /// <returns>Token ID</returns>
        public Guid NewToken(string typeCode, Dictionary<string, object> userData, ref string resultMsg)
        {
            if(logger.IsDebugEnabled) {
                logger.DebugFormat(@"NewToken(typeCode = {0}, userData = {1}) Start!", typeCode, userData);
            }

            try {
                // 首先，取得令牌类型.
                TokenType TokenType = GetTokenType(typeCode);
                if (TokenType == null)
                {
                    resultMsg = String.Format("未知的令牌类型:{0}", typeCode);
                    return Guid.Empty;
                }


                TokenData data = new TokenData();

                // 令牌类型.
                data.TokenTypeCode = typeCode;

                // 令牌ID.
                data.TokenID = Guid.NewGuid();

                // 用户数据, 以Json格式存储.
                if (userData != null)
                {
                    data.UserData = JsonConvert.SerializeObject(userData);
                }                


                // 令牌创建时间 = 现在.
                data.StartTime = DateTime.Now;

                // 令牌过期时间 = 现在 + 默认超时秒数.
                data.ExpiredTime = DateTime.Now.AddSeconds(TokenType.DefaultTimeoutSeconds);

                // 访问次数 = 0.
                data.AccessCount = 0;

                // 保存令牌数据.
                SaveTokenData(data);

                // 返回.
                return data.TokenID;

            } catch (Exception ex) {
                logger.Error(ex.Message, ex);
                resultMsg = ex.Message;
                return Guid.Empty;
            } finally {
                if(logger.IsDebugEnabled) {
                    logger.DebugFormat(@"NewToken(typeCode = {0}, userData = {1}, resultMsg = {2}) Finish!", typeCode, userData, resultMsg);
                }
            }

        }



        /// <summary>
        /// 访问令牌.
        /// </summary>
        /// <param name="tokenID">Token ID</param>
        /// <param name="userData">用户数据</param>
        /// <param name="resultMsg">结果消息</param>
        /// <returns></returns>
        public TokenData AccessToken(Guid tokenID, Dictionary<string, object> userData, ref string resultMsg)
        {
            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat(@"AccessToken(tokenID = {0}, userData = {1}) Start!", tokenID, userData);
            }

            // 令牌.
            TokenData result = null;

            // 令牌类型.
            TokenType tokenType = null;

            try
            {
                // 取得令牌.
                result = GetTokenData(tokenID);

                if (result == null)
                {
                    resultMsg = "令牌不存在";
                    return null;
                }

                // 取得令牌类型.
                tokenType = GetTokenType(result.TokenTypeCode);
                
                // 是否可用.
                if (!result.IsUseable)
                {
                    resultMsg = "令牌超时";
                    return null;
                }

                if (tokenType.AccessAbleTimesLimit > 0)
                {
                    // 配置限制了单个令牌的可访问次数.
                    if (result.AccessCount >= tokenType.AccessAbleTimesLimit)
                    {
                        resultMsg = "令牌使用次数超出限额";
                        return null;
                    }
                }


                // 访问次数递增.
                result.AccessCount++;

                // 保存令牌数据.
                SaveTokenData(result);

                resultMsg = SUCCESS_MESSAGE;


                if(!String.IsNullOrEmpty(result.UserData))
                {
                    result.UserDataObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(result.UserData);
                }


                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                resultMsg = ex.Message;
                return null;
            }
            finally
            {

                if (tokenType != null && tokenType.IsRequireAccessLog)
                {
                    // 需要记录访问日志.
                    TokenAccessLog accessLog = new TokenAccessLog();

                    // 令牌ID。
                    accessLog.TokenID = tokenID;

                    // 访问时间.
                    accessLog.AccessTime = DateTime.Now;

                    // 用户数据, 以Json格式存储.
                    if (userData != null)
                    {
                        accessLog.UserData = JsonConvert.SerializeObject(userData);
                    }
                    

                    // 处理结果.
                    accessLog.AccessResult = resultMsg;

                    // 保存访问日志
                    SaveTokenAccessLog(accessLog);

                }


                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat(@"AccessToken(tokenID = {0}, userData = {1}, resultMsg = {2}) Finish!", tokenID, userData, resultMsg);
                }
            }

        }







        /// <summary>
        /// 移除超时 Token.
        /// </summary>
        public abstract void RemoveTimeoutToken();


        /// <summary>
        /// 获取访问日志.
        /// </summary>
        /// <param name="tokenID"></param>
        /// <returns></returns>
        public List<TokenAccessLog> GetTokenAccessLog(Guid tokenID)
        {
            List<TokenAccessLog> resultList = this.GetTokenAccessLogList(tokenID);
            foreach(var result in resultList)
            {
                if(!String.IsNullOrEmpty(result.UserData))
                {
                    result.UserDataObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(result.UserData);
                }
            }
            return resultList;
        }









        
        /// <summary>
        /// 取得 令牌类型.
        /// </summary>
        /// <param name="typeCode"></param>
        /// <returns></returns>
        protected abstract TokenType GetTokenType(string typeCode);

        /// <summary>
        /// 保存令牌数据.
        /// </summary>
        /// <param name="data"></param>
        protected abstract void SaveTokenData(TokenData data);


        /// <summary>
        /// 取得令牌数据.
        /// </summary>
        /// <param name="tokenID"></param>
        /// <returns></returns>
        protected abstract TokenData GetTokenData(Guid tokenID);

        /// <summary>
        /// 保存访问日志.
        /// </summary>
        /// <param name="log"></param>
        protected abstract void SaveTokenAccessLog(TokenAccessLog log);


        /// <summary>
        /// 获取访问日志.
        /// </summary>
        /// <param name="tokenID"></param>
        /// <returns></returns>
        protected abstract List<TokenAccessLog> GetTokenAccessLogList(Guid tokenID);



    }

}
