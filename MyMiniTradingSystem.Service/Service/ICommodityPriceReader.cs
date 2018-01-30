using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyMiniTradingSystem.Model;




namespace MyMiniTradingSystem.Service
{



    /// <summary>
    /// 行情数据读取服务.
    /// </summary>
    public interface ICommodityPriceReader
    {



        List<CommodityPrice> GetCommodityPriceList(string stockCode, DateTime startDate, DateTime finishDate);



    }
}
