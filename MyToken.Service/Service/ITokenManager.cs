using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyToken.Model;


namespace MyToken.Service
{

    /// <summary>
    /// 令牌管理.
    /// </summary>
    public interface ITokenManager
    {


        /// <summary>
        /// 新增令牌.
        /// </summary>
        /// <param name="typeCode">分类代码</param>
        /// <param name="userData">用户数据</param>
        /// <param name="resultMsg">结果消息</param>
        /// <returns>Token ID</returns>
        Guid NewToken(string typeCode, object userData, ref string resultMsg);



        /// <summary>
        /// 访问令牌.
        /// </summary>
        /// <param name="tokenID">Token ID</param>
        /// <param name="userData">用户数据</param>
        /// <param name="resultMsg">结果消息</param>
        /// <returns></returns>
        TokenData AccessToken(Guid tokenID, object userData, ref string resultMsg);



        /// <summary>
        /// 移除超时令牌.
        /// </summary>
        void RemoveTimeoutToken();



        /// <summary>
        /// 获取访问日志.
        /// </summary>
        /// <param name="tokenID"></param>
        /// <returns></returns>
        List<TokenAccessLog> GetTokenAccessLog(Guid tokenID);

    }

}
