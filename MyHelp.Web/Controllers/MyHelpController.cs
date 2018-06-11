using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MyHelp.Model;
using MyHelp.Service;
using MyHelp.ServiceImpl;


namespace MyHelp.Web.Controllers
{
    public class MyHelpController : ApiController
    {

        /// <summary>
        /// 帮助文档服务.
        /// </summary>
        private IHelpService _HelpService = new DefaultHelpService();


        [HttpGet]
        [Route("api/MyHelp/QueryKeyword")]
        public List<HelpDocument> QueryKeyword(string input)
        {
            List<HelpDocument> resultList = this._HelpService.GetHelpDocumentByInputKeyword(input);
            return resultList;
        }


        [HttpGet]
        [Route("api/MyHelp/GetHelpDoc")]
        public HelpDocument GetHelpDoc(long id)
        {
            HelpDocument result = this._HelpService.GetHelpDocument(id);
            return result;
        }

    }
}
