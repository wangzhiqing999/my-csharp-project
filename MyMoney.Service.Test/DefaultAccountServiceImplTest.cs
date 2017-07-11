using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


using MyMoney.Model;
using MyMoney.ServiceImpl;




namespace MyMoney.Service.Test
{
    [TestClass]
    public class DefaultAccountServiceImplTest
    {

        [TestMethod]
        public void TestCase1()
        {
            // 待测试的服务实现.
            DefaultAccountServiceImpl service = new DefaultAccountServiceImpl();

            
            string resultMsg = null;

            // 步骤1. 创建账户.
            string userName = "TEST_001";
            long accountID = service.NewAccount(userName, ref resultMsg);

            // 账户ID 大于零 .
            Assert.IsTrue(accountID > 0);


            // 步骤2. 获取账户.
            var getAccountResult = service.GetAccount(accountID);
            // 结果非空.
            Assert.IsNotNull(getAccountResult);
            // 余额.
            Assert.AreEqual(0, getAccountResult.AccountBalance);



            // 步骤3. 测试不存在的账户
            bool opResult = service.AccountOperation(
                accountID: -1, 
                operationTypeCode : "BUY",
                money : -100,
                desc : "测试",
                resultMsg : ref resultMsg);

            // 结果应该是失败的.
            Assert.IsFalse(opResult);


            // 步骤4. 测试不存在的操作类型.
            opResult = service.AccountOperation(
                accountID: accountID,
                operationTypeCode: "BUYBUYBUY",
                money: -100,
                desc: "测试",
                resultMsg: ref resultMsg);

            // 结果应该是失败的.
            Assert.IsFalse(opResult);


            // 步骤5. 测试 余额不足.
            opResult = service.AccountOperation(
                accountID: accountID,
                operationTypeCode: "BUY",
                money: -100000,
                desc: "测试",
                resultMsg: ref resultMsg);

            // 结果应该是失败的.
            Assert.IsFalse(opResult);



            // 步骤6. 测试正常的操作.
            opResult = service.AccountOperation(
                accountID: accountID,
                operationTypeCode: "IN",
                money: 10000,
                desc: "测试入金10000块.",
                resultMsg: ref resultMsg);

            // 结果应该是成功的.
            Assert.IsTrue(opResult);

            // 校验账户余额.
            getAccountResult = service.GetAccount(accountID);
            // 结果非空.
            Assert.IsNotNull(getAccountResult);
            // 余额.
            Assert.AreEqual(10000, getAccountResult.AccountBalance);



            opResult = service.AccountOperation(
                accountID: accountID,
                operationTypeCode: "BUY",
                money: -100,
                desc: "测试买入，花费100块.",
                resultMsg: ref resultMsg);

            // 结果应该是成功的.
            Assert.IsTrue(opResult);


            // 校验账户余额.
            getAccountResult = service.GetAccount(accountID);
            // 结果非空.
            Assert.IsNotNull(getAccountResult);
            // 余额.
            Assert.AreEqual(9900, getAccountResult.AccountBalance);




            // 步骤7. 测试正常的操作.
            opResult = service.AccountOperation(
                accountID: accountID,
                operationTypeCode: "SELL",
                money: 99,
                desc: "测试卖出，收入99块.",
                resultMsg: ref resultMsg);

            // 结果应该是成功的.
            Assert.IsTrue(opResult);

            // 校验账户余额.
            getAccountResult = service.GetAccount(accountID);
            // 结果非空.
            Assert.IsNotNull(getAccountResult);
            // 余额.
            Assert.AreEqual(9999, getAccountResult.AccountBalance);



            // 步骤8， 检查 操作日志.
            var logList = service.GetAccountOperationLogList(accountID, DateTime.Today, DateTime.Today);

            // 日志列表非空.
            Assert.IsNotNull(logList);
            // 日志列表行数为 3.
            Assert.AreEqual(3, logList.Count);


            // 日志的首行非空.
            Assert.IsNotNull(logList[0]);
            // 日志的首行的 账户.
            Assert.AreEqual(accountID, logList[0].AccountID);
            // 日志首行的 操作类型.
            Assert.AreEqual("IN", logList[0].OperationTypeCode);
            // 日志首行的 金额.
            Assert.AreEqual(10000, logList[0].OperationMoney);
            // 日志首行的 操作前余额.
            Assert.AreEqual(0, logList[0].BeforeAccountBalance);
            // 日志首行的 操作后余额.
            Assert.AreEqual(10000, logList[0].AfterAccountBalance);


            // 日志的次行非空.
            Assert.IsNotNull(logList[1]);
            // 日志的次行的 账户.
            Assert.AreEqual(accountID, logList[1].AccountID);
            // 日志次行的 操作类型.
            Assert.AreEqual("BUY", logList[1].OperationTypeCode);
            // 日志次行的 金额.
            Assert.AreEqual(-100, logList[1].OperationMoney);
            // 日志次行的 操作前余额.
            Assert.AreEqual(10000, logList[1].BeforeAccountBalance);
            // 日志次行的 操作后余额.
            Assert.AreEqual(9900, logList[1].AfterAccountBalance);


            // 日志的末行非空.
            Assert.IsNotNull(logList[2]);
            // 日志的末行的 账户.
            Assert.AreEqual(accountID, logList[2].AccountID);
            // 日志末行的 操作类型.
            Assert.AreEqual("SELL", logList[2].OperationTypeCode);
            // 日志末行的 金额.
            Assert.AreEqual(99, logList[2].OperationMoney);
            // 日志末行的 操作前余额.
            Assert.AreEqual(9900, logList[2].BeforeAccountBalance);
            // 日志末行的 操作后余额.
            Assert.AreEqual(9999, logList[2].AfterAccountBalance);






            // 步骤9. 日报表.
            opResult = service.BuildDailyReport(accountID, DateTime.Today, ref resultMsg);
            // 结果应该是成功的.
            Assert.IsTrue(opResult);


            // 查询报表.
            var reportList = service.GetAccountDailyReportList(accountID, DateTime.Today, DateTime.Today);

            // 报表列表非空.
            Assert.IsNotNull(reportList);
            // 报表列表行数为 1.
            Assert.AreEqual(1, reportList.Count);

            var report = reportList[0];

            // 期初.
            Assert.AreEqual(0, report.BeginningMoney);
            // 期末.
            Assert.AreEqual(9999, report.EndingMoney);
            // 变化.
            Assert.AreEqual(9999, report.MoneyChange);
            // 交易笔数.
            Assert.AreEqual(3, report.DealCount);
        }





        [TestMethod]
        public void TestCase2()
        {
            // 待测试的服务实现.
            DefaultAccountServiceImpl service = new DefaultAccountServiceImpl();


            string resultMsg = null;

            // 步骤1. 创建账户.
            string userName = "TEST_002";
            long accountID = service.NewAccount(userName, ref resultMsg);


            // 账户ID 大于零 .
            Assert.IsTrue(accountID > 0);


            // 步骤2. 测试多日的操作.
            DateTime firstDate = DateTime.Today.AddDays(-10);
            DateTime accountingDate = firstDate;


            // 首日入金.
            bool opResult = service.AccountOperation(
                accountID: accountID,
                operationTypeCode: "IN",
                accountingDate : accountingDate,
                money: 10000,
                desc: "测试入金10000块.",
                resultMsg: ref resultMsg);

            // 结果应该是成功的.
            Assert.IsTrue(opResult);



            for (int i = 1; i < 10; i++)
            {
                accountingDate = accountingDate.AddDays(1);

                // 后续 N 日， 每天买入部分.

                opResult = service.AccountOperation(
                    accountID: accountID,
                    operationTypeCode: "BUY",
                    accountingDate: accountingDate,
                    money: -100 * i,
                    desc: String.Format("测试买入，花费 {0} 块.", 100 * i),
                    resultMsg: ref resultMsg);

                // 结果应该是成功的.
                Assert.IsTrue(opResult);
            }


            // 校验账户余额.
            var getAccountResult = service.GetAccount(accountID);
            // 结果非空.
            Assert.IsNotNull(getAccountResult);
            // 余额 = (10000 -100 -200 -300 -400 -500 -600 -700 -800 -900 = 5500
            Assert.AreEqual(5500, getAccountResult.AccountBalance);




            // 检查 操作日志.
            var logList = service.GetAccountOperationLogList(accountID, firstDate, DateTime.Today);

            // 日志列表非空.
            Assert.IsNotNull(logList);
            // 日志列表行数为 10.
            Assert.AreEqual(10, logList.Count);


            // 日志的首行非空.
            Assert.IsNotNull(logList[0]);
            // 日志的首行的 账户.
            Assert.AreEqual(accountID, logList[0].AccountID);
            // 日志首行的 操作类型.
            Assert.AreEqual("IN", logList[0].OperationTypeCode);
            // 日志首行的 金额.
            Assert.AreEqual(10000, logList[0].OperationMoney);
            // 日志首行的 操作前余额.
            Assert.AreEqual(0, logList[0].BeforeAccountBalance);
            // 日志首行的 操作后余额.
            Assert.AreEqual(10000, logList[0].AfterAccountBalance);


            // 临时余额.
            decimal tmpBalance = 10000;

            // 后续 9 行的日志.
            for (int i = 1; i < 10; i++)
            {
                // 日志的第 N 行非空.
                Assert.IsNotNull(logList[i]);
                // 日志的第 N 行的 账户.
                Assert.AreEqual(accountID, logList[i].AccountID);
                // 日志的第 N 行的 操作类型.
                Assert.AreEqual("BUY", logList[i].OperationTypeCode);
                // 日志的第 N 行的 金额.
                Assert.AreEqual(-100 * i, logList[i].OperationMoney);

                // 日志的第 N 行的 操作前余额.
                Assert.AreEqual(tmpBalance, logList[i].BeforeAccountBalance);

                tmpBalance = tmpBalance - 100 * i;

                // 日志的第 N 行的 操作后余额.
                Assert.AreEqual(tmpBalance, logList[i].AfterAccountBalance);
            }

        }



    }
}
