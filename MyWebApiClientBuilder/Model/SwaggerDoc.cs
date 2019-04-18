using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace MyWebApiClientBuilder.Model
{

    /// <summary>
    /// swagger 文档类.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SwaggerDoc
    {

        /// <summary>
        /// swagger 版本.
        /// </summary>
        [JsonProperty("swagger")]
        public string Swagger { set; get; }


        /// <summary>
        /// 基本信息.
        /// </summary>
        [JsonProperty("info")]
        public SwaggerInfo Info { set; get; }


        /// <summary>
        /// 主机.
        /// </summary>
        [JsonProperty("host")]
        public string Host { set; get; }


        /// <summary>
        /// 协议.
        /// </summary>
        [JsonProperty("schemes")]
        public string[] Schemes { set; get; }


        /// <summary>
        /// Web Api 路径.
        /// </summary>
        [JsonProperty("paths")]
        public Dictionary<string, SwaggerPath> Paths { set; get; }



        /// <summary>
        /// 对象定义.
        /// </summary>
        [JsonProperty("definitions")]
        public Dictionary<string, SwaggerDefinition> Definitions { set; get; }


        /// <summary>
        /// 获取指定项目的对象定义.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public SwaggerDefinition GetSwaggerDefinition(string name)
        {
            if (!this.Definitions.ContainsKey(name))
            {
                return null;
            }
            return this.Definitions[name];
        }


    }
}
