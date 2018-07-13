using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MyWebCrawler.Service;
using MyWebCrawler.ServiceImpl;

namespace MyWebCrawler.Service.Test.UI
{
    public partial class FormReadHtmlText : Form
    {
        public FormReadHtmlText()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            IHtmlDataReader<Form> reader = new DefaultHtmlDataReader<Form>();
            this.txtResult.Text = reader.ReadHtmlText(this.txtUrl.Text);


            // 移除脚本.
            this.txtResult.Text = reader.RemoveScriptAndStyle(this.txtResult.Text);

            // 移除备注.
            this.txtResult.Text = reader.RemoveRemarkText(this.txtResult.Text);
        }


    }
}
