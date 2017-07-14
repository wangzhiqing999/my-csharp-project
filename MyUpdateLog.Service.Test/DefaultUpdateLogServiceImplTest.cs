using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


using MyUpdateLog.Model;
using MyUpdateLog.DataAccess;
using MyUpdateLog.ServiceImpl;



namespace MyUpdateLog.Service.Test
{



    // 测试前，先执行 sql 脚本.
    [TestClass]
    public class DefaultUpdateLogServiceImplTest
    {


        [TestMethod]
        public void TestSaveUpdateLog()
        {

            // 待测试服务.
            IUpdateLogService service = new DefaultUpdateLogServiceImpl();



            // 以自己的分类表为例子， 进行模拟测试.
            using (MyUpdateLogContext context = new MyUpdateLogContext())
            {
                // 模拟： 更新前数据.
                var beforeData = context.UpdateLogCategorys.FirstOrDefault(p => p.CategoryCode == "TEST_INSERT");

                // 模拟：更新后数据.
                var afterData = new UpdateLogCategory() {
                    CategoryCode = "TEST_INSERT",
                    CategoryName = "（更新后）"
                };                

                // 测试 
                string resultMsg = null;


                // 测试插入.
                bool testInsert = service.SaveUpdateLog("TEST_INSERT", afterData.CategoryCode, "测试用户1", null, afterData, ref resultMsg);
                // 处理应该成功.
                Assert.IsTrue(testInsert);


                // 测试更新.
                bool testUpdate = service.SaveUpdateLog("TEST_UPDATE", afterData.CategoryCode, "测试用户2", beforeData, afterData, ref resultMsg);
                // 处理应该成功.
                Assert.IsTrue(testUpdate);


                // 测试删除.
                bool testDelete = service.SaveUpdateLog("TEST_DELETE", beforeData.CategoryCode, "测试用户3", beforeData, null, ref resultMsg);
                // 处理应该成功.
                Assert.IsTrue(testDelete);

            }



        }




    }
}
