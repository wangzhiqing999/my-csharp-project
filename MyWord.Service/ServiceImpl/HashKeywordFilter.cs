using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MyWord.Service;


namespace MyWord.ServiceImpl
{

    /// <summary>
    /// 关键字筛选.
    /// </summary>
    public class HashKeywordFilter : IKeywordsFilter
    {

        /// <summary>
        /// 关键字最大长度
        /// </summary>
        private int m_maxLen;

        /// <summary>
        /// 关键字 HashSet
        /// </summary>
        private HashSet<string> m_keys = new HashSet<string>();


        /// <summary>
        /// 添加关键词.
        /// </summary>
        /// <param name="word"></param>
        public void AddKeyword(string word)
        {
            if ((!string.IsNullOrEmpty(word)) && m_keys.Add(word) && word.Length > m_maxLen)
            {
                m_maxLen = word.Length;
            }
        }


        /// <summary>
        /// 目标文本中，是否包含关键字.
        /// </summary>
        /// <param name="text">输入文本</param>
        /// <returns></returns>
        public bool HasKeyword(string text)
        {
            return !String.IsNullOrEmpty(this.FindOne(text));
        }


        /// <summary>
        /// 返回文本中所包含的首个关键字.
        /// </summary>
        /// <param name="text">输入文本</param>
        /// <returns>找到的第1个关键字.没有则返回string.Empty</returns>
        public string FindOne(string text)
        {
            for (int len = 1; len <= text.Length; len++)
            {
                int maxIndex = text.Length - len;
                for (int index = 0; index <= maxIndex; index++)
                {
                    string key = text.Substring(index, len);
                    if (m_keys.Contains(key))
                    {
                        return key;
                    }
                }
            }
            return string.Empty;
        }


        /// <summary>
        /// 返回目标文本中所包含的所有关键字
        /// </summary>
        /// <param name="text">输入文本</param>
        /// <returns></returns>
        public IEnumerable<string> FindAll(string text)
        {
            for (int len = 1; len <= text.Length; len++)
            {
                int maxIndex = text.Length - len;
                for (int index = 0; index <= maxIndex; index++)
                {
                    string key = text.Substring(index, len);
                    if (m_keys.Contains(key))
                    {
                        yield return key;
                    }
                }
            }
        }



        /// <summary>
        /// 替换关键字
        /// </summary>
        /// <param name="text">输入文本</param>
        /// <param name="c">用于替换的字符</param>
        /// <returns>替换后的字符串</returns>
        public string Replace(string text, char c)
        {
            int maxLen = Math.Min(m_maxLen, text.Length);
            for (int len = 1; len <= maxLen; len++)
            {
                int maxIndex = text.Length - len;
                for (int index = 0; index <= maxIndex; index++)
                {
                    string key = text.Substring(index, len);
                    if (m_keys.Contains(key))
                    {
                        int keyLen = key.Length;
                        text = text.Replace(key, new string(c, keyLen));
                        index += (keyLen - 1);
                    }
                }
            }
            return text;
        }



    }
}
