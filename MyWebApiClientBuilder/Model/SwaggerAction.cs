using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace MyWebApiClientBuilder.Model
{

    /// <summary>
    /// 请求动作
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SwaggerAction
    {

        /// <summary>
        /// 标签.
        /// </summary>
        [JsonProperty("tags")]
        public string [] Tags { set; get; }


        /// <summary>
        /// 摘要.
        /// </summary>
        [JsonProperty("summary")]
        public string Summary { set; get; }


        /// <summary>
        /// 操作代码.
        /// </summary>
        [JsonProperty("operationId")]
        public string operationId { set; get; }


        /// <summary>
        /// Consumes
        /// </summary>
        [JsonProperty("consumes")]
        public string[] Consumes { set; get; }



        /// <summary>
        /// Produces
        /// </summary>
        [JsonProperty("produces")]
        public string[] Produces { set; get; }



        /// <summary>
        /// 参数.
        /// </summary>
        [JsonProperty("parameters")]
        public SwaggerActionParameter[] Parameters { set; get; }


        /// <summary>
        /// 获取参数列表.
        /// </summary>
        /// <param name="paramType"></param>
        /// <returns></returns>
        public List<string> GetParameterNameList(string paramType)
        {
            return this.Parameters.Where(p => p.In == paramType).Select(p => p.Name).ToList();
        }


        /// <summary>
        /// 获取参数.
        /// </summary>
        /// <param name="paramType"></param>
        /// <returns></returns>
        public List<SwaggerActionParameter> GetParameterList(string paramType)
        {
            return this.Parameters.Where(p => p.In == paramType).ToList();
        }

    }
}
