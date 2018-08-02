using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace WEB_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            // 4.Web API 配置和服务
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());

            // 启用Web API特性路由
            config.MapHttpAttributeRoutes();
            // 默认路由：

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //2.自定义路由一：匹配到action
            config.Routes.MapHttpRoute(
                name: "ActionApi",
                routeTemplate: "actionapi/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //3.自定义路由二
            config.Routes.MapHttpRoute(
                name: "TestApi",
                routeTemplate: "testapi/{controller}/{ordertype}/{id}",
                defaults: new { ordertype = "aa", id = RouteParameter.Optional }
                //访问的路径可以写成：testapi/{controller}/aa/{id}
            );
        }
    }
}
