using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBuying.ServiceModel
{
    public class BuyingData
    {


        /// <summary>
        /// 商品主表代码
        /// </summary>
        public string CommodityMasterCode { set; get; }



        /// <summary>
        /// 批次代码
        /// </summary>
        public string Batch {set;get;}



        /// <summary>
        /// 购买者代码
        /// </summary>
        public string BuyerCode { set; get; }


    }
}
