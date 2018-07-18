using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyBuying.Service.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            CommodityServiceTest commodityServiceTest = new CommodityServiceTest();
            
            // 测试简单创建商品明细.
            commodityServiceTest.TestCreateCommodityDetail();
            
            // 测试按模板创建商品明细.
            commodityServiceTest.TestCreateCommodityDetailByTemplate();


            Console.WriteLine("Finish!");
            Console.ReadKey();
        }
    }
}
