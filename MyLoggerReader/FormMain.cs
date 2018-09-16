using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using MyLoggerReader.Service;


namespace MyLoggerReader
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 文件名列表.
        /// </summary>
        private List<string> fileNameList;






        /// <summary>
        /// 选择 日志的目录.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtLoggerPath.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }


        /// <summary>
        /// 选择存储的结果文件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowseResultFile_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtResultFile.Text = this.saveFileDialog1.FileName;
            }
        }


        /// <summary>
        /// 文件数获取.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetFileCount_Click(object sender, EventArgs e)
        {
            this.fileNameList = LoggerFileGetter.GetLoggerFileNames(this.txtLoggerPath.Text);

            this.lblFileCount.Text = this.fileNameList.Count.ToString();
        }


        /// <summary>
        /// 文件分析处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadFile_Click(object sender, EventArgs e)
        {
            this.toolStripProgressBar1.Minimum = 0;
            this.toolStripProgressBar1.Value = 0;
            this.toolStripProgressBar1.Maximum = this.fileNameList.Count;


            List<string> resultList = new List<string>();

            foreach (var filename in this.fileNameList)
            {
                List<string> oneFileList = FileReader.SearchFile(filename);

                foreach (var oneLine in oneFileList)
                {
                    if (!resultList.Contains(oneLine))
                    {
                        resultList.Add(oneLine);
                    }
                }

                this.toolStripProgressBar1.Value++;
            }

            File.AppendAllLines(this.txtResultFile.Text, resultList);

        }



    }
}
