using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace API.Models
{
    public class Error
    {
        /// <summary>
        /// 返回失败模型
        /// </summary>
        /// <param name="message">传入的输入源</param>
        /// <returns></returns>
        public static HttpResponseMessage ErrorModel(string sign, string message)
        {
            errors model = new errors() { code = "500", datas = null, message = message, sign = sign };

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