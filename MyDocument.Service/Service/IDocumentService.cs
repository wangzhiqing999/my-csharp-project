using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyFramework.Util;

using MyDocument.Model;


namespace MyDocument.Service
{


    public interface IDocumentService
    {

        /// <summary>
        /// 取得文档列表.
        /// </summary>
        /// <param name="typeCode"></param>
        /// <param name="pgInfo"></param>
        /// <returns></returns>
        List<Document> GetDocumentList(string typeCode, ref PageInfo pgInfo);

    }

}
