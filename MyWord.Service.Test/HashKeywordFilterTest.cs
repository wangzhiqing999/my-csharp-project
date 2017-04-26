using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


using MyWord.Service;
using MyWord.ServiceImpl;

namespace MyWord.Service.Test
{
    /// <summary>
    /// HashKeywordFilter 测试.
    /// </summary>
    [TestClass]
    public class HashKeywordFilterTest : DefaultKeywordsFilterTest
    {

        public override IKeywordsFilter GetKeywordsFilter()
        {
            return new HashKeywordFilter();
        }

    }
}
