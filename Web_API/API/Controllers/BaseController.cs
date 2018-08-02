using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using API.Models;
using Newtonsoft.Json;

namespace API.Controllers
{
    public abstract class BaseController : ApiController
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            //初始化请求上下文
            base.Initialize(controllerContext);

            #region 获取客户端传过来的参数

           
            #endregion


        }


        #region token校验

        public abstract bool SignStoken(string verCode);
        public abstract HttpResponseMessage FailStoken();

        #endregion
    }
}
