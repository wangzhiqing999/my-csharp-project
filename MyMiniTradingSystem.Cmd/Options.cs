using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using CommandLine;
using CommandLine.Text;

using log4net;

using MyMiniTradingSystem.Model;
using MyMiniTradingSystem.Service;
using MyMiniTradingSystem.ServiceImpl;



namespace MyMiniTradingSystem.Cmd
{

    /// <summary>
    /// 通用参数.
    /// </summary>
    abstract class CommonSubOptions
    {
        /// <summary>
        /// 股票代码.
        /// </summary>
        [Option('c', "code", HelpText = "股票代码", Required = true)]
        public string Code { set; get; }


        /// <summary>
        /// 日志处理类.
        /// </summary>
        protected static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        /// <summary>
        /// 业务处理.
        /// </summary>
        public abstract void DoProcess();
    }



    /// <summary>
    /// 新增命令.
    /// 
    /// 例如：
    /// create -c 510300 -n 300ETF
    /// </summary>
    class CreateSubOption : CommonSubOptions
    {

        /// <summary>
        /// 股票名称.
        /// </summary>
        [Option('n', "name", HelpText = "股票名称", Required = true)]
        public string Name { set; get; }


        /// <summary>
        /// 业务处理.
        /// </summary>
        public override void DoProcess()
        {

            TradableCommodityService service = new TradableCommodityService();


            TradableCommodity newData = new TradableCommodity()
            {
                // 代码.
                CommodityCode = this.Code,

                // 名称.
                CommodityName = this.Name,

                // 1手 = 100股.
                NumOfOneHand = 100,

                // 保证金 100% == 无杠杆.
                DepositRatio = 100,

                // 有效.
                IsActive = true,
            };


            bool result = service.CreateTradableCommodity(newData);


            if (result)
            {
                logger.Info("Success!");
            }
            else
            {
                logger.Info("Fail!");
                logger.Info(service.ResultMessage);
            }
        }


    }


    /// <summary>
    /// 导入命令.
    /// 
    /// 例如：
    /// import -c 600642  -d 2015-04-22  -o 9.45 -e 10.16 -h 10.16 -l 9.35 -v 2270000
    /// </summary>
    class ImportSubOption : CommonSubOptions
    {

        /// <summary>
        /// 交易日期.
        /// </summary>
        [Option('d', "date", HelpText = "交易日期.", Required = true)]
        public DateTime Date { set; get; }


        /// <summary>
        /// 开盘价
        /// </summary>
        [Option('o', "open", HelpText = "开盘价.", Required = true)]
        public decimal OpenPrice { set; get; }

        /// <summary>
        /// 收盘价
        /// </summary>
        [Option('e', "close", HelpText = "收盘价.", Required = true)]
        public decimal ClosePrice { set; get; }


        /// <summary>
        /// 最高价
        /// </summary>
        [Option('h', "highest", HelpText = "最高价.", Required = true)]
        public decimal HighestPrice { set; get; }

        /// <summary>
        /// 最低价
        /// </summary>
        [Option('l', "lowest", HelpText = "最低价.", Required = true)]
        public decimal LowestPrice { set; get; }


        /// <summary>
        /// 成交量
        /// </summary>
        [Option('v', "Volume", HelpText = "成交量.", Required = true)]
        public long Volume { set; get; }



        public override void DoProcess()
        {
            CommodityPriceService service = new CommodityPriceService();

            CommodityPrice newData = new CommodityPrice()
            {
                // 代码.
                CommodityCode = this.Code,

                // 日期.
                TradingStartDate = this.Date,
                TradingFinishDate = this.Date,

                // 开.
                OpenPrice = this.OpenPrice,
                // 收.
                ClosePrice = this.ClosePrice,

                // 高.
                HighestPrice = this.HighestPrice,
                // 地.
                LowestPrice = this.LowestPrice,

                // 量.
                Volume = this.Volume,

                // 有效.
                IsActive = true,
            };

            bool result = service.InsertOrUpdateCommodityPrice(newData);


            if (result)
            {
                logger.Info("Success!");
            }
            else
            {
                logger.Info("Fail!");
                logger.Info(service.ResultMessage);
            }
        }
    }



    /// <summary>
    /// 从雅虎网站导入命令.
    /// 
    /// 例如：
    /// yahooimport -c 600642.SS -s 2015-04-01 -f 2015-04-23
    /// </summary>
    class YahooImportSubOption : CommonSubOptions
    {

        /// <summary>
        /// 开始交易日期.
        /// </summary>
        [Option('s', "start", HelpText = "开始交易日期.", Required = true)]
        public DateTime DateStart { set; get; }

        /// <summary>
        /// 结束交易日期.
        /// </summary>
        [Option('f', "finish", HelpText = "结束日期.", Required = true)]
        public DateTime DateFinish { set; get; }



        public override void DoProcess()
        {
            YahooCommodityPriceReader reader = new YahooCommodityPriceReader();

            List<CommodityPrice> dataList = reader.GetCommodityPriceList(this.Code, this.DateStart, this.DateFinish);


            CommodityPriceService service = new CommodityPriceService();


            foreach (CommodityPrice newData in dataList.OrderBy(p=>p.TradingStartDate))
            {
                // 代码
                newData.CommodityCode = this.Code.Substring(0, 6);
                // 有效.
                newData.IsActive = true;

                

                // 插入或更新.
                bool result = service.InsertOrUpdateCommodityPrice(newData);


                if (result)
                {
                    logger.Info("Success!");
                }
                else
                {
                    logger.Info("Fail!");
                    logger.Info(service.ResultMessage);
                }
            }


            Console.WriteLine("Done!");
        }
    }



    /// <summary>
    /// 从新浪网站导入命令.
    /// 
    /// 例如：
    /// sinaimport -c sh600642
    /// </summary>
    class SinaImportSubOption : CommonSubOptions
    {

        public override void DoProcess()
        {
            SinaCommodityPriceReader reader = new SinaCommodityPriceReader();

            List<CommodityPrice> dataList = reader.GetCommodityPriceList(this.Code, DateTime.Today, DateTime.Today);

            


            CommodityPrice newData = dataList[0];

            // 代码
            newData.CommodityCode = this.Code.Substring(2);
            // 有效.
            newData.IsActive = true;


            CommodityPriceService service = new CommodityPriceService();

            // 插入或更新.
            bool result = service.InsertOrUpdateCommodityPrice(newData);


            if (result)
            {
                logger.Info("Success!");
            }
            else
            {
                logger.Info("Fail!");
                logger.Info(service.ResultMessage);
            }
        }
    }



    /// <summary>
    /// 开仓命令.
    /// 
    /// 例如：
    /// open -c 600642 -u 000000 -q 1000
    /// </summary>
    class OpenPositionSubOption : CommonSubOptions
    {
     
        /// <summary>
        /// 帐户代码
        /// </summary>
        [Option('u', "usercode", HelpText = "帐户代码.", Required = true)]
        public string UserCode { set; get; }


        /// <summary>
        /// 数量
        /// </summary>
        [Option('q', "quantity", HelpText = "数量.", Required = true)]
        public int Quantity { set; get; }



        public override void DoProcess()
        {
            PositionService service = new PositionService();

            Position newData = new Position()
            {
                // 代码.
                CommodityCode = this.Code,

                // 用户.
                UserCode = this.UserCode,

                // 数量.
                Quantity = this.Quantity ,

                // 做多.
                IsLong = true,                

                // 有效.
                IsActive = true,
            };


            bool result = service.OpenPosition(newData);

            if (result)
            {
                logger.Info("Success!");
            }
            else
            {
                logger.Info("Fail!");
                logger.Info(service.ResultMessage);
            }

        }
    }



    /// <summary>
    /// 平仓命令.
    /// 
    /// 例如：
    /// close -c 600642 -u 000000 -q 1000
    /// </summary>
    class ClosePositionSubOption : CommonSubOptions
    {

        /// <summary>
        /// 帐户代码
        /// </summary>
        [Option('u', "usercode", HelpText = "帐户代码.", Required = true)]
        public string UserCode { set; get; }


        /// <summary>
        /// 数量
        /// </summary>
        [Option('q', "quantity", HelpText = "数量.", Required = true)]
        public int Quantity { set; get; }



        public override void DoProcess()
        {
            PositionService service = new PositionService();

            Position newData = new Position()
            {
                // 代码.
                CommodityCode = this.Code,

                // 用户.
                UserCode = this.UserCode,

                // 数量.
                Quantity = this.Quantity,

                // 做多.
                IsLong = true,

                // 有效.
                IsActive = true,
            };


            bool result = service.ClosePosition(newData);

            if (result)
            {
                logger.Info("Success!");
            }
            else
            {
                logger.Info("Fail!");
                logger.Info(service.ResultMessage);
            }

        }
    }







    /// <summary>
    /// 统计命令.
    /// 
    /// 例如：
    /// summary -u 000000 -d 2015-04-22
    /// </summary>
    class DailySummarySubOption : CommonSubOptions
    {

        /// <summary>
        /// 帐户代码
        /// </summary>
        [Option('u', "usercode", HelpText = "帐户代码.", Required = true)]
        public string UserCode { set; get; }


        /// <summary>
        /// 交易日期.
        /// </summary>
        [Option('d', "date", HelpText = "交易日期.", Required = true)]
        public DateTime Date { set; get; }



        public override void DoProcess()
        {
            DailySummaryService service = new DailySummaryService();
           
            bool result = service.BuildOneUserDailySummary(this.UserCode, this.Date);

            if (result)
            {
                logger.Info("Success!");
            }
            else
            {
                logger.Info("Fail!");
                logger.Info(service.ResultMessage);
            }

        }
    }









    /// <summary>
    /// 基本命令行选项.
    /// </summary>
    class Options
    {

        /// <summary>
        /// 新增命令
        /// </summary>
        [VerbOption("create", HelpText = "创建股票基础数据")]
        public CreateSubOption CreateVerb { get; set; }
        

        /// <summary>
        /// 数据导入命令
        /// </summary>
        [VerbOption("import", HelpText = "导入每日行情数据")]
        public ImportSubOption ImportVerb { get; set; }



        /// <summary>
        /// 数据导入命令
        /// </summary>
        [VerbOption("yahooimport", HelpText = "从雅虎网站导入每日行情数据")]
        public YahooImportSubOption YahooImportVerb { get; set; }
        

        /// <summary>
        /// 数据导入命令
        /// </summary>
        [VerbOption("sinaimport", HelpText = "从新浪网站导入每日行情数据")]
        public SinaImportSubOption SinaImportVerb { get; set; }




        /// <summary>
        /// 开仓命令
        /// </summary>
        [VerbOption("open", HelpText = "开仓")]
        public OpenPositionSubOption OpenVerb { get; set; }


        /// <summary>
        /// 平仓命令
        /// </summary>
        [VerbOption("close", HelpText = "平仓")]
        public ClosePositionSubOption CloseVerb { get; set; }




        /// <summary>
        /// 统计命令
        /// </summary>
        [VerbOption("summary", HelpText = "统计")]
        public DailySummarySubOption SummaryVerb { get; set; }

        


        [HelpVerbOption]
        public string GetUsage(string verb)
        {
            return HelpText.AutoBuild(this, verb);
        }
    }


}
