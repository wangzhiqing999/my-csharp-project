using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

using log4net;

using MyFinanceCalendar.Model;
using MyFinanceCalendar.Service;


namespace MyFinanceCalendar.ServiceImpl
{


    /// <summary>
    /// 从本地读取数据.
    /// </summary>
    public class LocalFinanceDataReader : IFinanceDataReader
    {

        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        private string mLocalPath = ".";

        /// <summary>
        /// 本地文件路径.
        /// </summary>
        public string LocalPath {
            set
            {
                mLocalPath = value;
            }
            get
            {
                return mLocalPath;
            }
        }



        private static LocalFinanceDataReader me = new LocalFinanceDataReader ();


        public static LocalFinanceDataReader GetInstance(string localPath) {
            me.LocalPath = localPath;
            return me;
        }




        public List<FinanceData> ReadFinanceDataInfo(DateTime myDate)
        {
            List<FinanceData> resultList = new List<FinanceData> ();

            string fileName = String.Format("{0}\\{1:yyyyMMdd}.xml", mLocalPath, myDate);

            if (!File.Exists(fileName))
            {
                // logger.WarnFormat("财经日历文件：{0} 不存在！", fileName);

                fileName = String.Format("{0}\\{1:yyyyMM}\\{2:yyyyMMdd}.xml", mLocalPath, myDate, myDate);

                if (!File.Exists(fileName))
                {
                    logger.WarnFormat("财经日历文件：{0} 不存在！", fileName);

                    // 文件不存在，返回空白列表.
                    return resultList;
                }
            }

            XmlSerializer xs = new XmlSerializer(typeof(List<FinanceData>));
            using (StreamReader sr = new StreamReader(fileName))
            {
                resultList = xs.Deserialize(sr) as List<FinanceData>;
                sr.Close();
            }


            return resultList;
        }
    }
}
