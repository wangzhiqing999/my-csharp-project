using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


using MyArea.ServiceImpl;


namespace MyArea.Service.Test
{


    [TestClass]
    public class DefaultAreaInfoServiceTest
    {

        /// <summary>
        /// 测试的服务.
        /// </summary>
        protected IAreaInfoService areaInfoService;




        public DefaultAreaInfoServiceTest()
        {
            this.areaInfoService = new DefaultAreaInfoService();
        }





        [TestMethod]
        public void TestGetRootAreaInfoList()
        {
            var rootAreaList = this.areaInfoService.GetRootAreaInfoList();
            
            // 结果非空.
            Assert.IsNotNull(rootAreaList);

            // 行数大于0.
            Assert.IsTrue(rootAreaList.Count > 0);
        }




        [TestMethod]
        public void TestGetSubAreaInfoList()
        {
            var subAreaList = this.areaInfoService.GetSubAreaInfoList("9999");
            // 结果非空.
            Assert.IsNotNull(subAreaList);
            // 行数为0.
            Assert.IsTrue(subAreaList.Count == 0);


            subAreaList = this.areaInfoService.GetSubAreaInfoList("9130");
            // 结果非空.
            Assert.IsNotNull(subAreaList);
            // 行数为0.
            Assert.IsTrue(subAreaList.Count > 0);

        }




        [TestMethod]
        public void TestGetAllAreaInfoList()
        {
            var allAreaList = this.areaInfoService.GetAllAreaInfoList();

            // 结果非空.
            Assert.IsNotNull(allAreaList);

            // 行数大于0.
            Assert.IsTrue(allAreaList.Count > 0);
        }

    }
}
