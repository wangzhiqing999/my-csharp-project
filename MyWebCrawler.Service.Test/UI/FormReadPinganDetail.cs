using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using MyWebCrawler.Model;
using MyWebCrawler.Service;
using MyWebCrawler.ServiceImpl;

using MyWebCrawler.Service.Test.Model;


namespace MyWebCrawler.Service.Test.UI
{
    public partial class FormReadPinganDetail : Form
    {
        public FormReadPinganDetail()
        {
            InitializeComponent();
        }


        private IHtmlDataReader<NewsData> reader = new DefaultHtmlDataReader<NewsData>();


        private void btnGo_Click(object sender, EventArgs e)
        {
            this.txtHtml.Text = reader.ReadHtmlText(this.txtUrl.Text);

            // 移除脚本.
            this.txtHtml.Text = reader.RemoveScriptAndStyle(this.txtHtml.Text);

            // 移除备注.
            this.txtHtml.Text = reader.RemoveRemarkText(this.txtHtml.Text);
        }



        private void btnProcess_Click(object sender, EventArgs e)
        {
            string[] propNames = this.txtPropertyName.Text.Split(',');

            HtmlReaderConfig config = new HtmlReaderConfig();
            config.RegexText = this.txtReg.Text;
            config.PropertyNameList = new List<string>(propNames);



            var result = reader.ReadSingleData(this.txtHtml.Text, config);

            string jsonString = JsonConvert.SerializeObject(result);
            this.txtResult.Text = jsonString;
        }






    }
}
