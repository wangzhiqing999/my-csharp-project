using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using MyJob.Service.Test.UI;


namespace MyJob.Service.Test
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }



        private void windowsCmdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormWindowsCmd();
            subForm.MdiParent = this;
            subForm.Show();
        }

        private void sqlQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormSqlQuery();
            subForm.MdiParent = this;
            subForm.Show();
        }

        private void sqlUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormSqlUpdate();
            subForm.MdiParent = this;
            subForm.Show();
        }
    }
}
