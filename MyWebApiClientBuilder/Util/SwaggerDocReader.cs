using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;

using Newtonsoft.Json;

using MyWebApiClientBuilder.Model;

namespace MyWebApiClientBuilder.Util
{
    public sealed class SwaggerDocReader
    {

        public static SwaggerDoc GetSwaggerDoc(string url)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                using (Stream s = client.OpenRead(url))
                {
                    using (StreamReader sr = new StreamReader(s, Encoding.UTF8))
                    {
                        string resultText = sr.ReadToEnd();

                        resultText = resultText.Replace("$ref", "ref");

                        SwaggerDoc resultData = JsonConvert.DeserializeObject<SwaggerDoc>(resultText);
                        return resultData;
                    }
                }                
            }
        }

    }
}
