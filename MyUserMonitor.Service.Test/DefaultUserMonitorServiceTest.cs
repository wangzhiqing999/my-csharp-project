using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


using MyUserMonitor.ServiceImpl;



namespace MyUserMonitor.Service.Test
{
    [TestClass]
    public class DefaultUserMonitorServiceTest
    {


        DefaultUserMonitorService userMonitorService = DefaultUserMonitorService.GetUserMonitorService();



        [TestMethod]
        public void TestUserAccess()
        {
            for (int i = 1; i <= 10; i++)
            {
                // 用户进入.
                this.userMonitorService.UserAccess("TEST", "user00" + i);
                // 获取当前在线列表.
                var userList = this.userMonitorService.GetCurrentUserList();

                // 列表非空.
                Assert.IsNotNull(userList);
                // 用户数.
                Assert.AreEqual( i, userList.Count);
            }


            System.Threading.Thread.Sleep(1000);


            for (int i = 1; i <= 10; i++)
            {
                // 用户重复进入.
                this.userMonitorService.UserAccess("TEST", "user00" + i);
                // 获取当前在线列表.
                var userList = this.userMonitorService.GetCurrentUserList();

                // 列表非空.
                Assert.IsNotNull(userList);
                // 用户数.
                Assert.AreEqual(10, userList.Count);
            }

            // 获取当前在线列表.
            var currentUserList = this.userMonitorService.GetCurrentUserList();
            
            for (int i = 0; i < currentUserList.Count; i++)
            {
                var userData = currentUserList[i];
                // 用户数据非空.
                Assert.IsNotNull(userData);
                // 用户名.
                Assert.AreEqual("user00" + (i+1), userData.UserName);

                // 用户的 离开时间. 应该与进入时间不同.
                Assert.AreNotEqual(userData.EnterTime, userData.LastAccessTime);

            }

        }


    }
}
