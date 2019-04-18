using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace MyWebApiClientBuilder.Model
{

    /// <summary>
    /// 对象定义的属性.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SwaggerDefinitionPropertie
    {
        /// <summary>
        /// 属性的描述.
        /// </summary>
        [JsonProperty("description")]
        public string Description { set; get; }


        /// <summary>
        /// 数据类型.
        /// </summary>
        [JsonProperty("type")]
        public string Type { set; get; }

    }
}
