using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyWord.Service;

namespace MyWord.ServiceImpl
{

    /// <summary>
    /// 默认的关键字筛选.
    /// 
    /// 仅仅为通过单元测试而写， 效率贼差的.
    /// </summary>
    public class DefaultKeywordsFilter : IKeywordsFilter
    {

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
            if (!string.IsNullOrEmpty(word))  
            {
                m_keys.Add(word);
            }
        }


        /// <summary>
        /// 目标文本中，是否包含关键字.
        /// </summary>
        /// <param name="text">输入文本</param>
        /// <returns></returns>
        public bool HasKeyword(string text)
        {
            // 遍历每一个关键字.
            foreach (var keyword in this.m_keys)
            {
                if (text.Contains(keyword))
                {
                    // 如果存在，则返回 true.
                    return true;
                }
            }
            // 都不存在的情况下， 返回 false.
            return false;
        }



        /// <summary>
        /// 返回文本中所包含的首个关键字.
        /// </summary>
        /// <param name="text">输入文本</param>
        /// <returns>找到的第1个关键字.没有则返回string.Empty</returns>
        public string FindOne(string text)
        {
            // 最小的索引.
            int minIndex = text.Length ;
            // 预期的结果.
            string result = string.Empty;

            // 遍历每一个关键字.
            foreach (var keyword in this.m_keys)
            {
                // 关键字的位置.
                int index = text.IndexOf(keyword);
                if (index == -1)
                {
                    continue;
                }

                if (minIndex > index)
                {
                    // 位置靠前.
                    minIndex = index;
                    // 设置结果.
                    result = keyword;
                }                
            }
            // 返回.
            return result;
        }


        /// <summary>
        /// 返回目标文本中所包含的所有关键字
        /// </summary>
        /// <param name="text">输入文本</param>
        /// <returns></returns>
        public IEnumerable<string> FindAll(string text)
        {
            List<string> resultList = new List<string>();

            // 遍历每一个关键字.
            foreach (var keyword in this.m_keys)
            {
                if (text.Contains(keyword))
                {
                    // 如果存在，则将当前 keyword 加入结果列表.
                    resultList.Add( keyword);
                }
            }

            return resultList;
        }



        /// <summary>
        /// 替换关键字
        /// </summary>
        /// <param name="text">输入文本</param>
        /// <param name="c">用于替换的字符</param>
        /// <returns>替换后的字符串</returns>
        public string Replace(string text, char c)
        {
            string result = text;

            // 遍历每一个关键字.
            foreach (var keyword in this.m_keys.OrderByDescending(p=>p.Length))
            {
                if (text.Contains(keyword))
                {
                    // 如果存在，则进行替换.
                    string replaceWord = new String(c, keyword.Length);
                    result = result.Replace(keyword, replaceWord);
                }
            }

            return result;
        }

    }
}
