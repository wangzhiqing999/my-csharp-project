using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

using MyWebApiClientBuilder.Model;
using MyWebApiClientBuilder.Util;
using MyWebApiClientBuilder.Template;

namespace MyWebApiClientBuilder
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 基础文档.
        /// </summary>
        private SwaggerDoc swaggerDoc;


        /// <summary>
        /// 初始化.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.txtSourcePath.Text = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }


        /// <summary>
        /// 选择代码路径.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            if(this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtSourcePath.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }



        /// <summary>
        /// 读取.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadDoc_Click(object sender, EventArgs e)
        {
            swaggerDoc = SwaggerDocReader.GetSwaggerDoc(this.txtSwaggerDocUrl.Text);


            btnCreateMyJavaScriptService.Enabled = true;
        }

        /// <summary>
        /// 生成 MyJavaScriptService
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateMyJavaScriptService_Click(object sender, EventArgs e)
        {
            // 代码目录.
            string sourcePath = this.txtSourcePath.Text;

            if (string.IsNullOrEmpty(sourcePath))
            {
                MessageBox.Show("未选择代码目录.");
                return;
            }
            if (!Directory.Exists(sourcePath))
            {
                MessageBox.Show("代码目录不存在.");
                return;
            }

            string resultFile = String.Format("{0}\\myJavaScriptService.js", sourcePath);

            MyJavaScriptService m = new MyJavaScriptService(this.swaggerDoc);
            string resultText = m.TransformText();
            File.WriteAllText(resultFile, resultText, Encoding.UTF8);
            MessageBox.Show("OK.");
        }
    }
}
