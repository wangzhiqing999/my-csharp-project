using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace MyWebApiClientBuilder.Model
{

    /// <summary>
    /// 对象的定义.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SwaggerDefinition
    {

        /// <summary>
        /// 对象的描述.
        /// </summary>
        [JsonProperty("description")]
        public string Description { set; get; }


        /// <summary>
        /// 必须的属性.
        /// </summary>
        [JsonProperty("required")]
        public string[] Required { set; get; }



        /// <summary>
        /// 数据类型.
        /// </summary>
        [JsonProperty("type")]
        public string Type { set; get; }



        /// <summary>
        /// 属性定义.
        /// </summary>
        [JsonProperty("properties")]
        public Dictionary<string, SwaggerDefinitionPropertie> Properties { set; get; }



        /// <summary>
        /// 属性名列表.
        /// </summary>
        public List<string> PropertyNameList
        {
            get
            {
                if (this.Properties == null)
                {
                    return new List<string>();
                }

                return this.Properties.Keys.ToList();
            }
        }


    }
}
