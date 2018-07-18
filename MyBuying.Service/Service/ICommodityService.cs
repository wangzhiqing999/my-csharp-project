using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyFramework.ServiceModel;

namespace MyBuying.Service
{

    /// <summary>
    /// 商品服务.
    /// </summary>
    public interface ICommodityService
    {

        /// <summary>
        /// 简单创建商品明细.
        /// </summary>
        /// <param name="commodityMasterCode">商品主表代码</param>
        /// <param name="batchCode">批次代码</param>
        /// <param name="count">创建的数量.</param>
        /// <returns></returns>
        CommonServiceResult CreateCommodityDetail(string commodityMasterCode, string batchCode, int count);



        /// <summary>
        /// 根据模板创建商品明细.
        /// </summary>
        /// <param name="commodityMasterCode"></param>
        /// <param name="batchCode"></param>
        /// <returns></returns>
        CommonServiceResult CreateCommodityDetailByTemplate(string commodityMasterCode, string batchCode);


    }
}
