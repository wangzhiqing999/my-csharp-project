using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MyWebCrawler.Service.Test.UI;


namespace MyWebCrawler.Service.Test
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void readHtmlTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormReadHtmlText();
            subForm.MdiParent = this;
            subForm.Show();
        }


        private void readOneDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormReadOneData();
            subForm.MdiParent = this;
            subForm.Show();
        }


        private void readMultiDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormReadMultiData();
            subForm.MdiParent = this;
            subForm.Show();
        }


        private void readHtmlImgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormReadImg();
            subForm.MdiParent = this;
            subForm.Show();
        }

        private void readHtmlKeywordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormReadKeyword ();
            subForm.MdiParent = this;
            subForm.Show();
        }


        private void readListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormReadPinganList();
            subForm.MdiParent = this;
            subForm.Show();
        }

        private void readDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormReadPinganDetail();
            subForm.MdiParent = this;
            subForm.Show();
        }





        #region 中国金额期货交易所交易公告


        private void readCffexListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormReadCffexList();
            subForm.MdiParent = this;
            subForm.Show();
        }


        private void readCffexDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormReadCffexDetail();
            subForm.MdiParent = this;
            subForm.Show();
        }


        #endregion



        #region 上海期货交易所公告.


        private void readShfeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormReadShfeList();
            subForm.MdiParent = this;
            subForm.Show();
        }

        private void readShfeDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormReadShfeDetail();
            subForm.MdiParent = this;
            subForm.Show();
        }

        #endregion




        #region 大连商品期货交易所 通知



        private void readDceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormReadDceList();
            subForm.MdiParent = this;
            subForm.Show();
        }



        private void readDceDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormReadDceDetail();
            subForm.MdiParent = this;
            subForm.Show();
        }


        #endregion




        #region 郑州商品期货交易所



        private void readCzceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormReadCzceList();
            subForm.MdiParent = this;
            subForm.Show();
        }



        private void readCzceDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormReadCzceDetail();
            subForm.MdiParent = this;
            subForm.Show();
        }


        #endregion




        #region 上海黄金交易所.




        private void readSgeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormReadSgeList();
            subForm.MdiParent = this;
            subForm.Show();
        }



        private void readSgeDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormReadSgeDetail();
            subForm.MdiParent = this;
            subForm.Show();
        }


        #endregion





        #region Fx678


        private void readFx678ListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormReadFx678List();
            subForm.MdiParent = this;
            subForm.Show();
        }

        private void readFx678DetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormReadFx678Detail();
            subForm.MdiParent = this;
            subForm.Show();
        }




        private void readFx678RLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormReadRl();
            subForm.MdiParent = this;
            subForm.Show();
        }



        #endregion Fx678


    }
}
