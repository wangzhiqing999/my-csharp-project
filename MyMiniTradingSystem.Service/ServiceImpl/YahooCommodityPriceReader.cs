using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using System.IO;
using System.Net;

using MyMiniTradingSystem.Model;
using MyMiniTradingSystem.Service;




namespace MyMiniTradingSystem.ServiceImpl
{

    /// <summary>
    /// 雅虎数据读取服务.
    /// </summary>
    public class YahooCommodityPriceReader : ICommodityPriceReader
    {



        /// <summary>
        /// 
        /// http://ichart.yahoo.com/table.csv?s=string&a=int&b=int&c=int&d=int&e=int&f=int&g=d&ignore=.csv
        /// s — 股票名称 
        /// a — 起始时间，月 
        /// b — 起始时间，日 
        /// c — 起始时间，年 
        /// d — 结束时间，月 
        /// e — 结束时间，日 
        /// f — 结束时间，年 
        /// g — 时间周期。
        /// 
        /// Ø  参数g的取值范围：d->‘日’(day), w->‘周’(week)，m->‘月’(mouth)，v->‘dividends only’ 
        /// Ø  月份是从0开始的，如9月数据，则写为08。
        /// 
        /// 示例 
        /// 
        /// 查询浦发银行2010.09.25 – 2010.10.8之间日线数据
        /// 
        /// http://ichart.yahoo.com/table.csv?s=600000.SS&a=08&b=25&c=2010&d=09&e=8&f=2010&g=d
        /// </summary>
        /// <returns></returns>
        private string FormatUrl(string stockCode, DateTime startDate, DateTime finishDate)
        {
            string url = String.Format("http://ichart.yahoo.com/table.csv?s={0}&a={1}&b={2}&c={3}&d={4}&e={5}&f={6}&g=d&ignore=.csv",
                stockCode,
                startDate.Month - 1,
                startDate.Day,
                startDate.Year,
                finishDate.Month - 1,
                finishDate.Day,
                finishDate.Year);

            return url;
        }




        /// <summary>
        /// 读取一行数据.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private CommodityPrice GetOneCommodityPriceDay(string line)
        {


            // 数据格式：
            // Date,Open,High,Low,Close,Volume,Adj Close
            // 2010-10-08,13.08996,13.46995,12.86,13.35997,129016300,8.60814

            string[] itemArray = line.Split(',');

            CommodityPrice result = new CommodityPrice()
            {
                // 日期.
                TradingStartDate = Convert.ToDateTime(itemArray[0]),
                TradingFinishDate = Convert.ToDateTime(itemArray[0]),
                // 开.
                OpenPrice = Convert.ToDecimal(itemArray[1]),
                // 高.
                HighestPrice = Convert.ToDecimal(itemArray[2]),
                // 低.
                LowestPrice = Convert.ToDecimal(itemArray[3]),
                // 平.
                ClosePrice = Convert.ToDecimal(itemArray[4]),
                // 成交.
                Volume = Convert.ToInt64(itemArray[5])
            };

            return result;
        }





        public List<CommodityPrice> GetCommodityPriceList(string stockCode, DateTime startDate, DateTime finishDate)
        {
            List<CommodityPrice> resultList = new List<CommodityPrice>();

            string url = FormatUrl(stockCode, startDate, finishDate);



            try
            {
                //访问该链接
                WebRequest request = WebRequest.Create(url);
                //获得返回值
                WebResponse response = request.GetResponse();
                // 从 Internet 资源返回数据流。
                Stream s = response.GetResponseStream();

                using (StreamReader sr = new StreamReader(s, Encoding.UTF8))
                {
                    int lineIndex = 0;
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lineIndex++;

                        if (lineIndex == 1)
                        {
                            // 第一行是标题行， 忽略.
                            continue;
                        }

                        if (String.IsNullOrWhiteSpace(line))
                        {
                            // 只有空白， 结束.
                            break;
                        }


                        // 读取一行.
                        CommodityPrice oneResult = GetOneCommodityPriceDay(line);

                        // 加入列表.
                        resultList.Add(oneResult);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw ex;
            }

            return resultList;
        }
    }
}
