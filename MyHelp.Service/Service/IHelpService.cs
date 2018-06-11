using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyHelp.Model;


namespace MyHelp.Service
{

    /// <summary>
    /// 帮助服务.
    /// </summary>
    public interface IHelpService
    {


        /// <summary>
        /// 根据输入的文本，获取可用的帮助文档.
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="topN"></param>
        /// <returns></returns>
        List<HelpDocument> GetHelpDocumentByInputKeyword(string inputText, int topN = 5);



        /// <summary>
        /// 获取帮助文档
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        HelpDocument GetHelpDocument(long id);


    }
}
