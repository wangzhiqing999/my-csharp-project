using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyLoggerReader.Service
{

    /// <summary>
    /// 文字匹配.
    /// </summary>
    class FileReader
    {

        // 初始化 正则表达式  忽略大小写
        private static Regex reg1 = new Regex("操作 = ([\u4E00-\u9FFF]+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);

        private static Regex reg2 = new Regex("工号 = ([0-9Xx]+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);

        private static Regex reg3 = new Regex("流水号 = ([0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);


        public static List<string> SearchFile(string fileName)
        {

            try
            {

                List<string> resultList = new List<string>();

                using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
                {
                    // 用于暂存 文本文件数据的 行.
                    String line = null;

                    do
                    {
                        // 一次读取一行数据.
                        line = sr.ReadLine();


                        if (line != null)
                        {
                            // 正则匹配.

                            // 指定的输入字符串中搜索 Regex 构造函数中指定的正则表达式的第一个匹配项。
                            Match m1 = reg1.Match(line);
                            Match m2 = reg2.Match(line);
                            Match m3 = reg3.Match(line);

                            if (m1.Success && m2.Success && m3.Success)
                            {
                                string name = m1.Groups[1].Value;
                                string id = m2.Groups[1].Value;
                                string phone = m3.Groups[1].Value;

                                string regText = String.Format("{0}, {1}, {2}", name, id, phone);


                                // 避免重复.
                                if (!resultList.Contains(regText))
                                {
                                    resultList.Add(regText);
                                }
                            }
                        }

                    } while (line != null);
                }

                return resultList;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }

        }

    }
}
