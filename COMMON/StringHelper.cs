using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace COMMON
{
    public class StringHelper
    {

        #region dt转json
        /// <summary>
        /// 将DataTable转化为HttpResponseMessage格式
        /// </summary>
        /// <param name="dtSoure"></param>
        /// <returns></returns>
        public static HttpResponseMessage JsonHelper(DataTable dtSoure)
        {
            string json = string.Empty;
            string allPageResoult = string.Empty;
            if (dtSoure == null)
            { 
                allPageResoult = string.Concat(new object[] { "{\"code\":", 500, ",\"message\":", "请求成功！但查询出错", ",\"datas\":", json, "}" });
            }
            else
            {
                json = JsonConvert.SerializeObject(dtSoure);
                allPageResoult = string.Concat(new object[] { "{\"code\":", 200, ",\"message\":", "null", ",\"datas\":", json, "}" });
            }

            return new HttpResponseMessage()
            {
                Content = new StringContent(allPageResoult, Encoding.UTF8, "application/json")
            };
        }
        #endregion

    }
}
