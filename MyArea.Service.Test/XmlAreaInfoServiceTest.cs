using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


using MyArea.ServiceImpl;


namespace MyArea.Service.Test
{


    [TestClass]
    public class XmlAreaInfoServiceTest : DefaultAreaInfoServiceTest
    {


        public XmlAreaInfoServiceTest()
        {
            this.areaInfoService = new XmlAreaInfoService("AreaInfo.xml");
        }

    }
}
