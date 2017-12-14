using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using log4net;

using MyFx678Kx.Model;
using MyFx678Kx.DataAccess;
using MyFx678Kx.Service;



namespace MyFx678Kx.ServiceImpl
{


    public class DefaultFx678KxUpdateService : IFx678KxUpdateService
    {

        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);




        public string ResultMessage
        {
            get;
            set;
        }


        /// <summary>
        /// 新闻读取.
        /// </summary>
        private IFx678KxReader fx678KxReader;



        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="fx678KxReader"></param>
        public DefaultFx678KxUpdateService(IFx678KxReader fx678KxReader)
        {
            this.fx678KxReader = fx678KxReader;
        }




        /// <summary>
        /// 更新快讯.
        /// </summary>
        /// <returns></returns>
        public bool UpdateFx678Kx()
        {
            if (logger.IsInfoEnabled)
            {
                logger.Info("开始更新快讯信息！");
            }


            // 插入的行数.
            int insertCount = 0;

            // 忽略的行数.
            int passCount = 0;


            try
            {

                // 读取快讯列表.
                List<Fx678Kx> kxList = this.fx678KxReader.ReadFx678KxList();


                if (kxList == null || kxList.Count == 0)
                {
                    ResultMessage = "快讯读取，可能发生了问题， 读取到的行数为零！！！";
                    logger.Warn(ResultMessage);
                    return false;
                }

                using (MyFx678KxContext context = new MyFx678KxContext())
                {

                    Random randomer = new Random();


                    foreach (var kxData in kxList)
                    {

                        // 判断是否已存在.
                        Fx678Kx dbData = context.Fx678Kxs.Find(kxData.NewsId);


                        if (dbData != null)
                        {
                            // 已存在的，不做任何处理.
                            passCount++;
                            continue;
                        }


                        if (kxData.HasMore && !String.IsNullOrEmpty(kxData.MoreUrl))
                        {
                            // 额外读取明细数据.
                            kxData.Content = this.fx678KxReader.ReadMore(kxData.MoreUrl);

                            // 为了避免太频繁访问目标网站.
                            // 随机休眠指定秒数后，再进行处理。
                            Thread.Sleep(randomer.Next(5000));
                        }



                        // 数据有效.
                        kxData.IsActive = true;
                        // 插入前处理.
                        kxData.BeforeInsertOperation();

                        // 逻辑插入.
                        context.Fx678Kxs.Add(kxData);

                      
                        insertCount++;


                        if (logger.IsDebugEnabled)
                        {
                            logger.DebugFormat("kxData: {0}", kxData);
                        }


                        // 物理保存.
                        context.SaveChanges();
                    }

                    
                }





                return true;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbErr)
            {
                foreach (var errItem in dbErr.EntityValidationErrors)
                {
                    foreach (var err in errItem.ValidationErrors)
                    {
                        logger.InfoFormat("{0} : {1}", err.PropertyName, err.ErrorMessage);
                    }
                }

                logger.Error(dbErr.Message, dbErr);

                ResultMessage = dbErr.Message;

                return false;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);

                ResultMessage = ex.Message;

                return false;
            }
            finally
            {
                if (logger.IsInfoEnabled)
                {
                    logger.InfoFormat("更新快讯信息完毕！  新插入行数：{0},  已存在的数据行数：{1} ", insertCount, passCount);
                }
            }


        }


    }

}
