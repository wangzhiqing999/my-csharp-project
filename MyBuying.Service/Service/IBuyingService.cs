using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyBuying.Model;
using MyFramework.ServiceModel;


namespace MyBuying.Service
{

    public interface IBuyingService
    {

        /// <summary>
        /// 获取商品明细列表.
        /// </summary>
        /// <param name="commodityMasterCode">商品主表代码</param>
        /// <param name="batchCode">批次代码</param>
        /// <param name="commodityStatus">商品状态</param>
        /// <returns></returns>
        List<CommodityDetail> GetCommodityDetailList(string commodityMasterCode, string batchCode, string commodityStatus);



        /// <summary>
        /// 获取第一个可购买的商品明细.
        /// [CREATED] ---> [LOCKED]
        /// </summary>
        /// <param name="commodityMasterCode"></param>
        /// <param name="batchCode"></param>
        /// <returns></returns>
        CommonServiceResult<long> GetFirstBuyableCommodityDetail(string commodityMasterCode, string batchCode, string buyerCode);



        /// <summary>
        /// 创建订单 (购买操作)
        /// [LOCKED] ---> [PAYING]
        /// </summary>
        /// <param name="buyerCode"></param>
        /// <param name="commodityDetailID"></param>
        /// <returns></returns>
        CommonServiceResult CreateOrder(long commodityDetailID, string buyerCode);


        /// <summary>
        /// 订单超时处理  (购买后未付款，释放资源操作)
        /// [LOCKED] ---> [CREATED] 
        /// [PAYING] ---> [CREATED] 
        /// (注：此操作可考虑在数据库层面做批处理. 前提是 商品明细表，需要有一个 最后更新时间)
        /// </summary>
        /// <param name="commodityDetailID"></param>
        /// <returns></returns>
        CommonServiceResult OrderTimeout(long commodityDetailID);


        /// <summary>
        /// 订单完成支付处理 (购买后付款，确定资源占用操作)
        /// [PAYING] ---> [PAYED]
        /// </summary>
        /// <param name="commodityDetailID"></param>
        /// <returns></returns>
        CommonServiceResult<CommodityDetail> OrderPayed(long commodityDetailID);





        /// <summary>
        /// 商品完成使用 (购买后付款，正式使用资源的操作)
        /// [PAYED] ---> [USED]
        /// 
        /// 此方法为线上直接使用的，这种情况下，知道 商品明细的ID.
        /// 
        /// </summary>
        /// <param name="commodityDetailID"></param>
        /// <returns></returns>
        CommonServiceResult CommodityDetailUsed(long commodityDetailID);



        /// <summary>
        /// 商品完成使用 (购买后付款，正式使用资源的操作)
        /// [PAYED] ---> [USED]
        /// 此方法为线下使用的
        /// 
        /// 这种情况下，主办方持有 总代码与批次代码，   用户持有 明细代码。
        /// 
        /// </summary>
        /// <param name="commodityMasterCode">主表代码</param>
        /// <param name="batchCode">批次</param>
        /// <param name="commodityDetailCode">明细代码</param>
        /// <returns></returns>
        CommonServiceResult CommodityDetailUsedByCode(string commodityMasterCode, string batchCode, string commodityDetailCode);

    }
}
