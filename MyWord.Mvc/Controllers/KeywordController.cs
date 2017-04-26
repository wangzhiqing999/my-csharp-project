using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MyWord.Model;
using MyWord.Service;
using MyWord.ServiceImpl;


namespace MyWord.Mvc.Controllers
{
    public class KeywordController : Controller
    {

        /// <summary>
        /// 词服务.
        /// </summary>
        private IWordService wordService = new DefaultWordService();



        /// <summary>
        /// 关键字查询服务.
        /// </summary>
        private IKeywordsFilter keywordsFilter = new DefaultKeywordsFilter();



        public KeywordController()
        {
            List<Word> wordList = this.wordService.GetWordList();

            foreach (var word in wordList)
            {
                // 添加关键字.
                keywordsFilter.AddKeyword(word.WordValue);
            }
        }



        #region 提供给客户端检查的代码.

        // GET: Keyword
        [OutputCache(Duration = 60)]
        public JsonResult Index()
        {
            // 查询全部的关键字.
            List<Word> wordList = this.wordService.GetWordList();

            // 只返回词的部分.
            var resultList =
                wordList.Select(p => p.WordValue).ToList();

            return Json(resultList, JsonRequestBehavior.AllowGet);
        }

        #endregion 提供给客户端检查的代码.








        #region 提供给服务端检查的代码.

        /// <summary>
        ///  目标文本中，是否包含关键字.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public JsonResult HasKeyword(string text)
        {
            bool result = this.keywordsFilter.HasKeyword(text);
            return Json(result);
        }


        /// <summary>
        /// 替换关键字
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public JsonResult Replace(string text)
        {
            string result = this.keywordsFilter.Replace(text, '*');
            return Json(result);
        }


        #endregion 提供给服务端检查的代码.


    }
}