using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace MyLoggerReader.Service
{

    /// <summary>
    /// 日志文件获取.
    /// </summary>
    class LoggerFileGetter
    {


        /// <summary>
        /// 获取指定目录下的日志文件.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<string> GetLoggerFileNames(string path)
        {
            List<string> resultList = new List<string>();

            string[] files = Directory.GetFiles(path, "Log_INFO_*.csv", SearchOption.AllDirectories);

            resultList.AddRange(files);

            return resultList;
        }



    }
}
