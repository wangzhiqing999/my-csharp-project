using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using MyAccessStatistics.ServiceImpl;



namespace MyAccessStatistics.Service.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DefaultAccessStatisticsService accessStatisticsService = new DefaultAccessStatisticsService();

            string resultMsg = null;
            bool result;

            result = accessStatisticsService.NewAccess("TEST", "1", false, ref resultMsg);
            Console.WriteLine("NewAccess!  Result = {0}, MEssage = {1}", result, resultMsg);


            Thread.Sleep(1000);


            result = accessStatisticsService.NewAccess("TEST", "1", false, ref resultMsg);
            Console.WriteLine("NewAccess!  Result = {0}, MEssage = {1}", result, resultMsg);


            Thread.Sleep(1000);


            result = accessStatisticsService.NewAccess("TEST", "2", true, ref resultMsg);
            Console.WriteLine("NewAccess!  Result = {0}, MEssage = {1}", result, resultMsg);


            Thread.Sleep(1000);

            result = accessStatisticsService.NewAccess("TEST", "2", true, ref resultMsg);
            Console.WriteLine("NewAccess!  Result = {0}, MEssage = {1}", result, resultMsg);


            Console.WriteLine("NewAccess Finish!");






            DefaultAccessStatisticsReportService accessStatisticsReportService = new DefaultAccessStatisticsReportService();

            var resultList1 = accessStatisticsReportService.GetAccessTypeSummary();
            foreach (var item in resultList1)
            {
                Console.WriteLine("AccessTypeSummary {0} : {1} = {2}", item.AccessTypeCode, item.AccessDate, item.AccessCount);
            }
            Console.WriteLine();


            var resultList2 = accessStatisticsReportService.GetAccessDetailSummary();
            foreach (var item in resultList2)
            {
                Console.WriteLine("AccessDetailSummary {0}, {1} : {2} = {3}", item.AccessTypeCode,  item.DetailCode, item.AccessDate, item.AccessCount);
            }
            Console.WriteLine();


            var resultList3 = accessStatisticsReportService.GetAccessDetailLog();
            foreach (var item in resultList3)
            {
                Console.WriteLine("AccessDetailLog {0}, {1} : {2}", item.AccessTypeCode, item.DetailCode, item.AccessTime);
            }
            Console.WriteLine();


            Console.ReadLine();
        }
    }
}
