using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using System.IO;
using System.Diagnostics;



namespace MyDocument.Util
{
    public class Pdf2SwfConverter
    {


        private string pdf2SwfExePath = @"D:\SWFTools\pdf2swf.exe";

        public string Pdf2SwfExePath
        {
            set
            {
                pdf2SwfExePath = value;
            }
            get
            {
                return pdf2SwfExePath;
            }
        }



        /// <summary>
        /// Pdf 转换为 Swf.
        /// </summary>
        /// <param name="pdfFile"></param>
        /// <param name="swfFile"></param>
        public bool Pdf2Swf(string pdfFile, string swfFile)
        {
            Process process = new Process();

            // pdf2swf.exe 的目录.
            process.StartInfo.FileName = pdf2SwfExePath;

            // 命令行参数.
			// 有些pdf中的图形转换效果不好，会产生过多shape，这种情况下可以使用 -s poly2bitmap 的参数，将图形转成点阵。生成的swf尺寸少了。
			// 加 “-T 9” 参数，设置输出版本为flash9，解决PDF文件只有一页，生成的swf不能播放的问题。
            process.StartInfo.Arguments = String.Format(@" {0} {1}   -s poly2bitmap -T 9", pdfFile, swfFile);


            try
            {
                // 运行.
                process.Start();

                process.WaitForExit();
            }
            catch
            {
                return false;
                throw;
            }
            finally
            {
                process.Close();
            }
            return File.Exists(swfFile);
        }
        



    }
}
