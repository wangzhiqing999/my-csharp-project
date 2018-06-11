using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyHelp.Model;
using MyHelp.DataAccess;
using MyHelp.Service;

namespace MyHelp.ServiceImpl
{

    /// <summary>
    /// 默认的帮助服务.
    /// </summary>
    public class DefaultHelpService : IHelpService
    {
        /// <summary>
        /// 根据输入的文本，获取可用的帮助文档.
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="topN"></param>
        /// <returns></returns>
        List<HelpDocument> IHelpService.GetHelpDocumentByInputKeyword(string inputText, int topN)
        {
            using (MyHelpContext context = new MyHelpContext())
            {
                var query =
                    from data in context.HelpKeywords.Include("HelpDocumentList")
                    where
                        data.KeywordText.Contains(inputText)
                    select
                        data;


                List<HelpDocument> resultList = new List<HelpDocument>();

                foreach (HelpKeyword keywordData in query)
                {
                    foreach (HelpDocument doc in keywordData.HelpDocumentList)
                    {
                        if (!resultList.Exists(p => p.DocumentID == doc.DocumentID))
                        {
                            resultList.Add(doc);
                        }

                        if (resultList.Count >= topN)
                        {
                            break;
                        }
                    }
                }

                return resultList;
            }
        }



        HelpDocument IHelpService.GetHelpDocument(long id)
        {
            using (MyHelpContext context = new MyHelpContext())
            {
                HelpDocument doc = context.HelpDocuments.Find(id);
                return doc;
            }
        }

    }

}
