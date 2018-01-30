using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using log4net;


using MyMiniTradingSystem.Model;
using MyMiniTradingSystem.DataAccess;
using MyMiniTradingSystem.Service;



namespace MyMiniTradingSystem.ServiceImpl
{


    public class TradableCommodityService
    {
        /// <summary>
        /// 日志处理类.
        /// </summary>
        protected static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        /// <summary>
        /// 结果消息.
        /// </summary>
        public string ResultMessage { set; get; }






        /// <summary>
        /// 插入商品信息.
        /// </summary>
        /// <param name="newData"></param>
        /// <returns></returns>
        public bool CreateTradableCommodity(TradableCommodity newData)
        {
            bool result = false;


            try
            {

                using (MyMiniTradingSystemContext context = new MyMiniTradingSystemContext())
                {
                    // 查询数据是否已存在.
                    var query =
                        from data in context.TradableCommoditys
                        where data.CommodityCode == newData.CommodityCode
                        select data;

                    if (query.Count() > 0)
                    {
                        ResultMessage = String.Format("代码为{0}的商品已存在！", newData.CommodityCode);
                        return result;
                    }



                    newData.BeforeInsertOperation();
                    context.TradableCommoditys.Add(newData);
                    context.SaveChanges();

                    result = true;
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                
                result = false;
                ResultMessage = ex.Message;
            }

            return result;
        }



    }


}
