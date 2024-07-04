using System;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyImageReplace
{
    public partial class FormMain : Form
    {

        /// <summary>
        /// 旧文件大小.
        /// </summary>
        private long oldFileSize = 0;

        /// <summary>
        /// 旧文件MD5.
        /// </summary>
        private string oldFileMD5 = "";



        public FormMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 设置路径.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetPath_Click(object sender, EventArgs e)
        {
            if(this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtImagePath.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnSelectOld_Click(object sender, EventArgs e)
        {
            if(this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtOldFileName.Text = this.openFileDialog1.FileName;
            }
        }

        private void btnSelectNew_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtNewFileName.Text = this.openFileDialog1.FileName;
            }
        }




        /// <summary>
        /// 预处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(this.txtImagePath.Text))
            {
                MessageBox.Show("图片路径不存在！");
                return;
            }
            if (!File.Exists(this.txtOldFileName.Text))
            {
                MessageBox.Show("旧图片不存在！");
                return;
            }

            // 获取旧文件大小.
            FileInfo oldFileInfo = new FileInfo(this.txtOldFileName.Text);
            oldFileSize = oldFileInfo.Length;
            oldFileMD5 = GetMD5(this.txtOldFileName.Text);

            this.txtResult.AppendText($"旧文件大小：{oldFileSize}\r\n");
            this.txtResult.AppendText($"旧文件MD5：{oldFileMD5}\r\n");

            // 旧文件的扩展名.
            string oldExt = Path.GetExtension(this.txtOldFileName.Text);


            // 开始遍历图片目录.
            foreach (var file in Directory.GetFiles(this.txtImagePath.Text, $"*{oldExt}", SearchOption.AllDirectories))
            {
                try
                {
                    // 获取指定文件大小.
                    FileInfo myFileInfo = new FileInfo(file);
                    long myFileSize = myFileInfo.Length;

                    if (myFileSize == oldFileSize)
                    {
                        // 当前文件大小，与旧文件大小相同.
                        // 尝试计算当前文件MD5.
                        string myFileMD5 = GetMD5(file);

                        if (myFileMD5 == oldFileMD5)
                        {
                            // 当前文件MD5，与旧文件MD5相同.
                            // 输出文件名.
                            this.txtResult.AppendText($"需要替换的文件：{file}\r\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.txtResult.AppendText($"文件：{file}\r\n");
                    this.txtResult.AppendText($"错误信息：{ex.Message}\r\n");
                }
            }
        }



        /// <summary>
        /// 开始处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartReplace_Click(object sender, EventArgs e)
        {
            if(!Directory.Exists(this.txtImagePath.Text))
            {
                MessageBox.Show("图片路径不存在！");
                return;
            }
            if(!File.Exists(this.txtOldFileName.Text))
            {
                MessageBox.Show("旧图片不存在！");
                return;
            }
            if (!File.Exists(this.txtNewFileName.Text))
            {
                MessageBox.Show("新图片不存在！");
                return;
            }

            if (this.txtOldFileName.Text == this.txtNewFileName.Text)
            {
                MessageBox.Show("旧图片和新图片不能相同！");
                return;
            }


            // 获取旧文件大小.
            FileInfo oldFileInfo = new FileInfo(this.txtOldFileName.Text);
            oldFileSize = oldFileInfo.Length;
            oldFileMD5 = GetMD5(this.txtOldFileName.Text);

            this.txtResult.Text = "";

            this.txtResult.AppendText($"旧文件大小：{oldFileSize}\r\n");
            this.txtResult.AppendText($"旧文件MD5：{oldFileMD5}\r\n");

            // 旧文件的扩展名.
            string oldExt = Path.GetExtension(this.txtOldFileName.Text);


            // 开始遍历图片目录.
            foreach (var file in Directory.GetFiles(this.txtImagePath.Text, $"*{oldExt}", SearchOption.AllDirectories))
            {
                try
                {
                    // 获取指定文件大小.
                    FileInfo myFileInfo = new FileInfo(file);
                    long myFileSize = myFileInfo.Length;

                    if(myFileSize == oldFileSize)
                    {
                        // 当前文件大小，与旧文件大小相同.
                        // 尝试计算当前文件MD5.
                        string myFileMD5 = GetMD5(file);

                        if(myFileMD5 == oldFileMD5)
                        {
                            // 当前文件MD5，与旧文件MD5相同.
                            // 尝试做文件替换的操作.
                            this.txtResult.AppendText($"替换文件：{file}\r\n");
                            File.Copy(this.txtNewFileName.Text, file, true);
                        }
                    }                    
                } 
                catch (Exception ex)
                {
                    this.txtResult.AppendText($"文件：{file}\r\n");
                    this.txtResult.AppendText($"错误信息：{ex.Message}\r\n");
                }
            }
        }




        /// <summary>
        /// 获取文件 MD5.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string GetMD5(string fileName)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(fileName))
                {
                    byte[] hash = md5.ComputeHash(stream);
                    string md5Hash = BitConverter.ToString(hash).Replace("-", "").ToLower();
                    return md5Hash;
                }
            }
        }


    }
}
