using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyFinanceCalendar.Model;
using MyFinanceCalendar.DataAccess;


using MyFinanceCalendar.Service;


namespace MyFinanceCalendar.ServiceImpl
{

    public class FinanceDataService : IFinanceDataService
    {

        /// <summary>
        /// 插入或更新数据.
        /// </summary>
        /// <param name="dataList"></param>
        public void InsertOrUpdate(List<FinanceData> dataList)
        {
            using (MyFinanceCalendarContext context = new MyFinanceCalendarContext())
            {
                foreach (FinanceData data in dataList)
                {

                    DateTime minDate = new DateTime(data.FinanceDateTime.Year, data.FinanceDateTime.Month, data.FinanceDateTime.Day);
                    DateTime maxDate = minDate.AddDays(1);


                    var query =
                        from dbData in context.FinanceDatas
                        where
                            // 国家/地区.
                            dbData.CountryName == data.CountryName
                            // 指标名.
                            && dbData.Content == data.Content
                            // 时间.
                            && dbData.FinanceDateTime >= minDate
                            && dbData.FinanceDateTime < maxDate
                        select 
                            dbData;

                    FinanceData financeData = query.FirstOrDefault();

                    if (financeData == null)
                    {
                        // 数据库中没有，需要创建.
                        context.FinanceDatas.Add(data);
                    }
                    else
                    {
                        // 数据库中已存在，需要更新.

                        // 公布时间.
                        financeData.FinanceDateTime = data.FinanceDateTime;

                        // 公布值.
                        financeData.CurrentValue = data.CurrentValue;
                    }
                }

                // 物理保存.
                context.SaveChanges();
            }
        }




        /// <summary>
        /// 查询日期.
        /// </summary>
        /// <param name="queryDate"></param>
        /// <returns></returns>
        public List<FinanceData> GetFinanceData(DateTime queryDate)
        {
            DateTime minDate = new DateTime(queryDate.Year, queryDate.Month, queryDate.Day);
            DateTime maxDate = minDate.AddDays(1);

            using (MyFinanceCalendarContext context = new MyFinanceCalendarContext())
            {
                var query =
                    from data in context.FinanceDatas
                    where
                        data.FinanceDateTime >= minDate
                        && data.FinanceDateTime < maxDate
                    select data;

                return query.ToList();
            }
        }

    }

}
