using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


using MyWord.Service;
using MyWord.ServiceImpl;



namespace MyWord.Service.Test
{

    /// <summary>
    /// DefaultKeywordsFilter 测试.
    /// </summary>
    [TestClass]
    public class DefaultKeywordsFilterTest
    {



        public virtual IKeywordsFilter GetKeywordsFilter()
        {
            return new DefaultKeywordsFilter();
        }


        /// <summary>
        /// 初始化关键字.
        /// </summary>
        /// <param name="filter"></param>
        public virtual void InitKeywords(IKeywordsFilter filter)
        {
            // 增加关键字.

            // 普通的关键字.
            filter.AddKeyword("北京");
            filter.AddKeyword("上海");
            filter.AddKeyword("广州");
            filter.AddKeyword("深圳");


            // 较长的关键字，目的是测试 替换的时候， 会优先替换长的，而不是短的。
            filter.AddKeyword("上海地铁");


            // 长度为一的关键字， 目的是测试，如果关键字级短的情况下， 算法是否会发生问题。
            filter.AddKeyword("X");
            filter.AddKeyword("短");
        }



        /// <summary>
        /// 不存在关键字的字符串.
        /// </summary>
        private const string NO_KEYWORD_STRING = "测试一个不存在的关键字的字符串";


        /// <summary>
        /// 存在一个关键字的字符串
        /// </summary>
        private const string EXISTS_ONE_KEYWORD_STRING = "北京市朝阳区静安东里12号院国门大厦B座";


        /// <summary>
        /// 存在一组（一长一短）关键字的字符串
        /// </summary>
        private const string EXISTS_ONE_GROUP_KEYWORD_STRING = "怎么走，才能到上海地铁哪里？";


        /// <summary>
        /// 存在两个关键字的字符串
        /// </summary>
        private const string EXISTS_TWO_KEYWORD_STRING = "您所乘坐的列车，是由北京开往上海的列车！";


        /// <summary>
        /// 很短的关键字.
        /// </summary>
        private const string EXISTS_SHORT_KEYWORD_STRING = "测试一个很短的关键字，内容为X。";


        /// <summary>
        /// 字符串既是关键字.
        /// </summary>
        private const string KEYWORD_ONLY_STRING = "短";



        /// <summary>
        /// 测试 HasKeyword.
        /// </summary>
        [TestMethod]
        public void TestHasKeyword()
        {
            // 获取 Filter.
            IKeywordsFilter filter = this.GetKeywordsFilter();
            // 初始化关键字
            this.InitKeywords(filter);


            // 不存在的情况.
            bool result = filter.HasKeyword(NO_KEYWORD_STRING);
            // 预期结果为 false.
            Assert.IsFalse(result);


            // 存在一个的情况.
            result = filter.HasKeyword(EXISTS_ONE_KEYWORD_STRING);
            // 预期结果为 true.
            Assert.IsTrue(result);


            // 存在一组（一长一短）的情况.
            result = filter.HasKeyword(EXISTS_ONE_GROUP_KEYWORD_STRING);
            // 预期结果为 true.
            Assert.IsTrue(result);


            // 存在两个的情况.
            result = filter.HasKeyword(EXISTS_TWO_KEYWORD_STRING);
            // 预期结果为 true.
            Assert.IsTrue(result);




            // 关键字很短的情况.
            result = filter.HasKeyword(EXISTS_SHORT_KEYWORD_STRING);
            // 预期结果为 true.
            Assert.IsTrue(result);


            // 字符串就是关键字情况.
            result = filter.HasKeyword(KEYWORD_ONLY_STRING);
            // 预期结果为 true.
            Assert.IsTrue(result);
        }




        /// <summary>
        /// 测试 FindOne.
        /// </summary>
        [TestMethod]
        public void TestFindOne()
        {
            // 获取 Filter.
            IKeywordsFilter filter = this.GetKeywordsFilter();
            // 初始化关键字
            this.InitKeywords(filter);


            // 不存在的情况.
            string result = filter.FindOne(NO_KEYWORD_STRING);
            // 预期结果为 String.Empty.
            Assert.AreEqual(String.Empty, result);


            // 存在的情况.
            result = filter.FindOne(EXISTS_ONE_KEYWORD_STRING);
            // 预期结果为 北京.
            Assert.AreEqual("北京", result);


            // 存在一组（一长一短）的情况.
            result = filter.FindOne(EXISTS_ONE_GROUP_KEYWORD_STRING);
            // 预期结果为 上海 或者 上海地铁 .
            Assert.IsTrue(result == "上海" || result == "上海地铁");


            // 存在两个的情况.
            result = filter.FindOne(EXISTS_TWO_KEYWORD_STRING);
            // 预期结果为 北京.
            Assert.AreEqual("北京", result);



            // 关键字很短的情况.
            result = filter.FindOne(EXISTS_SHORT_KEYWORD_STRING);
            // 预期结果为 X 或者 短 .
            Assert.IsTrue(result == "X" || result == "短");


            // 字符串就是关键字情况.
            result = filter.FindOne(KEYWORD_ONLY_STRING);
            // 预期结果为 短 .
            Assert.AreEqual("短", result);
        }



        /// <summary>
        /// 测试 FindAll.
        /// </summary>
        [TestMethod]
        public void TestFindAll()
        {
            // 获取 Filter.
            IKeywordsFilter filter = this.GetKeywordsFilter();
            // 初始化关键字
            this.InitKeywords(filter);

            // 不存在的情况.
            IEnumerable<string> result = filter.FindAll(NO_KEYWORD_STRING);
            // 预期结果为空白列表.
            Assert.AreEqual(0, result.Count());


            // 存在一个的情况.
            result = filter.FindAll(EXISTS_ONE_KEYWORD_STRING);
            // 预期结果为 北京.
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("北京", result.First());


            // 存在一组（一长一短）的情况.
            result = filter.FindAll(EXISTS_ONE_GROUP_KEYWORD_STRING);
            // 预期结果为 上海 与 上海地铁 .
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(1, result.Count(p => p == "上海"));
            Assert.AreEqual(1, result.Count(p => p == "上海地铁"));


            // 存在两个的情况.
            result = filter.FindAll(EXISTS_TWO_KEYWORD_STRING);
            // 预期结果为 北京. 上海
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(1, result.Count(p => p == "北京"));
            Assert.AreEqual(1, result.Count(p => p == "上海"));



            // 关键字很短的情况.
            result = filter.FindAll(EXISTS_SHORT_KEYWORD_STRING);
            // 预期结果为 X. 短
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(1, result.Count(p => p == "X"));
            Assert.AreEqual(1, result.Count(p => p == "短"));


            // 字符串就是关键字情况.
            result = filter.FindAll(KEYWORD_ONLY_STRING);
            // 预期结果为 短.
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("短", result.First());
        }





        /// <summary>
        /// 测试 Replace.
        /// </summary>
        [TestMethod]
        public void TestReplace()
        {
            // 获取 Filter.
            IKeywordsFilter filter = this.GetKeywordsFilter();
            // 初始化关键字
            this.InitKeywords(filter);


            // 不存在的情况.
            string result = filter.Replace(NO_KEYWORD_STRING, '*');
            // 预期结果为 原始字符串.
            Assert.AreEqual(NO_KEYWORD_STRING, result);


            // 存在的情况.
            result = filter.Replace(EXISTS_ONE_KEYWORD_STRING, '*');
            // 预期结果 .
            Assert.AreEqual("**市朝阳区静安东里12号院国门大厦B座", result);


            // 存在一组（一长一短）的情况.
            result = filter.Replace(EXISTS_ONE_GROUP_KEYWORD_STRING, '*');
            // 预期结果为 怎么走，才能到****哪里？ 或者 怎么走，才能到**地铁哪里？ .
            Assert.IsTrue(result == "怎么走，才能到****哪里？" || result == "怎么走，才能到**地铁哪里？");



            // 存在两个的情况.
            result = filter.Replace(EXISTS_TWO_KEYWORD_STRING, '*');
            // 预期结果.
            Assert.AreEqual("您所乘坐的列车，是由**开往**的列车！", result);




            // 关键字很短的情况.
            result = filter.Replace(EXISTS_SHORT_KEYWORD_STRING, '*');
            // 预期结果.
            Assert.AreEqual("测试一个很*的关键字，内容为*。", result);


            // 字符串就是关键字情况.
            result = filter.Replace(KEYWORD_ONLY_STRING, '*');
            // 预期结果.
            Assert.AreEqual("*", result);
        }

    }
}
