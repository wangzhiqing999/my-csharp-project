using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MyFinanceCalendar.Model;
using MyFinanceCalendar.Service;


namespace MySubModule.Web.Controllers
{
    /// <summary>
    /// 财经日历
    /// </summary>
    public class FinanceCalendarController : ApiController
    {

        /// <summary>
        /// 财经日历读取.
        /// </summary>
        private IFinanceDataReader financeDataReader;

        /// <summary>
        /// 财经日历
        /// </summary>
        public FinanceCalendarController(IFinanceDataReader financeDataReader)
        {
            this.financeDataReader = financeDataReader;
        }



        /// <summary>
        /// 获取财经日历数据
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public IHttpActionResult GetFinancialCalendar(string date = null)
        {
            DateTime dt;
            if (!DateTime.TryParse(date, out dt))
            {
                dt = DateTime.Today;
            }
            List<FinanceData> dataList = this.financeDataReader.ReadFinanceDataInfo(dt);

            if (dataList == null)
            {
                return NotFound();
            }

            var query =
                from data in dataList
                select new
                {
                    // 时间.
                    Time = data.DisplayFinanceTime,

                    // 国家.
                    CountryName = data.CountryName,

                    // 指标名称
                    Content = data.Content,

                    // 重要性
                    Weightiness = data.Weightiness,

                    // 前值	
                    Previous = data.Previous,

                    // 预测值
                    Predict = data.Predict,


                    // 公布值
                    CurrentValue = data.CurrentValue,
                };

            var resultDataList = query.ToList();

            return Ok(resultDataList);
        }


    }

}
