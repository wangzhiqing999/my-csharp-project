using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MyMoney.Model;



namespace MyMoney.Service
{


    /// <summary>
    /// 账户服务.
    /// </summary>
    public interface IAccountService
    {

        /// <summary>
        /// 新增账户.
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="resultMsg"></param>
        /// <returns>账户ID</returns>
        long NewAccount(string userName, ref string resultMsg);




        /// <summary>
        /// 账户操作
        /// </summary>
        /// <param name="accountID">账户代码</param>
        /// <param name="operationTypeCode">操作类型</param>
        /// <param name="accountingDate">结算日期</param>
        /// <param name="money">操作金额</param>
        /// <param name="desc">操作描述</param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        bool AccountOperation(long accountID, string operationTypeCode, DateTime accountingDate, decimal money, string desc, ref string resultMsg);



        /// <summary>
        /// 当日账户操作.
        /// </summary>
        /// <param name="accountID">账户代码</param>
        /// <param name="operationTypeCode">操作类型</param>
        /// <param name="money">操作金额</param>
        /// <param name="desc">操作描述</param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        bool AccountOperation(long accountID, string operationTypeCode, decimal money, string desc, ref string resultMsg);









        /// <summary>
        /// 获取账户信息.
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        Account GetAccount(long accountID);



        /// <summary>
        /// 获取账户的操作日志.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="startDate"></param>
        /// <param name="finishDate"></param>
        /// <returns></returns>
        List<AccountOperationLog> GetAccountOperationLogList(long accountID, DateTime startDate, DateTime finishDate);










        /// <summary>
        /// 生成账户的日结报表.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="reportDate"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        bool BuildDailyReport(long accountID, DateTime reportDate, ref string resultMsg);



        /// <summary>
        /// 获取账户的日结报表.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="startDate"></param>
        /// <param name="finishDate"></param>
        /// <returns></returns>
        List<AccountDailyReport> GetAccountDailyReportList(long accountID, DateTime startDate, DateTime finishDate);


    }


}
