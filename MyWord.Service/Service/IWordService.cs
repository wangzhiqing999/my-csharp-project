using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyWord.Model;


namespace MyWord.Service
{

    /// <summary>
    /// 词服务接口.
    /// </summary>
    public interface IWordService
    {

        /// <summary>
        /// 获取词列表.
        /// </summary>
        /// <returns></returns>
        List<Word> GetWordList();



        /// <summary>
        /// 新增词.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="resultMessage"></param>
        /// <returns></returns>
        bool NewWord(Word word, ref string resultMessage);


        /// <summary>
        /// 删除词
        /// </summary>
        /// <param name="word"></param>
        /// <param name="resultMessage"></param>
        /// <returns></returns>
        bool RemoveWord(Word word, ref string resultMessage);

    }
}
