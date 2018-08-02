using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace WEB_API.Models
{
    /// <summary>
    /// 失败模型
    /// </summary>
    public class Error
    {
        /// <summary>
        /// 返回失败模型
        /// </summary>
        /// <param name="message">传入的输入源</param>
        /// <returns></returns>
        public static HttpResponseMessage ErrorModel(string VerlCode)
        {
            errors model = new errors() { code = "200", datas = "null", message = "message", sign = VerlCode };

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")
            };
        }

        public class errors
        {

            public string code { get; set; }
            public string message { get; set; }
            public string datas { get; set; }
            public string sign { get; set; }

        }
    }
}
