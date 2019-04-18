using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyWebApiClientBuilder.Model;


namespace MyWebApiClientBuilder.Template
{
    partial class MyJavaScriptService
    {

        /// <summary>
        /// 服务文档.
        /// </summary>
        public SwaggerDoc DocInfo { set; get; }


        public MyJavaScriptService(SwaggerDoc swaggerDoc)
        {
            this.DocInfo = swaggerDoc;
        }

    }
}
