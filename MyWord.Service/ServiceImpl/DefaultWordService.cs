using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MyWord.Model;
using MyWord.DataAccess;
using MyWord.Service;


namespace MyWord.ServiceImpl
{
    /// <summary>
    /// 词服务实现.
    /// </summary>
    public class DefaultWordService : IWordService
    {
        /// <summary>
        /// 获取词列表.
        /// </summary>
        /// <returns></returns>
        public List<Word> GetWordList()
        {
            using (MyWordContext context = new MyWordContext())
            {
                var query =
                    from data in context.Words
                    select data;

                List<Word> resultList = query.ToList();

                return resultList;
            }
        }


        /// <summary>
        /// 新增词.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="resultMessage"></param>
        /// <returns></returns>
        public bool NewWord(Word word, ref string resultMessage)
        {
            using (MyWordContext context = new MyWordContext())
            {
                var query =
                    from data in context.Words
                    where data.WordValue == word.WordValue
                    select data;

                if (query.Count() > 0)
                {
                    resultMessage = String.Format("词 {0} 已存在！", word.WordValue);
                    return false;
                }

                context.Words.Add(word);
                context.SaveChanges();

                return true;
            }
        }


        /// <summary>
        /// 删除词
        /// </summary>
        /// <param name="word"></param>
        /// <param name="resultMessage"></param>
        /// <returns></returns>
        public bool RemoveWord(Word word, ref string resultMessage)
        {
            using (MyWordContext context = new MyWordContext())
            {
                if (word.WordID > 0)
                {
                    // 先根据ID进行处理.                
                    var dbData = context.Words.Find(word.WordID);
                    if (dbData != null)
                    {
                        // 找到数据.
                        context.Words.Remove(dbData);
                        context.SaveChanges();
                        return true;
                    }
                }


                // 如果没有指定ID， 则针对词进行处理.
                var query =
                    from data in context.Words
                    where data.WordValue == word.WordValue
                    select data;

                var dbData2 = query.FirstOrDefault();

                if (dbData2 != null)
                {
                    // 找到数据.
                    context.Words.Remove(dbData2);
                    context.SaveChanges();
                    return true;
                }
               
                resultMessage = "数据不存在！";
                return false;
               
            }
        }
    }

}
