using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using MyBuying.Model;
using MyBuying.DataAccess;
using MyBuying.Service;

using MyFramework.ServiceModel;


namespace MyBuying.ServiceImpl
{
    public class DefaultBuyingServiceImpl : IBuyingService
    {

        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        public List<CommodityDetail> GetCommodityDetailList(string commodityMasterCode, string batchCode, string commodityStatus)
        {
            using (MyBuyingContext context = new MyBuyingContext())
            {
                var query =
                    from data in context.CommodityDetails
                    where
                        data.CommodityMasterCode == commodityMasterCode
                        && data.BatchCode == batchCode
                        && data.CommodityStatus == commodityStatus
                    select
                        data;

                List<CommodityDetail> resultList = query.ToList();
                return resultList;
            }
        }



        public CommonServiceResult<long> GetFirstBuyableCommodityDetail(string commodityMasterCode, string batchCode, string buyerCode)
        {
            try
            {
                using (MyBuyingContext context = new MyBuyingContext())
                {
                    CommodityDetail detail = context.CommodityDetails.FirstOrDefault(p => 
                        p.CommodityMasterCode == commodityMasterCode 
                        && p.BatchCode == batchCode 
                        && p.CommodityStatus == CommodityDetail.COMMODITY_STATUS_IS_CREATED);

                    if (detail == null)
                    {
                        // 数据不存在.
                        return CommonServiceResult<long>.DataNotFoundResult;
                    }

                    // 修改状态.
                    detail.CommodityStatus = CommodityDetail.COMMODITY_STATUS_IS_LOCKED;

                    // 购买人.
                    detail.BuyerCode = buyerCode;

                    context.SaveChanges();

                    return CommonServiceResult<long>.CreateDefaultSuccessResult(detail.CommodityDetailID);
                }                
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                return new CommonServiceResult<long>(ex);
            }
        }



        public CommonServiceResult CreateOrder(long commodityDetailID, string buyerCode)
        {
            try
            {
                using (MyBuyingContext context = new MyBuyingContext())
                {
                    CommodityDetail detail = context.CommodityDetails.Find(commodityDetailID);
                    if (detail == null)
                    {
                        // 数据不存在.
                        return CommonServiceResult.DataNotFoundResult;
                    }

                    if (detail.CommodityStatus != CommodityDetail.COMMODITY_STATUS_IS_LOCKED)
                    {
                        CommonServiceResult errorResult = new CommonServiceResult()
                        {
                            ResultCode = "COMMODITY_STATUS_ERROR",
                            ResultMessage = "状态数据无效！",
                        };
                        return errorResult;
                    }

                    // 修改状态.
                    detail.CommodityStatus = CommodityDetail.COMMODITY_STATUS_IS_PAYING;

                    // 购买人.
                    detail.BuyerCode = buyerCode;

                    context.SaveChanges();
                }

                return CommonServiceResult.DefaultSuccessResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                return new CommonServiceResult(ex);
            }
            
        }



        public CommonServiceResult OrderTimeout(long commodityDetailID)
        {
            try
            {
                using (MyBuyingContext context = new MyBuyingContext())
                {
                    CommodityDetail detail = context.CommodityDetails.Find(commodityDetailID);
                    if (detail == null)
                    {
                        // 数据不存在.
                        return CommonServiceResult.DataNotFoundResult;
                    }

                    if (detail.CommodityStatus != CommodityDetail.COMMODITY_STATUS_IS_LOCKED
                        || detail.CommodityStatus != CommodityDetail.COMMODITY_STATUS_IS_PAYING)
                    {
                        CommonServiceResult errorResult = new CommonServiceResult()
                        {
                            ResultCode = "COMMODITY_STATUS_ERROR",
                            ResultMessage = "状态数据无效！",
                        };
                        return errorResult;
                    }

                    // 修改状态.
                    detail.CommodityStatus = CommodityDetail.COMMODITY_STATUS_IS_CREATED;
                    detail.BuyerCode = null;

                    context.SaveChanges();
                }

                return CommonServiceResult.DefaultSuccessResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                return new CommonServiceResult(ex);
            }
        }



        public CommonServiceResult<CommodityDetail> OrderPayed(long commodityDetailID)
        {
            try
            {
                using (MyBuyingContext context = new MyBuyingContext())
                {
                    CommodityDetail detail = context.CommodityDetails.Find(commodityDetailID);
                    if (detail == null)
                    {
                        // 数据不存在.
                        return CommonServiceResult<CommodityDetail>.DataNotFoundResult;
                    }

                    if (detail.CommodityStatus != CommodityDetail.COMMODITY_STATUS_IS_PAYING)
                    {
                        CommonServiceResult<CommodityDetail> errorResult = new CommonServiceResult<CommodityDetail>()
                        {
                            ResultCode = "COMMODITY_STATUS_ERROR",
                            ResultMessage = "状态数据无效！",
                        };
                        return errorResult;
                    }

                    // 修改状态.
                    detail.CommodityStatus = CommodityDetail.COMMODITY_STATUS_IS_PAYED;

                    context.SaveChanges();


                    return CommonServiceResult<CommodityDetail>.CreateDefaultSuccessResult(detail);
                }

                
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                return new CommonServiceResult<CommodityDetail>(ex);
            }

        }



        public CommonServiceResult CommodityDetailUsed(long commodityDetailID)
        {
            try
            {
                using (MyBuyingContext context = new MyBuyingContext())
                {
                    CommodityDetail detail = context.CommodityDetails.Find(commodityDetailID);
                    if (detail == null)
                    {
                        // 数据不存在.
                        return CommonServiceResult.DataNotFoundResult;
                    }

                    if (detail.CommodityStatus != CommodityDetail.COMMODITY_STATUS_IS_PAYED)
                    {
                        CommonServiceResult errorResult = new CommonServiceResult()
                        {
                            ResultCode = "COMMODITY_STATUS_ERROR",
                            ResultMessage = "状态数据无效！",
                        };
                        return errorResult;
                    }

                    // 修改状态.
                    detail.CommodityStatus = CommodityDetail.COMMODITY_STATUS_IS_USED;

                    context.SaveChanges();
                }

                return CommonServiceResult.DefaultSuccessResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                return new CommonServiceResult(ex);
            }
        }








        public CommonServiceResult CommodityDetailUsedByCode(string commodityMasterCode, string batchCode, string commodityDetailCode)
        {
            try
            {
                using (MyBuyingContext context = new MyBuyingContext())
                {
                    CommodityDetail detail = context.CommodityDetails.FirstOrDefault(p => 
                        p.CommodityMasterCode == commodityMasterCode
                        && p.BatchCode == batchCode
                        && p.CommodityDetailCode == commodityDetailCode);

                    if (detail == null)
                    {
                        // 数据不存在.
                        return CommonServiceResult.DataNotFoundResult;
                    }

                    if (detail.CommodityStatus != CommodityDetail.COMMODITY_STATUS_IS_PAYED)
                    {
                        CommonServiceResult errorResult = new CommonServiceResult()
                        {
                            ResultCode = "COMMODITY_STATUS_ERROR",
                            ResultMessage = "状态数据无效！",
                        };
                        return errorResult;
                    }

                    // 修改状态.
                    detail.CommodityStatus = CommodityDetail.COMMODITY_STATUS_IS_USED;

                    context.SaveChanges();
                }

                return CommonServiceResult.DefaultSuccessResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                return new CommonServiceResult(ex);
            }
        }


    }
}
