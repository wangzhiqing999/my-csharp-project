using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using MyMiniTradingSystem.Model;
using MyMiniTradingSystem.DataAccess;


namespace MyMiniTradingSystem.Chart
{
    public partial class FormDailySummaryCloseAndStop : Form
    {

        private const string DefaultUserCode = "000000";


        public FormDailySummaryCloseAndStop()
        {
            InitializeComponent();
        }




        private void FormDailySummary_Load(object sender, EventArgs e)
        {
            using (MyMiniTradingSystemContext context = new MyMiniTradingSystemContext())
            {
                var groupQuery =
                    from data in context.DailySummarys
                    where data.UserCode == DefaultUserCode
                    group data by data.PositionCommodityCode;

                foreach (var group in groupQuery)
                {
                    this.cboItem.Items.Add(group.Key);
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

            string code = this.cboItem.Text;
            DateTime startDt = this.dtpStart.Value;
            DateTime finishDt = this.dtpFinish.Value;

            using (MyMiniTradingSystemContext context = new MyMiniTradingSystemContext())
            {

                var query =
                    from data in context.DailySummarys
                    where
                        data.UserCode == DefaultUserCode
                        && data.PositionCommodityCode == code
                        && data.DailySummaryDate >= startDt
                        && data.DailySummaryDate <= finishDt
                    orderby
                        data.DailySummaryDate
                    select data;


                chart1.Series["ClosePrice"].Points.Clear();
                chart1.Series["StopLossPrice"].Points.Clear();



                foreach (var data in query)
                {
                    chart1.Series["ClosePrice"].Points.AddXY(data.DailySummaryDate.ToShortDateString(), data.ClosePrice);
                    chart1.Series["StopLossPrice"].Points.AddXY(data.DailySummaryDate.ToShortDateString(), data.StopLossPrice);
                }


            }




        }






    }
}
