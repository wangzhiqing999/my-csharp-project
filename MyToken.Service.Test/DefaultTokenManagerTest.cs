using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;


using MyToken.Model;
using MyToken.Service;
using MyToken.ServiceImpl;


namespace MyToken.Service.Test
{
    [TestClass]
    public class DefaultTokenManagerTest
    {

        /// <summary>
        /// 令牌管理.
        /// </summary>
        private ITokenManager tokenManager = new DefaultTokenManager();



        [TestMethod]
        public void TestCase0()
        {
            // 测试不存在的 测试案例.
            string resultMsg = null;

            // 创建 Token.
            Guid token = this.tokenManager.NewToken("TEST_CASE_NOT_EXISTS", null, ref resultMsg);

            // 结果为 Guid.Empty
            Assert.AreEqual(Guid.Empty, token);

            TokenData tokenData = this.tokenManager.AccessToken(token, null, ref resultMsg);

            // 结果为 Null
            Assert.IsNull(tokenData);
        }





        [TestMethod]
        public void TestCase1()
        {
            // TEST_CASE_1，测试案例1， 10秒有效，允许多次使用，无日志
            string resultMsg = null;


            // 创建 Token.
            Guid token = this.tokenManager.NewToken("TEST_CASE_1", null, ref resultMsg);
            // 结果非 Guid.Empty.
            Assert.AreNotEqual(Guid.Empty, token);


            // ########## 这里目的是测试 允许多次使用 ##########
            for (int i = 0; i < 5; i++)
            {
                Dictionary<string, object> userData = new Dictionary<string, object>();
                userData.Add("UserSecondData", i);

                TokenData tokenData = this.tokenManager.AccessToken(token, userData, ref resultMsg);
                // 结果非 Null
                Assert.IsNotNull(tokenData);
            }



            // ########## 这里目的是测试  10秒有效 ##########
            // 休眠11秒. 让 Token 过期.
            System.Threading.Thread.Sleep(11000);

            Dictionary<string, object> userData11 = new Dictionary<string, object>();
            userData11.Add("UserSecondData", 11);

            // 再次调用.
            TokenData tokenData2 = this.tokenManager.AccessToken(token, userData11, ref resultMsg);
            // 结果为 Null
            Assert.IsNull(tokenData2);



            // ########## 这里目的是测试  无日志 ##########
            var logList = this.tokenManager.GetTokenAccessLog(token);

            // 结果非 Null
            Assert.IsNotNull(logList);
            // 日志行数为零.
            Assert.AreEqual(0, logList.Count);
        }




        [TestMethod]
        public void TestCase2()
        {
            // TEST_CASE_2，测试案例2， 10秒有效，最多次使用1次，无日志
            string resultMsg = null;


            // ########## 这里目的是测试 最多次使用1次 ##########

            Dictionary<string, object> userData = new Dictionary<string, object>();
            userData.Add("UserData", "TEST_CASE_2_CREATE");

            // 创建 Token.
            Guid token1 = this.tokenManager.NewToken("TEST_CASE_2", userData, ref resultMsg);
            // 结果非 Guid.Empty.
            Assert.AreNotEqual(Guid.Empty, token1);



            // 首次调用.
            TokenData tokenData = this.tokenManager.AccessToken(token1, null, ref resultMsg);
            // 结果非 Null
            Assert.IsNotNull(tokenData);

            // 二次调用.
            tokenData = this.tokenManager.AccessToken(token1, null, ref resultMsg);
            // 结果为 Null
            Assert.IsNull(tokenData);


            // ########## 这里目的是测试  10秒有效 ##########

            Dictionary<string, object> userData2 = new Dictionary<string, object>();
            userData2.Add("UserData", "TEST_CASE_2_TIMEOUT");

            // 创建 Token.
            Guid token2 = this.tokenManager.NewToken("TEST_CASE_2", userData2, ref resultMsg);
            // 结果非 Guid.Empty.
            Assert.AreNotEqual(Guid.Empty, token2);

            // 休眠11秒. 让 Token 过期.
            System.Threading.Thread.Sleep(11000);
            // 首次调用.
            tokenData = this.tokenManager.AccessToken(token2, null, ref resultMsg);
            // 结果为 Null
            Assert.IsNull(tokenData);



            // ########## 这里目的是测试  无日志 ##########
            var logList = this.tokenManager.GetTokenAccessLog(token1);
            // 结果非 Null
            Assert.IsNotNull(logList);
            // 日志行数为零.
            Assert.AreEqual(0, logList.Count);


            logList = this.tokenManager.GetTokenAccessLog(token2);
            // 结果非 Null
            Assert.IsNotNull(logList);
            // 日志行数为零.
            Assert.AreEqual(0, logList.Count);


        }





        [TestMethod]
        public void TestCase3()
        {
            // TEST_CASE_3，测试案例3， 10秒有效，最多次使用2次，无日志
            string resultMsg = null;

            Dictionary<string, object> userData = new Dictionary<string, object>();
            userData.Add("UserData", "TEST_CASE_3_CREATE");


            // ########## 这里目的是测试 最多次使用2次 ##########
            // 创建 Token.
            Guid token1 = this.tokenManager.NewToken("TEST_CASE_3", userData, ref resultMsg);
            // 结果非 Guid.Empty.
            Assert.AreNotEqual(Guid.Empty, token1);
            // 首次调用.
            TokenData tokenData = this.tokenManager.AccessToken(token1, null, ref resultMsg);
            // 结果非 Null
            Assert.IsNotNull(tokenData);
            // 二次调用.
            tokenData = this.tokenManager.AccessToken(token1, null, ref resultMsg);
            // 结果非 Null
            Assert.IsNotNull(tokenData);
            // 三次调用.
            tokenData = this.tokenManager.AccessToken(token1, null, ref resultMsg);
            // 结果为 Null
            Assert.IsNull(tokenData);


            // ########## 这里目的是测试  10秒有效 ##########

            Dictionary<string, object> userData2 = new Dictionary<string, object>();
            userData2.Add("UserData", "TEST_CASE_3_TIMEOUT");

            // 创建 Token.
            Guid token2 = this.tokenManager.NewToken("TEST_CASE_3", userData2, ref resultMsg);
            // 结果非 Guid.Empty.
            Assert.AreNotEqual(Guid.Empty, token2);
            // 休眠11秒. 让 Token 过期.
            System.Threading.Thread.Sleep(11000);
            // 首次调用.
            tokenData = this.tokenManager.AccessToken(token2, null, ref resultMsg);
            // 结果为 Null
            Assert.IsNull(tokenData);



            // ########## 这里目的是测试  无日志 ##########
            var logList = this.tokenManager.GetTokenAccessLog(token1);
            // 结果非 Null
            Assert.IsNotNull(logList);
            // 日志行数为零.
            Assert.AreEqual(0, logList.Count);


            logList = this.tokenManager.GetTokenAccessLog(token2);
            // 结果非 Null
            Assert.IsNotNull(logList);
            // 日志行数为零.
            Assert.AreEqual(0, logList.Count);
        }









        [TestMethod]
        public void TestCase4()
        {
            // TEST_CASE_4，测试案例4， 10秒有效，允许多次使用，有日志
            string resultMsg = null;


            // 创建 Token.
            Guid token = this.tokenManager.NewToken("TEST_CASE_4", null, ref resultMsg);
            // 结果非 Guid.Empty.
            Assert.AreNotEqual(Guid.Empty, token);


            // ########## 这里目的是测试 允许多次使用 ##########
            for (int i = 0; i < 5; i++)
            {
                Dictionary<string, object> userData = new Dictionary<string, object>();
                userData.Add("UserData", "TEST_CASE_4_USER_" + i);

                TokenData tokenData = this.tokenManager.AccessToken(token, userData, ref resultMsg);
                // 结果非 Null
                Assert.IsNotNull(tokenData);
            }



            // ########## 这里目的是测试  10秒有效 ##########
            // 休眠11秒. 让 Token 过期.
            System.Threading.Thread.Sleep(11000);
            // 再次调用.
            TokenData tokenData2 = this.tokenManager.AccessToken(token, null, ref resultMsg);
            // 结果为 Null
            Assert.IsNull(tokenData2);




            // ########## 这里目的是测试  有日志 ##########
            var logList = this.tokenManager.GetTokenAccessLog(token);

            // 结果非 Null
            Assert.IsNotNull(logList);
            // 日志行数为6. （5次成功， 1次失败）
            Assert.AreEqual(6, logList.Count);
        }








        [TestMethod]
        public void TestCase5()
        {
            // TEST_CASE_5，测试案例5， 10秒有效，最多次使用1次，有日志
            string resultMsg = null;


            // ########## 这里目的是测试 最多次使用1次 ##########
            // 创建 Token.
            Guid token1 = this.tokenManager.NewToken("TEST_CASE_5", null, ref resultMsg);
            // 结果非 Guid.Empty.
            Assert.AreNotEqual(Guid.Empty, token1);
            // 首次调用.
            TokenData tokenData = this.tokenManager.AccessToken(token1, null, ref resultMsg);
            // 结果非 Null
            Assert.IsNotNull(tokenData);
            // 二次调用.
            tokenData = this.tokenManager.AccessToken(token1, null, ref resultMsg);
            // 结果为 Null
            Assert.IsNull(tokenData);


            // ########## 这里目的是测试  10秒有效 ##########
            // 创建 Token.
            Guid token2 = this.tokenManager.NewToken("TEST_CASE_5", null, ref resultMsg);
            // 结果非 Guid.Empty.
            Assert.AreNotEqual(Guid.Empty, token2);
            // 休眠11秒. 让 Token 过期.
            System.Threading.Thread.Sleep(11000);
            // 首次调用.
            tokenData = this.tokenManager.AccessToken(token2, null, ref resultMsg);
            // 结果为 Null
            Assert.IsNull(tokenData);



            // ########## 这里目的是测试  有日志 ##########
            var logList = this.tokenManager.GetTokenAccessLog(token1);
            // 结果非 Null
            Assert.IsNotNull(logList);
            // 日志行数为2. （1次成功，1次失败）
            Assert.AreEqual(2, logList.Count);


            logList = this.tokenManager.GetTokenAccessLog(token2);
            // 结果非 Null
            Assert.IsNotNull(logList);
            // 日志行数为1. （1次失败）
            Assert.AreEqual(1, logList.Count);


        }






    }
}
