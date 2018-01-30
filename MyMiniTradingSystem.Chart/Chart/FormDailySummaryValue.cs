using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using MyMiniTradingSystem.Model;
using MyMiniTradingSystem.DataAccess;


namespace MyMiniTradingSystem.Chart
{
    public partial class FormDailySummaryValue : Form
    {

        private const string DefaultUserCode = "000000";


        public FormDailySummaryValue()
        {
            InitializeComponent();
        }

        private void FormDailySummaryValue_Load(object sender, EventArgs e)
        {
            using (MyMiniTradingSystemContext context = new MyMiniTradingSystemContext())
            {
                var groupQuery =
                    from data in context.DailySummarys
                    where data.UserCode == DefaultUserCode
                    group data by data.PositionCommodityCode;

                foreach (var group in groupQuery)
                {

                    // Create a data series
                    Series series1 = new Series()
                    {
                        // 名称.
                        Name = group.Key,

                        // 类型.
                        ChartType = SeriesChartType.StackedArea,

                        // 显示数值.
                        IsValueShownAsLabel = true,
                    };

                    // Add series to the chart
                    this.chart1.Series.Add(series1);
                }



                var dateQuery =
                    from data in context.DailySummarys
                    where
                        data.UserCode == DefaultUserCode
                    orderby
                        data.DailySummaryDate
                    select data;

                DailySummary firstData = dateQuery.FirstOrDefault();
                if (firstData != null)
                {
                    this.dtpStart.Value = firstData.DailySummaryDate;
                    this.dtpStart.MinDate = firstData.DailySummaryDate;
                }

                this.dtpFinish.Value = DateTime.Today;
                this.dtpFinish.MaxDate = DateTime.Today;


            }
        }



        /// <summary>
        /// 查询.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            DateTime startDt = this.dtpStart.Value;
            DateTime finishDt = this.dtpFinish.Value;

            using (MyMiniTradingSystemContext context = new MyMiniTradingSystemContext())
            {

                var query =
                    from data in context.DailySummarys
                    where
                        data.UserCode == DefaultUserCode
                        && data.DailySummaryDate >= startDt
                        && data.DailySummaryDate <= finishDt
                    orderby
                        data.DailySummaryDate
                    select data;


                foreach (var serie in chart1.Series)
                {
                    serie.Points.Clear();
                }


                foreach (var data in query)
                {
                    chart1.Series[data.PositionCommodityCode].Points.AddXY(data.DailySummaryDate.ToShortDateString(), data.PositionValue);
                }
            }
        }






    }
}
