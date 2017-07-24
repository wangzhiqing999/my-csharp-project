using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using log4net;

using MyBallot.Model;
using MyBallot.DataAccess;
using MyBallot.Service;


namespace MyBallot.ServiceImpl
{

    /// <summary>
    /// 投票主表服务.
    /// </summary>
    public class DefaultBallotMasterService : IBallotMasterService
    {


        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        /// <summary>
        /// 获取有效的 投票主表 数据列表.
        /// </summary>
        /// <param name="typeCode"></param>
        /// <returns></returns>
        public BallotMaster GetActiveBallotMaster(string typeCode)
        {
            try
            {
                using (MyBallotContext context = new MyBallotContext())
                {
                    // 先检查 typeCode 是否存在.
                    var ballotType = context.BallotTypes.Find(typeCode);
                    if (ballotType == null)
                    {
                        logger.WarnFormat("外部传入了无法识别的类型代码 ： {0}", typeCode);
                        return null;
                    }


                    var query =
                        from data in context.BallotMasters.Include("BallotDetailList").Include("BallotTypeData")
                        where
                            // 类型.
                            data.BallotTypeCode == typeCode
                            // 今天的数据.
                            && data.BallotDate == DateTime.Today
                        select
                            data;
                    BallotMaster result = query.FirstOrDefault();


                    if (result == null)
                    {
                        // 当日数据不存在， 创建.
                        result = new BallotMaster()
                        {
                            // 类型代码.
                            BallotTypeCode = typeCode,
                            BallotTypeData = ballotType,
                            // 投票日期.
                            BallotDate = DateTime.Today,
                            // 投票明细.
                            BallotDetailList = new List<BallotDetail>(),
                        };


                        // 遍历明细.
                        List<BallotTypeDetail> typeDetailList = ballotType.BallotTypeDetailList;
                        foreach (var typeDetail in typeDetailList)
                        {
                            BallotDetail detail = new BallotDetail()
                            {
                                // 投票明细代码
                                BallotTypeDetailCode = typeDetail.BallotTypeDetailCode,
                                // 投票数.
                                BallotCount = typeDetail.DefaultBallotValue,
                            };

                            result.BallotDetailList.Add(detail);
                        }

                        context.BallotMasters.Add(result);
                        context.SaveChanges();
                    }


                    // 加载分类明细.
                    foreach (var detail in result.BallotDetailList)
                    {
                        detail.BallotTypeDetailData = context.BallotTypeDetails.Find(detail.BallotTypeDetailCode);
                    }


                    // 计算投票百分比.
                    result.CalculateBallotPercent();
                    
                    // 返回.
                    return result;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                return null;
            }

            

        }
    }


}
