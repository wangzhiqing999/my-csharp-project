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

    public class DefaultAccessStatisticsReportService : IAccessStatisticsReportService
    {



        public List<AccessTypeSummary> GetAccessTypeSummary(string accessTypeCode = null, DateTime? startDate = null, DateTime? finishDate = null)
        {
            using (MyAccessStatisticsContext context = new MyAccessStatisticsContext())
            {
                var query =
                    from data in context.AccessTypeSummarys
                    select data;

                // 指定了类型代码.
                if (!String.IsNullOrEmpty(accessTypeCode))
                {
                    query = query.Where(p => p.AccessTypeCode == accessTypeCode);
                }

                // 指定了开始时间.
                if (startDate != null)
                {
                    query = query.Where(p => p.AccessDate >= startDate.Value);
                }

                // 指定了结束时间.
                if (finishDate != null)
                {
                    query = query.Where(p => p.AccessDate < finishDate.Value.AddDays(1));
                }

                var resultList = query.ToList();

                return resultList;
            }
        }



        public List<AccessDetailSummary> GetAccessDetailSummary(string accessTypeCode = null, string accessDetailCode = null, DateTime? startDate = null, DateTime? finishDate = null)
        {
            using (MyAccessStatisticsContext context = new MyAccessStatisticsContext())
            {
                var query =
                    from data in context.AccessDetailSummarys
                    select data;

                // 指定了类型代码.
                if (!String.IsNullOrEmpty(accessTypeCode))
                {
                    query = query.Where(p => p.AccessTypeCode == accessTypeCode);
                }

                // 指定了明细代码.
                if (!String.IsNullOrEmpty(accessDetailCode))
                {
                    query = query.Where(p => p.DetailCode == accessDetailCode);
                }


                // 指定了开始时间.
                if (startDate != null)
                {
                    query = query.Where(p => p.AccessDate >= startDate.Value);
                }

                // 指定了结束时间.
                if (finishDate != null)
                {
                    query = query.Where(p => p.AccessDate < finishDate.Value.AddDays(1));
                }

                var resultList = query.ToList();

                return resultList;
            }
        }



        public List<AccessDetailLog> GetAccessDetailLog(string accessTypeCode = null, string accessDetailCode = null, DateTime? startDate = null, DateTime? finishDate = null, long? userID = null)
        {
            using (MyAccessStatisticsContext context = new MyAccessStatisticsContext())
            {
                var query =
                    from data in context.AccessDetailLogs
                    select data;

                // 指定了类型代码.
                if (!String.IsNullOrEmpty(accessTypeCode))
                {
                    query = query.Where(p => p.AccessTypeCode == accessTypeCode);
                }

                // 指定了明细代码.
                if (!String.IsNullOrEmpty(accessDetailCode))
                {
                    query = query.Where(p => p.DetailCode == accessDetailCode);
                }


                // 指定了开始时间.
                if (startDate != null)
                {
                    query = query.Where(p => p.AccessTime >= startDate.Value);
                }

                // 指定了结束时间.
                if (finishDate != null)
                {
                    query = query.Where(p => p.AccessTime < finishDate.Value.AddDays(1));
                }


                // 指定了 特定的用户.
                if (userID != null)
                {
                    query = query.Where(p => p.UserID == userID.Value);
                }

                var resultList = query.ToList();

                return resultList;
            }
        }
    }

}
