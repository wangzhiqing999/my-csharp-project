using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Security.Cryptography;


namespace MyChatRoom.Util
{
    class SHA512Process
    {

        private static UnicodeEncoding byteConverter = new UnicodeEncoding();


        private static SHA512 shaM = new SHA512Managed();



        /// <summary>
        /// 获取 SHA512 字符串信息.
        /// </summary>
        /// <param name="source"></param>
        public static string GetSHA512String(string source)
        {

            // 源字符串转换为 byte数组.
            byte[] dataToEncrypt = byteConverter.GetBytes(source);

            // SHA512 处理.
            byte[] sha512Result = shaM.ComputeHash(dataToEncrypt);

            // 结果格式化为 十六进制的字符串格式.
            StringBuilder buff = new StringBuilder();

            for (int i = 0; i < sha512Result.Length; i++)
            {
                buff.AppendFormat("{0:X2}", sha512Result[i]);
            }

            return buff.ToString();
        }


    }
}
