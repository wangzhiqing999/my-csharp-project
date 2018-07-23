using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using log4net;

using MyFramework.ServiceModel;

using MyBuying.Service;
using MyBuying.ServiceImpl;
using MyBuying.ServiceModel;


namespace MyBuying.Util
{

    /// <summary>
    /// 购买者队列管理.
    /// </summary>
    public class BuyerQueueManager
    {

        #region 单例使用.

        private BuyerQueueManager()
        {
            // 消费线程.
            Thread reader = new Thread(DequeueService);
            reader.Start();
        }

        private static BuyerQueueManager _Me = new BuyerQueueManager();

        public static BuyerQueueManager GetInstance()
        {
            return _Me;
        }

        #endregion 单例使用.


        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);





        /// <summary>
        /// 用于 锁定 生产 / 消费 的数据队列 的对象.
        /// </summary>
        static object locker = new object();


        /// <summary>
        /// 用于 锁定 结果集合 的对象.
        /// </summary>
        static object resultLocker = new object();



        /// <summary>
        /// 用于快速判断。 用户是否已经在队列管理中的 Set. 
        /// 而不是通过 遍历 队列的方式， 来查询是否存在.
        /// </summary>
        private HashSet<string> userCodeSet = new HashSet<string>();


        /// <summary>
        /// 实际操作的队列.
        /// </summary>
        private Queue<BuyingData> userCodeQueue = new Queue<BuyingData>();


        /// <summary>
        /// 服务执行的结果.
        /// </summary>
        private Dictionary<string, CommonServiceResult<long>> serviceResult = new Dictionary<string, CommonServiceResult<long>>();



        /// <summary>
        /// 购买服务.
        /// </summary>
        private IBuyingService _BuyingService = new DefaultBuyingServiceImpl();




        /// <summary>
        /// 入队列.
        /// </summary>
        /// <param name="buyingData"></param>
        /// <returns></returns>
        public CommonServiceResult<int> Enqueue(BuyingData buyingData)
        {
            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("入队列: {0}", buyingData);
            }

            lock (locker)
            {
                if (this.userCodeSet.Contains(buyingData.BuyerCode))
                {
                    CommonServiceResult<int> errorResult = new CommonServiceResult<int>()
                    {
                        ResultCode = "BUYER_CODE_HAD_EXISTS",
                        ResultMessage = "用户代码已经存在于队列中",
                    };
                    return errorResult;
                }

                this.userCodeSet.Add(buyingData.BuyerCode);
                this.userCodeQueue.Enqueue(buyingData);

                var queueCount = this.userCodeQueue.Count();

                // 通知 其他等待的线程
                Monitor.Pulse(locker);

                return CommonServiceResult<int>.CreateDefaultSuccessResult(queueCount);
            }
        }




        private void DequeueService()
        {
            while (true)
            {
                BuyingData buyingData;
                lock (locker)
                {
                    if (this.userCodeSet.Count == 0)
                    {
                        // 队列中无数据.
                        // 等待通知.
                        if (logger.IsDebugEnabled)
                        {
                            logger.DebugFormat("队列中无数据，等待通知。");
                        }
                        Monitor.Wait(locker);
                    }



                    buyingData = this.userCodeQueue.Dequeue();
                    
                }
                
                
                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("出队列，数据处理：{0}", buyingData);
                }


                // 为了测试队列中等待的效果， 这里休眠5秒.
                Thread.Sleep(5000);

                CommonServiceResult<long> result = this._BuyingService.GetFirstBuyableCommodityDetail(buyingData.CommodityMasterCode, buyingData.Batch, buyingData.BuyerCode);

                lock (locker)
                {
                    this.userCodeSet.Remove(buyingData.BuyerCode);
                }
                lock (resultLocker)
                {
                    if(!this.serviceResult.ContainsKey(buyingData.BuyerCode)) {
                        this.serviceResult.Add(buyingData.BuyerCode, result);
                    }                    
                }
            }
        }


        /// <summary>
        /// 是否在队列中.
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public CommonServiceResult IsInQueue(string userCode)
        {
            lock (locker)
            {
                if (!this.userCodeSet.Contains(userCode))
                {
                    return CommonServiceResult.DataNotFoundResult;
                }

                return CommonServiceResult.DefaultSuccessResult;
            }
        }


        /// <summary>
        /// 获取服务结果.
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public CommonServiceResult<long> GetServiceResult(string userCode)
        {
            lock (resultLocker)
            {
                if (this.serviceResult.ContainsKey(userCode))
                {
                    CommonServiceResult<long> result = this.serviceResult[userCode];
                    this.serviceResult.Remove(userCode);
                    return result;
                }
                return CommonServiceResult<long>.DataNotFoundResult;
            }
        }



    }
}
