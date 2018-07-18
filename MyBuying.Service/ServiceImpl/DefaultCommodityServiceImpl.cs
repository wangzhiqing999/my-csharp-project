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

    /// <summary>
    /// 商品服务
    /// </summary>
    public class DefaultCommodityServiceImpl : ICommodityService
    {
        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        /// 简单创建商品明细
        /// </summary>
        /// <param name="commodityMasterCode"></param>
        /// <param name="batchCode"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public CommonServiceResult CreateCommodityDetail(string commodityMasterCode, string batchCode, int count)
        {
            try
            {
                using (MyBuyingContext context = new MyBuyingContext())
                {

                    // 先查询 商品主表是否存在.
                    CommodityMaster commodityMaster = context.CommodityMasters.Find(commodityMasterCode);
                    if (commodityMaster == null)
                    {
                        // 数据不存在.
                        return CommonServiceResult.DataNotFoundResult;
                    }

                    // 再查询， 相同的商品主表代码+批次， 是否已存在有数据.
                    int dbDataCount = context.CommodityDetails.Count(p => p.CommodityMasterCode == commodityMasterCode && p.BatchCode == batchCode);
                    if (dbDataCount > 0)
                    {
                        // 数据已存在.
                        return CommonServiceResult.DataHadExistsResult;
                    }

                    if (count <= 0)
                    {
                        CommonServiceResult  errorResult = new CommonServiceResult()
                        {
                            ResultCode = "COUNT_MUST_MORE_THAN_ZERO",
                            ResultMessage = "数量必须大于零。",
                        };
                        return errorResult;
                    }


                    HashSet<int> resultCodes = new HashSet<int>();
                    Random random = new Random();

                    while (resultCodes.Count < count)
                    {
                        int num = random.Next(1, 99999999);
                        if (!resultCodes.Contains(num)) {
                            resultCodes.Add(num);
                        }
                    }

                    foreach (int num in resultCodes)
                    {
                        CommodityDetail commodityDetail = new CommodityDetail()
                        {
                            // 主表代码.
                            CommodityMasterCode = commodityMasterCode,
                            // 批次.
                            BatchCode = batchCode,
                            // 明细代码.
                            CommodityDetailCode = num.ToString("00000000"),

                            // 商品状态 : 可用.
                            CommodityStatus = CommodityDetail.COMMODITY_STATUS_IS_CREATED,
                        };

                        context.CommodityDetails.Add(commodityDetail);
                    }

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



        /// <summary>
        /// 根据模板创建商品明细
        /// </summary>
        /// <param name="commodityMasterCode"></param>
        /// <param name="batchCode"></param>
        /// <returns></returns>
        public CommonServiceResult CreateCommodityDetailByTemplate(string commodityMasterCode, string batchCode)
        {
            try
            {
                using (MyBuyingContext context = new MyBuyingContext())
                {
                    // 先查询 商品主表是否存在.
                    CommodityMaster commodityMaster = context.CommodityMasters.Find(commodityMasterCode);
                    if (commodityMaster == null)
                    {
                        // 数据不存在.
                        return CommonServiceResult.DataNotFoundResult;
                    }

                    // 再获取模板数据.
                    List<CommodityDetailTemplate> templateDataList = context.CommodityDetailTemplates.Where(p => p.CommodityMasterCode == commodityMasterCode).ToList();
                    if (templateDataList.Count == 0)
                    {
                        CommonServiceResult errorResult = new CommonServiceResult()
                        {
                            ResultCode = "WITHOUT_TEMPLATE_DATA",
                            ResultMessage = "未查询到模板数据",
                        };
                        return errorResult;
                    }

                    // 再查询， 相同的商品主表代码+批次， 是否已存在有数据.
                    int dbDataCount = context.CommodityDetails.Count(p => p.CommodityMasterCode == commodityMasterCode && p.BatchCode == batchCode);
                    if (dbDataCount > 0)
                    {
                        // 数据已存在.
                        return CommonServiceResult.DataHadExistsResult;
                    }


                    HashSet<int> resultCodes = new HashSet<int>();
                    Random random = new Random();

                    while (resultCodes.Count < templateDataList.Count)
                    {
                        int num = random.Next(1, 99999999);
                        if (!resultCodes.Contains(num))
                        {
                            resultCodes.Add(num);
                        }
                    }

                    // 索引.
                    var index = 0;
                    foreach (int num in resultCodes)
                    {
                        CommodityDetail commodityDetail = new CommodityDetail()
                        {
                            // 主表代码.
                            CommodityMasterCode = commodityMasterCode,
                            // 批次.
                            BatchCode = batchCode,
                            // 明细代码.
                            CommodityDetailCode = num.ToString("00000000"),

                            // 商品状态 : 可用.
                            CommodityStatus = CommodityDetail.COMMODITY_STATUS_IS_CREATED,

                            // 附加数据.
                            CommodityDetailExpData = templateDataList[index].CommodityDetailExpData,
                        };

                        context.CommodityDetails.Add(commodityDetail);
                        index++;
                    }

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
