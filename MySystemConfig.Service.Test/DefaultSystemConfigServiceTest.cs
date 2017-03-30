﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


using MySystemConfig.Model;
using MySystemConfig.Service;
using MySystemConfig.ServiceImpl;


namespace MySystemConfig.Service.Test
{
    [TestClass]
    public class DefaultSystemConfigServiceTest
    {

        /// <summary>
        /// 系统配置服务.
        /// </summary>
        private ISystemConfigService systemConfigService = new DefaultSystemConfigService();



        /// <summary>
        /// 测试错误的输入.
        /// </summary>
        [TestMethod]
        public void TestBadInput()
        {
            SystemConfigValue configValue1 = new SystemConfigValue()
            {
                // 类型代码.
                ConfigTypeCode = "",
                // 配置代码
                ConfigCode = "123",
                // 配置名称.
                ConfigName = "测试类型代码为空时报错.",
                // 配置数值.
                ConfigValueObject = "Test Error 001",
            };

            SystemConfigValue configValue2 = new SystemConfigValue()
            {
                // 类型代码.
                ConfigTypeCode = "123",
                // 配置代码
                ConfigCode = "",
                // 配置名称.
                ConfigName = "测试代码为空时报错.",
                // 配置数值.
                ConfigValueObject = "Test Error 002",
            };

            SystemConfigValue configValue3 = new SystemConfigValue()
            {
                // 类型代码.
                ConfigTypeCode = "TEST_NOT_EXISTS_CODE",
                // 配置代码
                ConfigCode = "123",
                // 配置名称.
                ConfigName = "测试不存在的类型代码时报错.",
                // 配置数值.
                ConfigValueObject = "Test Error 003",
            };

            string resultMsg = null;
            bool result = this.systemConfigService.UpdateSystemConfigValue(configValue1, ref resultMsg);
            Assert.IsFalse(result);


            result = this.systemConfigService.UpdateSystemConfigValue(configValue2, ref resultMsg);
            Assert.IsFalse(result);


            result = this.systemConfigService.UpdateSystemConfigValue(configValue3, ref resultMsg);
            Assert.IsFalse(result);
        }




        [TestMethod]
        public void TestString()
        {
            SystemConfigValue configValue1 = new SystemConfigValue()
            {
                // 类型代码.
                ConfigTypeCode = "TEST_STRING",
                // 配置代码
                ConfigCode = "TEST1",
                // 配置名称.
                ConfigName = "测试项目1",
                // 配置数值.
                ConfigValueObject = "Test 001",
            };

            SystemConfigValue configValue2 = new SystemConfigValue()
            {
                // 类型代码.
                ConfigTypeCode = "TEST_STRING",
                // 配置代码
                ConfigCode = "TEST2",
                // 配置名称.
                ConfigName = "测试项目2",
                // 配置数值.
                ConfigValueObject = "Test 002",
            };


            // 先更新.
            string resultMsg = null;
            bool result = this.systemConfigService.UpdateSystemConfigValue(configValue1, ref resultMsg);
            Assert.IsTrue(result);

            result = this.systemConfigService.UpdateSystemConfigValue(configValue2, ref resultMsg);
            Assert.IsTrue(result);


            // 后查询.
            var dataList = this.systemConfigService.GetSystemConfigValueByType("TEST_STRING");

            // 结果数据非空.
            Assert.IsNotNull(dataList);

            // 行数为2.
            Assert.AreEqual(2, dataList.Count);



            Assert.AreEqual(configValue1.ConfigValueObject, dataList[0].ConfigValueObject);
            Assert.AreEqual(configValue2.ConfigValueObject, dataList[1].ConfigValueObject);

        }



        [TestMethod]
        public void TestInt32()
        {
            SystemConfigValue configValue1 = new SystemConfigValue()
            {
                // 类型代码.
                ConfigTypeCode = "TEST_INT32",
                // 配置代码
                ConfigCode = "TEST1",
                // 配置名称.
                ConfigName = "测试项目1",
                // 配置数值.
                ConfigValueObject = 100,
            };

            SystemConfigValue configValue2 = new SystemConfigValue()
            {
                // 类型代码.
                ConfigTypeCode = "TEST_INT32",
                // 配置代码
                ConfigCode = "TEST2",
                // 配置名称.
                ConfigName = "测试项目2",
                // 配置数值.
                ConfigValueObject = 200,
            };


            // 先更新.
            string resultMsg = null;
            bool result = this.systemConfigService.UpdateSystemConfigValue(configValue1, ref resultMsg);
            Assert.IsTrue(result);

            result = this.systemConfigService.UpdateSystemConfigValue(configValue2, ref resultMsg);
            Assert.IsTrue(result);


            // 后查询.
            var dataList = this.systemConfigService.GetSystemConfigValueByType("TEST_INT32");

            // 结果数据非空.
            Assert.IsNotNull(dataList);

            // 行数为2.
            Assert.AreEqual(2, dataList.Count);


            Assert.AreEqual(configValue1.ConfigValueObject, dataList[0].ConfigValueObject);
            Assert.AreEqual(configValue2.ConfigValueObject, dataList[1].ConfigValueObject);
        }





        [TestMethod]
        public void TestObject()
        {
            SystemConfigValue configValue1 = new SystemConfigValue()
            {
                // 类型代码.
                ConfigTypeCode = "TEST_OBJ",
                // 配置代码
                ConfigCode = "TEST1",
                // 配置名称.
                ConfigName = "测试项目1",
                // 配置数值.
                ConfigValueObject = new MyTestUser()
                {
                    Name = "张三",
                    Age = 25,
                    Address = "北京"
                },
            };

            SystemConfigValue configValue2 = new SystemConfigValue()
            {
                // 类型代码.
                ConfigTypeCode = "TEST_OBJ",
                // 配置代码
                ConfigCode = "TEST2",
                // 配置名称.
                ConfigName = "测试项目2",
                // 配置数值.
                ConfigValueObject = new MyTestUser()
                {
                    Name = "李四",
                    Age = 30,
                    Address = "上海"
                },
            };


            // 先更新.
            string resultMsg = null;
            bool result = this.systemConfigService.UpdateSystemConfigValue(configValue1, ref resultMsg);
            Assert.IsTrue(result);

            result = this.systemConfigService.UpdateSystemConfigValue(configValue2, ref resultMsg);
            Assert.IsTrue(result);


            // 后查询.
            var dataList = this.systemConfigService.GetSystemConfigValueByType("TEST_OBJ");

            // 结果数据非空.
            Assert.IsNotNull(dataList);

            // 行数为2.
            Assert.AreEqual(2, dataList.Count);


            Assert.AreEqual(configValue1.ConfigValueObject, dataList[0].ConfigValueObject);
            Assert.AreEqual(configValue2.ConfigValueObject, dataList[1].ConfigValueObject);
        }






    }




    /// <summary>
    /// 测试用户.
    /// </summary>
    public class MyTestUser
    {
        /// <summary>
        /// 姓名.
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 年龄.
        /// </summary>
        public int Age { set; get; }

        /// <summary>
        /// 地址.
        /// </summary>
        public string Address { set; get; }



        public override bool Equals(object obj)
        {
            if (!(obj is MyTestUser))
            {
                // 目标对象不是 MyTestUser
                return false;
            }

            MyTestUser otherObj = obj as MyTestUser;

            if (!String.Equals(otherObj.Name, this.Name))
            {
                // 姓名不一致.
                return false;
            }

            if (otherObj.Age != this.Age)
            {
                // 年龄不一致.
                return false;
            }

            if (!String.Equals(otherObj.Address, this.Address))
            {
                // 地址不一致.
                return false;
            }

            // 如果执行到这里， 认为是一致的.
            return true;
        }

    }


}
