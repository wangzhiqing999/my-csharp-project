using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace MyWebApiClientBuilder.Model
{

    /// <summary>
    /// 路径
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SwaggerPath
    {

        /// <summary>
        /// GET 请求动作.
        /// </summary>
        [JsonProperty("get")]
        public SwaggerAction Get { set; get; }


        /// <summary>
        /// POST 请求动作.
        /// </summary>
        [JsonProperty("post")]
        public SwaggerAction Post { set; get; }



        /// <summary>
        /// PUT 请求动作.
        /// </summary>
        [JsonProperty("put")]
        public SwaggerAction Put { set; get; }



        /// <summary>
        /// DELETE 请求动作.
        /// </summary>
        [JsonProperty("delete")]
        public SwaggerAction Delete { set; get; }

    }
}
