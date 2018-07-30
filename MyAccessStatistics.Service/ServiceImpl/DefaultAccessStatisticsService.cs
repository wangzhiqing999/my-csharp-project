using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MyAccessStatistics.Model;
using MyAccessStatistics.DataAccess;
using MyAccessStatistics.Service;


namespace MyAccessStatistics.ServiceImpl
{

    /// <summary>
    /// 访问汇总服务.
    /// </summary>
    public class DefaultAccessStatisticsService : IAccessStatisticsService
    {


        /// <summary>
        /// 更新访问类型明细.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="accessTypeCode"></param>
        /// <param name="accessDetailCode"></param>
        private void UpdateAccessDetail(MyAccessStatisticsContext context, string accessTypeCode, string accessDetailCode)
        {
            // 检查， 访问明细 是否存在.
            AccessDetail accessDetail = context.AccessDetails.Find(accessTypeCode, accessDetailCode);
            if (accessDetail == null)
            {
                // 未知的明细， 自动创建.
                accessDetail = new AccessDetail()
                {
                    AccessTypeCode = accessTypeCode,
                    DetailCode = accessDetailCode,
                };
                // 新增.
                context.AccessDetails.Add(accessDetail);
            }
        }


        /// <summary>
        /// 更新访问类型汇总.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="accessTypeCode"></param>
        private void UpdateAccessTypeSummary(MyAccessStatisticsContext context, string accessTypeCode)
        {
            AccessTypeSummary data = context.AccessTypeSummarys.Find(accessTypeCode, DateTime.Today);
            if (data == null)
            {
                // 当日数据不存在， 则新增.
                data = new AccessTypeSummary()
                {
                    AccessTypeCode = accessTypeCode,
                    AccessDate = DateTime.Today,
                    AccessCount = 1,
                };

                context.AccessTypeSummarys.Add(data);
            }
            else
            {
                // 当日数据已存在. 简单 访问次数递增.
                data.AccessCount++;
            }
        }




        /// <summary>
        /// 更新访问类型明细汇总
        /// </summary>
        /// <param name="context"></param>
        /// <param name="accessTypeCode"></param>
        /// <param name="accessDetailCode"></param>
        private void UpdateAccessDetailSummary(MyAccessStatisticsContext context, string accessTypeCode, string accessDetailCode)
        {
            AccessDetailSummary data = context.AccessDetailSummarys.Find(accessTypeCode, accessDetailCode, DateTime.Today);
            if (data == null)
            {
                // 当日数据不存在， 则新增.
                data = new AccessDetailSummary()
                {
                    AccessTypeCode = accessTypeCode,
                    DetailCode = accessDetailCode,
                    AccessDate = DateTime.Today,
                    AccessCount = 1,
                };

                context.AccessDetailSummarys.Add(data);
            }
            else
            {
                // 当日数据已存在. 简单 访问次数递增.
                data.AccessCount++;
            }
        }




        /// <summary>
        /// 新增访问类型明细日志.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="accessTypeCode"></param>
        /// <param name="accessDetailCode"></param>
        /// <param name="expInfo"></param>
        private void NewAccessDetailLog(MyAccessStatisticsContext context, string accessTypeCode, string accessDetailCode, long? userID, string expInfo = null)
        {
            AccessDetailLog log = new AccessDetailLog()
            {
                AccessTypeCode = accessTypeCode,
                DetailCode = accessDetailCode,
                AccessTime = DateTime.Now,
                UserID = userID,
                ExpInfo = expInfo,
            };

            context.AccessDetailLogs.Add(log);
        }






        public bool NewAccess(string accessTypeCode, string accessDetailCode, bool isSaveDetailLog, long? userID, ref string resultMsg)
        {

            using (MyAccessStatisticsContext context = new MyAccessStatisticsContext())
            {
                // 先检查 访问类型代码是否存在.
                AccessType accessType = context.AccessTypes.Find(accessTypeCode);
                if (accessType == null)
                {
                    // 未知的分类
                    resultMsg = "未知的访问类型！";
                    return false;
                }


                
                // 更新访问类型明细.
                this.UpdateAccessDetail(context, accessTypeCode, accessDetailCode);


                // 更新访问类型汇总
                this.UpdateAccessTypeSummary(context, accessTypeCode);

                // 更新访问类型明细汇总.
                this.UpdateAccessDetailSummary(context, accessTypeCode, accessDetailCode);


                if (isSaveDetailLog)
                {
                    // 新增访问类型明细日志
                    this.NewAccessDetailLog(context, accessTypeCode, accessDetailCode, userID);
                }


                context.SaveChanges();

                resultMsg = "success";
                return true;
            }
        }




    }


}
