using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyBuying.Service;
using MyBuying.ServiceImpl;
using MyFramework.ServiceModel;


namespace MyBuying.Service.Test
{
    class CommodityServiceTest
    {

        private ICommodityService commodityService = new DefaultCommodityServiceImpl();


        public void TestCreateCommodityDetail()
        {
            string batch = DateTime.Today.ToString("MMdd");
            CommonServiceResult result = this.commodityService.CreateCommodityDetail("TEST2", batch, 5);
            CommonServiceResult result2 = this.commodityService.CreateCommodityDetail("TEST3", String.Empty, 5);
        }


        public void TestCreateCommodityDetailByTemplate()
        {
            string batch = DateTime.Today.ToString("MMdd");
            CommonServiceResult result = this.commodityService.CreateCommodityDetailByTemplate("TEST", batch);
        }



    }
}
