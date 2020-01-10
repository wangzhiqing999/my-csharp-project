using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace MyWebApiClientBuilder.Model
{

    /// <summary>
    /// 请求动作参数.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SwaggerActionParameter
    {

        /// <summary>
        /// 参数名称.
        /// </summary>
        [JsonProperty("name")]
        public string Name { set; get; }


        /// <summary>
        /// 参数入口.
        /// (可能的值： path / query / body / header  )
        /// </summary>
        [JsonProperty("in")]
        public string In { set; get; }


        /// <summary>
        /// 参数的描述.
        /// </summary>
        [JsonProperty("description")]
        public string Description { set; get; }


        /// <summary>
        /// 是否必须.
        /// </summary>
        [JsonProperty("required")]
        public bool Required { set; get; }


        /// <summary>
        /// 数据类型.
        /// </summary>
        [JsonProperty("type")]
        public string Type { set; get; }


        /// <summary>
        /// 格式.
        /// </summary>
        [JsonProperty("format")]
        public string Format { set; get; }



        /// <summary>
        /// Schema
        /// </summary>
        [JsonProperty("schema")]
        public Dictionary<string, Object> Schema { set; get; }



        /// <summary>
        /// 引用类的最后一个名称.
        /// </summary>
        public string SchemaRefName
        {
            get
            {
                if (this.Schema == null || this.Schema.Count == 0)
                {
                    // 数据集合存在.
                    return null;
                }

                if(!this.Schema.ContainsKey("ref")) {
                    // 数据集合中不存在指定关键字.
                    return null;
                }


                if (this.Schema.ContainsKey("ref"))
                {
                    string refString = this.Schema["ref"].ToString();
                    if (String.IsNullOrEmpty(refString))
                    {
                        // 数据为空白.
                        return null;
                    }

                    string[] refArray = refString.Split('/');

                    return refArray.Last();
                }

                return null;
            }
        }



    }

}
