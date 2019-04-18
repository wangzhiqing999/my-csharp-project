using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace MyWebApiClientBuilder.Model
{

    /// <summary>
    /// swagger 基本信息.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SwaggerInfo
    {
        /// <summary>
        /// 版本.
        /// </summary>
        [JsonProperty("version")]
        public string Version { set; get;}


        /// <summary>
        /// 标题.
        /// </summary>
        [JsonProperty("title")]
        public string Title { set; get; }

    }
}
