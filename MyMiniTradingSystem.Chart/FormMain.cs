using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyMiniTradingSystem.Chart
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }



        private void closeAndStopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDailySummaryCloseAndStop subForm = new FormDailySummaryCloseAndStop();
            subForm.MdiParent = this;
            subForm.Show();
        }



        private void valueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDailySummaryValue subForm = new FormDailySummaryValue();
            subForm.MdiParent = this;
            subForm.Show();
        }


    }
}
