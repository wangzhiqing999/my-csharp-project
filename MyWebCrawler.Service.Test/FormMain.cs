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

        private void readMultiDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormReadMultiData();
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





    }
}
