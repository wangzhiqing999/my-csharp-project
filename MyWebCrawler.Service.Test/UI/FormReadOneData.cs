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
    public partial class FormReadOneData : Form
    {
        public FormReadOneData()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {

            IHtmlDataReader<ItemPriceData> reader = new DefaultHtmlDataReader<ItemPriceData>();


            string[] propNames = this.txtPropertyName.Text.Split(',');

            HtmlReaderConfig config = new HtmlReaderConfig();
            config.RegexText = this.txtReg.Text;
            config.PropertyNameList = new List<string>(propNames);



            var result = reader.ReadSingleData(this.txtSource.Text, config);

            string jsonString = JsonConvert.SerializeObject(result);
            this.txtResult.Text = jsonString;
        }
    }
}
