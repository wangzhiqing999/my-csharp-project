using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using MyUserMonitor.Model;

using MyUserMonitor.Service;


namespace MyUserMonitor.ServiceImpl
{

    public class CsvFileUserAccessInfoWriter : IUserAccessInfoWriter
    {


        private string csvFileName = @"c:\test.csv";

        public string CsvFileName
        {
            set
            {
                this.csvFileName = value;
            }
            get
            {
                return this.csvFileName;
            }
        }



        private string GetCsvOneLine(UserAccessInfo data)
        {
            string result = String.Format("{0},{1},{2:yyyy-MM-dd HH:mm:ss},{3:yyyy-MM-dd HH:mm:ss},{4}", data.GroupCode, data.UserName, data.EnterTime, data.LastAccessTime, data.AccessCount);
            return result;
        }




        public void SaveUserAccessInfo(UserAccessInfo data)
        {
            string line = GetCsvOneLine(data) + "/r/n";
            File.AppendAllText(csvFileName, line, Encoding.UTF8);
        }


        public void SaveUserAccessInfoList(List<UserAccessInfo> dataList)
        {
            List<string> lineList = new List<string>();
            foreach (var data in dataList)
            {
                lineList.Add(GetCsvOneLine(data));
            }

            File.AppendAllLines(csvFileName, lineList, Encoding.UTF8);
        }
    }
}
