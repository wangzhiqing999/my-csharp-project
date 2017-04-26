using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWord.Service
{

    /// <summary>
    /// 关键字筛选.
    /// </summary>
    public interface IKeywordsFilter
    {

        /// <summary>
        /// 添加关键词.
        /// </summary>
        /// <param name="word"></param>
        void AddKeyword(string word);



        /// <summary>
        /// 目标文本中，是否包含关键字.
        /// </summary>
        /// <param name="text">输入文本</param>
        /// <returns></returns>
        bool HasKeyword(string text);



        /// <summary>
        /// 返回文本中所包含的首个关键字.
        /// </summary>
        /// <param name="text">输入文本</param>
        /// <returns>找到的第1个关键字.没有则返回string.Empty</returns>
        string FindOne(string text);



        /// <summary>
        /// 返回目标文本中所包含的所有关键字
        /// </summary>
        /// <param name="text">输入文本</param>
        /// <returns></returns>
        IEnumerable<string> FindAll(string text);



        /// <summary>
        /// 替换关键字
        /// </summary>
        /// <param name="text">输入文本</param>
        /// <param name="c">用于替换的字符</param>
        /// <returns>替换后的字符串</returns>
        string Replace(string text, char c);

    }

}
