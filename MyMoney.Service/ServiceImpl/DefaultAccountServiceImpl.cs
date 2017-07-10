using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MyMoney.Model;
using MyMoney.DataAccess;
using MyMoney.Service;


namespace MyMoney.ServiceImpl
{


    /// <summary>
    /// 账户服务默认实现.
    /// </summary>
    public class DefaultAccountServiceImpl : IAccountService
    {

        /// <summary>
        /// 成功返回的消息.
        /// </summary>
        private const string SUCCESS_MESSAGE = "success";


        /// <summary>
        /// 新增账户.
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="resultMsg"></param>
        /// <returns>账户ID</returns>
        public long NewAccount(string userName, ref string resultMsg)
        {
            try
            {
                Account data = new Account()
                {
                    // 用户名。
                    UserName = userName,
                    // 初期余额 = 0.
                    AccountBalance = 0,
                };

                using (MyMoneyContext context = new MyMoneyContext())
                {
                    context.Accounts.Add(data);
                    context.SaveChanges();
                }

                resultMsg = SUCCESS_MESSAGE;
                return data.AccountID;
            }
            catch (Exception ex)
            {
                resultMsg = ex.Message;
                return -1;
            }
        }



        /// <summary>
        /// 账户操作.
        /// </summary>
        /// <param name="accountID">账户代码</param>
        /// <param name="operationTypeCode">操作类型</param>
        /// <param name="money">操作金额</param>
        /// <param name="desc">操作描述</param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public bool AccountOperation(long accountID, string operationTypeCode, decimal money, string desc, ref string resultMsg)
        {
            try
            {
                using (MyMoneyContext context = new MyMoneyContext())
                {
                    // 查询账户信息.
                    var accountData = context.Accounts.Find(accountID);
                    if (accountData == null)
                    {
                        resultMsg = String.Format("未检索到代码为 {0} 的账户信息！", accountID);
                        return false;
                    }

                    // 查询账户操作类型.
                    var operationType = context.AccountOperationTypes.Find(operationTypeCode);
                    if (operationType == null)
                    {
                        resultMsg = String.Format("未知的操作类型代码 {0} ！", operationTypeCode);
                        return false;
                    }


                    // 检查操作类型.
                    switch (operationType.ChangeDirection)
                    {
                        case AccountOperationType.MoneyChangeDirection.Increase:
                            // 金额增加.
                            if (money < 0)
                            {
                                // 金额增加的账户操作， 传递了小于零的 操作金额.
                                resultMsg = String.Format("非法的操作金额 {0} ！", money);
                                return false;
                            }
                            break;
                        case AccountOperationType.MoneyChangeDirection.Decrease:
                            // 金额减少.
                            if (money > 0)
                            {
                                // 金额减少的账户操作， 传递了大于零的 操作金额.
                                resultMsg = String.Format("非法的操作金额 {0}！", money);
                                return false;
                            }
                            break;
                        case AccountOperationType.MoneyChangeDirection.Unchanged:
                            // 金额无变化.
                            if (money != 0)
                            {
                                // 金额无变化的账户操作， 传递了非零的 操作金额.
                                resultMsg = String.Format("无效的操作金额 {0} ！", money);
                                return false;
                            }
                            break;
                        default:
                            // 未知的情况.
                            resultMsg = String.Format("操作类型代码为 {0} 的数据，存在异常！", operationTypeCode);
                            return false;
                    }




                    // 检查账户余额.
                    decimal afterAccountBalance = accountData.AccountBalance + money;
                    if (afterAccountBalance < 0)
                    {
                        resultMsg = "账户余额不足！";
                        return false;
                    }


                    // 创建日志.
                    AccountOperationLog logData = new AccountOperationLog()
                    {
                        // 关联账户ID.
                        AccountID = accountID,
                        // 账户操作类型.
                        OperationTypeCode = operationTypeCode,
                        // 操作时间.
                        OperationTime = DateTime.Now,
                        // 操作金额.
                        OperationMoney = money,
                        // 操作备注.
                        OperationDesc = desc,

                        // 业务处理前 账户金额.
                        BeforeAccountBalance = accountData.AccountBalance,
                        // 业务处理后 账户金额.
                        AfterAccountBalance = afterAccountBalance,
                    };

                    // 插入日志.
                    context.AccountOperationLogs.Add(logData);


                    // 更新账户金额 = 业务处理后 账户金额.
                    accountData.AccountBalance = afterAccountBalance;

                    // 物理保存.
                    context.SaveChanges();
                }

                resultMsg = SUCCESS_MESSAGE;
                return true;
            }
            catch (Exception ex)
            {
                resultMsg = ex.Message;
                return false;
            }
        }







        public Account GetAccount(long accountID)
        {
            using (MyMoneyContext context = new MyMoneyContext())
            {
                // 查询账户信息.
                var accountData = context.Accounts.Find(accountID);
                return accountData;
            }
        }



        public List<AccountOperationLog> GetAccountOperationLogList(long accountID, DateTime startDate, DateTime finishDate)
        {
            List<AccountOperationLog> resultList = new List<AccountOperationLog>();

            // 结束的日期时间 = 结束日期 + 1天.
            // 时间的查询条件， 为  大于等于 开始日期， 小于 结束日期 + 1天
            DateTime finishDateTime = finishDate.AddDays(1);

            using (MyMoneyContext context = new MyMoneyContext())
            {
                // 查询账户操作日志.
                var query =
                    from data in context.AccountOperationLogs
                    where
                        data.AccountID == accountID
                        && data.OperationTime >= startDate
                        && data.OperationTime < finishDateTime
                    select
                        data;

                resultList = query.ToList();
            }

            return resultList;
        }







        /// <summary>
        /// 生成账户的日结报表.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="reportDate"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public bool BuildDailyReport(long accountID, DateTime reportDate, ref string resultMsg)
        {

            // 报表结束时间.
            DateTime reportFinishTime = reportDate.AddDays(1);

            try
            {
                using (MyMoneyContext context = new MyMoneyContext())
                {
                    // 查询账户信息.
                    var accountData = context.Accounts.Find(accountID);
                    if (accountData == null)
                    {
                        resultMsg = String.Format("未检索到代码为 {0} 的账户信息！", accountID);
                        return false;
                    }



                    // 新的报表数据.
                    AccountDailyReport newReport = new AccountDailyReport() {
                        // 账户.
                        AccountID = accountID,
                        // 日期.
                        ReportDate = reportDate,
                    };


                    
                    // 查询是否存在 前日报表.
                    var reportQuery =
                        from data in context.AccountDailyReports
                        where
                            data.AccountID == accountID
                        orderby
                            data.ReportDate descending
                        select
                            data;

                    var lastDailyData = reportQuery.FirstOrDefault();

                    if (lastDailyData == null)
                    {
                        // 不存在 历史报表.                            
                        // 期初资金.
                        newReport.BeginningMoney = 0;
                    }
                    else
                    {
                        // 存在 历史报表.
                        // 需要判断.
                        if (lastDailyData.ReportDate >= reportDate)
                        {
                            // 最后一个报表的日期， 大于等于 计算的日期。
                            // 报错.
                            resultMsg = String.Format("已经存在有 {0:yyyy-MM-dd} 的报表数据， 不能计算之前的报表数据！", lastDailyData.ReportDate);
                            return false;
                        }
                        // 这一期的 期初  = 上期的 期末.
                        newReport.BeginningMoney = lastDailyData.EndingMoney;
                    }


                    // 计算当日交易.
                    var logQuery =
                        from data in context.AccountOperationLogs
                        where
                            data.AccountID == accountID
                            && data.OperationTime >= reportDate
                            && data.OperationTime < reportFinishTime
                        orderby
                            data.OperationTime
                        select
                            data;

                    List<AccountOperationLog> logList = logQuery.ToList();

                    // 交易笔数.
                    newReport.DealCount = logList.Count();
                    // 变化金额.
                    newReport.MoneyChange = logList.Sum(p => p.OperationMoney);
                    
                    
                    // 期末金额.
                    if (newReport.DealCount == 0)
                    {
                        // 无交易.
                        // 期末 = 期初.
                        newReport.EndingMoney = newReport.BeginningMoney;
                    }
                    else
                    {
                        // 期末 = 日志中， 最后一行的 处理后.
                        newReport.EndingMoney = logList.Last().AfterAccountBalance;
                    }
                    


                    // 插入数据.
                    context.AccountDailyReports.Add(newReport);
                    // 保存.
                    context.SaveChanges();


                    resultMsg = SUCCESS_MESSAGE;
                    return true;
                }
            }
            catch (Exception ex)
            {
                resultMsg = ex.Message;
                return false;
            }

        }




        /// <summary>
        /// 获取账户的日结报表.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="startDate"></param>
        /// <param name="finishDate"></param>
        /// <returns></returns>
        public List<AccountDailyReport> GetAccountDailyReportList(long accountID, DateTime startDate, DateTime finishDate)
        {
            List<AccountDailyReport> resultList = new List<AccountDailyReport>();

            // 结束的日期时间 = 结束日期 + 1天.
            // 时间的查询条件， 为  大于等于 开始日期， 小于 结束日期 + 1天
            DateTime finishDateTime = finishDate.AddDays(1);

            using (MyMoneyContext context = new MyMoneyContext())
            {
                // 查询账户操作日志.
                var query =
                    from data in context.AccountDailyReports
                    where
                        data.AccountID == accountID
                        && data.ReportDate >= startDate
                        && data.ReportDate < finishDateTime
                    select
                        data;

                resultList = query.ToList();
            }

            return resultList;
        }



    }

}
