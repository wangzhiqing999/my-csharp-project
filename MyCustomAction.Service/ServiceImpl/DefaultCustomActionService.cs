using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;


using MyCustomAction.Model;
using MyCustomAction.DataAccess;
using MyCustomAction.Service;

namespace MyCustomAction.ServiceImpl
{

    /// <summary>
    /// 客户行为服务.
    /// </summary>
    public class DefaultCustomActionService : ICustomActionService
    {
        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public long NewAction(long customID, string moduleCode, string expData)
        {
            try
            {
                using (MyCustomActionContext context = new MyCustomActionContext())
                {

                    // 视需要，检查 模块代码是否存在.
                    // 不检查的话，则由数据库的外键约束进行拦截.

                    CustomAction data = new CustomAction()
                    {
                        // 客户ID.
                        CustomID = customID,

                        // 模块代码.
                        ModuleCode = moduleCode,

                        // 附加数据.
                        ExpData = expData,

                        // 首次访问.
                        EnterTime = DateTime.Now,
                        LastAccessTime = DateTime.Now,
                        AccessCount = 1                        
                    };

                    context.CustomActions.Add(data);

                    context.SaveChanges();

                    return data.ID;
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                return -1;
            }            
        }



        public bool ContinueAction(long actionID, long customID, string moduleCode)
        {
            try
            {
                using (MyCustomActionContext context = new MyCustomActionContext())
                {
                    CustomAction data = context.CustomActions.Find(actionID);
                    if (data == null)
                    {
                        // 数据不存在.
                        return false;
                    }
                    
                    // 数据检查.
                    if (data.CustomID != customID || data.ModuleCode != moduleCode)
                    {
                        // 数据不匹配.
                        return false;
                    }


                    // 数据更新.
                    data.LastAccessTime = DateTime.Now;
                    data.AccessCount = data.AccessCount + 1;

                    context.SaveChanges();

                    return true;
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                return false;
            }  
        }




        public List<CustomAction> QueryCustomAction(long? customID, DateTime? fromTime, DateTime? toTime)
        {
            using (MyCustomActionContext context = new MyCustomActionContext())
            {
                var query =
                    from data in context.CustomActions.Include("AccessServiceModule")
                    select data;


                if (customID != null)
                {
                    query = query.Where(p => p.CustomID == customID);
                }


                if (fromTime != null)
                {
                    query = query.Where(p => p.LastAccessTime >= fromTime);
                }
                if (toTime != null)
                {
                    query = query.Where(p => p.LastAccessTime <= toTime);
                }

                List<CustomAction> resultList = query.ToList();
                return resultList;
            }
        }



    }
}
