using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using COMMON;
using Newtonsoft.Json;
using WEB_API.Models;

namespace WEB_API.Controllers
{
    public class DefaultController : ApiController
    {
        /// <summary>
        /// 逻辑处理层
        /// </summary>
        BLL.ProcBLL bll = new BLL.ProcBLL();
        /// <summary>
        /// 数据容器
        /// </summary>
        public DataTable DT = new DataTable();
        /// <summary>
        /// http响应返回体
        /// </summary>
        HttpResponseMessage R = new HttpResponseMessage();



        /// <summary>
        /// 过去十二个月的销售金额
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage SaleAmount([FromBody]Verification verCode)
        {

            #region 验证代码
            //获取值进行排序
            List<string> listStr = new List<string>();//创建List

            //向List中加入元素，不像数组，List可以无限的加下去，没有越界问题
            listStr.Add(verCode.datetime);//时间戳
            listStr.Add(verCode.stoken);
            listStr.Add(verCode.username);
            listStr.Add(verCode.password);

            StringBuilder sb = new StringBuilder();
            string[] str = listStr.ToArray();//将list容器转为数组
            Array.Sort(str, string.CompareOrdinal);//按照ASCII排序
            foreach (string f in str)
            {
                sb.Append(f);//拼接字符串
            }

            //判断请求是否超时
            long datetimes = Convert.ToInt64(verCode.datetime);//时间戳
            DateTime XiTongDate = DateTime.Now.AddSeconds(30);//获取系统当前时间+30s

            //sign验证
            string yanzheng = (md5(sb.Append("jnht2018").ToString())).ToLower();//用MD5[32]加密
            if (yanzheng == verCode.sign)
            {
                #endregion
                //*******************************************************代码区Start*******************************************************

                DT = bll.Get12MonthSaleDT();
                R = COMMON.StringHelper.JsonHelper(DT);
                DT.Clear();
                //*******************************************************代码区End*******************************************************
                #region 验证代码


                if (DateTime.Now > XiTongDate)
                {
                    return Models.Error.ErrorModel(yanzheng);
                }
            }
            else
            {
                return Models.Error.ErrorModel(yanzheng);
            }
            #endregion

            return R;
        }


        /// <summary>
        /// 品牌销量占比
        /// </summary>
        /// <param name="verCode"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage SalesRatio([FromBody]Verification verCode)
        {

            #region 验证代码
            //获取值进行排序
            List<string> listStr = new List<string>();//创建List

            //向List中加入元素，不像数组，List可以无限的加下去，没有越界问题
            listStr.Add(verCode.datetime);//时间戳
            listStr.Add(verCode.stoken);
            listStr.Add(verCode.username);
            listStr.Add(verCode.password);

            StringBuilder sb = new StringBuilder();
            string[] str = listStr.ToArray();//将list容器转为数组
            Array.Sort(str, string.CompareOrdinal);//按照ASCII排序
            foreach (string f in str)
            {
                sb.Append(f);//拼接字符串
            }

            //判断请求是否超时
            long datetimes = Convert.ToInt64(verCode.datetime);//时间戳
            DateTime XiTongDate = DateTime.Now.AddSeconds(30);//获取系统当前时间+30s

            //sign验证
            string yanzheng = (md5(sb.Append("jnht2018").ToString())).ToLower();//用MD5[32]加密
            if (yanzheng == verCode.sign)
            {
                #endregion
                //*******************************************************代码区Start*******************************************************

                DT = bll.GetbrandSaleDT();
                R = COMMON.StringHelper.JsonHelper(DT);
                DT.Clear();
                //*******************************************************代码区End*******************************************************
                #region 验证代码


                if (DateTime.Now > XiTongDate)
                {
                    return Models.Error.ErrorModel(yanzheng);
                }
            }
            else
            {
                return Models.Error.ErrorModel(yanzheng);
            }
            #endregion

            return R;
        }


        /// <summary>
        /// 当前库存金额数据
        /// </summary>
        /// <param name="verCode"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage CurrInventoryData([FromBody]Verification verCode)
        {

            #region 验证代码
            //获取值进行排序
            List<string> listStr = new List<string>();//创建List

            //向List中加入元素，不像数组，List可以无限的加下去，没有越界问题
            listStr.Add(verCode.datetime);//时间戳
            listStr.Add(verCode.stoken);
            listStr.Add(verCode.username);
            listStr.Add(verCode.password);


            StringBuilder sb = new StringBuilder();
            string[] str = listStr.ToArray();//将list容器转为数组
            Array.Sort(str, string.CompareOrdinal);//按照ASCII排序
            foreach (string f in str)
            {
                sb.Append(f);//拼接字符串
            }

            //判断请求是否超时
            long datetimes = Convert.ToInt64(verCode.datetime);//时间戳
            DateTime XiTongDate = DateTime.Now.AddSeconds(30);//获取系统当前时间+30s

            //sign验证
            string yanzheng = (md5(sb.Append("jnht2018").ToString())).ToLower();//用MD5[32]加密
            if (yanzheng == verCode.sign)
            {
                #endregion
                //*******************************************************代码区Start*******************************************************

                DT = bll.GetJSKCDT();
                R = COMMON.StringHelper.JsonHelper(DT);
                DT.Clear();
                //*******************************************************代码区End*******************************************************
                #region 验证代码


                if (DateTime.Now > XiTongDate)
                {
                    return Models.Error.ErrorModel(yanzheng);
                }
            }
            else
            {
                return Models.Error.ErrorModel(yanzheng);
            }
            #endregion

            return R;
        }


        /// <summary>
        /// 门店采购数据
        /// </summary>
        /// <param name="verCode"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage StorePurchData([FromBody]Verification verCode)
        {

            #region 验证代码
            //获取值进行排序
            List<string> listStr = new List<string>();//创建List

            //向List中加入元素，不像数组，List可以无限的加下去，没有越界问题
            listStr.Add(verCode.datetime);//时间戳
            listStr.Add(verCode.stoken);
            listStr.Add(verCode.username);
            listStr.Add(verCode.password);


            StringBuilder sb = new StringBuilder();
            string[] str = listStr.ToArray();//将list容器转为数组
            Array.Sort(str, string.CompareOrdinal);//按照ASCII排序
            foreach (string f in str)
            {
                sb.Append(f);//拼接字符串
            }

            //判断请求是否超时
            long datetimes = Convert.ToInt64(verCode.datetime);//时间戳
            DateTime XiTongDate = DateTime.Now.AddSeconds(30);//获取系统当前时间+30s

            //sign验证
            string yanzheng = (md5(sb.Append("jnht2018").ToString())).ToLower();//用MD5[32]加密
            if (yanzheng == verCode.sign)
            {
                #endregion
                //*******************************************************代码区Start*******************************************************

                DT = bll.GetShopInDT();
                R = COMMON.StringHelper.JsonHelper(DT);
                DT.Clear();
                //*******************************************************代码区End*******************************************************
                #region 验证代码


                if (DateTime.Now > XiTongDate)
                {
                    return Models.Error.ErrorModel(yanzheng);
                }
            }
            else
            {
                return Models.Error.ErrorModel(yanzheng);
            }
            #endregion

            return R;
        }

        /// <summary>
        /// 门店销量数据 【Desc 类型：从高到低】
        /// </summary>
        /// <param name="verCode"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage StoreSaleData([FromBody]Verification verCode)
        {

            #region 验证代码
            //获取值进行排序
            List<string> listStr = new List<string>();//创建List

            //向List中加入元素，不像数组，List可以无限的加下去，没有越界问题
            listStr.Add(verCode.datetime);//时间戳
            listStr.Add(verCode.stoken);
            listStr.Add(verCode.username);
            listStr.Add(verCode.password);


            StringBuilder sb = new StringBuilder();
            string[] str = listStr.ToArray();//将list容器转为数组
            Array.Sort(str, string.CompareOrdinal);//按照ASCII排序
            foreach (string f in str)
            {
                sb.Append(f);//拼接字符串
            }

            //判断请求是否超时
            long datetimes = Convert.ToInt64(verCode.datetime);//时间戳
            DateTime XiTongDate = DateTime.Now.AddSeconds(30);//获取系统当前时间+30s

            //sign验证
            string yanzheng = (md5(sb.Append("jnht2018").ToString())).ToLower();//用MD5[32]加密
            if (yanzheng == verCode.sign)
            {
                #endregion
                //*******************************************************代码区Start*******************************************************

                DT = bll.GetShopSaleDT();
                R = COMMON.StringHelper.JsonHelper(DT);
                DT.Clear();
                //*******************************************************代码区End*******************************************************
                #region 验证代码


                if (DateTime.Now > XiTongDate)
                {
                    return Models.Error.ErrorModel(yanzheng);
                }
            }
            else
            {
                return Models.Error.ErrorModel(yanzheng);
            }
            #endregion

            return R;
        }


        /// <summary>
        /// 农机销量数据比【Desc 类型由高到低】
        /// </summary>
        /// <param name="verCode"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetMachineTypeSaleData([FromBody]Verification verCode)
        {

            #region 验证代码
            //获取值进行排序
            List<string> listStr = new List<string>();//创建List

            //向List中加入元素，不像数组，List可以无限的加下去，没有越界问题
            listStr.Add(verCode.datetime);//时间戳
            listStr.Add(verCode.stoken);
            listStr.Add(verCode.username);
            listStr.Add(verCode.password);


            StringBuilder sb = new StringBuilder();
            string[] str = listStr.ToArray();//将list容器转为数组
            Array.Sort(str, string.CompareOrdinal);//按照ASCII排序
            foreach (string f in str)
            {
                sb.Append(f);//拼接字符串
            }

            //判断请求是否超时
            long datetimes = Convert.ToInt64(verCode.datetime);//时间戳
            DateTime XiTongDate = DateTime.Now.AddSeconds(30);//获取系统当前时间+30s

            //sign验证
            string yanzheng = (md5(sb.Append("jnht2018").ToString())).ToLower();//用MD5[32]加密
            if (yanzheng == verCode.sign)
            {
                #endregion
                //*******************************************************代码区Start*******************************************************

                DT = bll.GetTypeSaleDT();
                R = COMMON.StringHelper.JsonHelper(DT);
                DT.Clear();

                //*******************************************************代码区End*******************************************************
                #region 验证代码


                if (DateTime.Now > XiTongDate)
                {
                    return Models.Error.ErrorModel(yanzheng);
                }
            }
            else
            {
                return Models.Error.ErrorModel(yanzheng);
            }
            #endregion

            return R;
        }


        /// <summary>
        ///本年，本月，昨天，今天即时数据
        /// </summary>
        /// <param name="verCode"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetYearMonthLastDaySaleDate([FromBody]Verification verCode)
        {

            #region 验证代码
            //获取值进行排序
            List<string> listStr = new List<string>();//创建List

            //向List中加入元素，不像数组，List可以无限的加下去，没有越界问题
            listStr.Add(verCode.datetime);//时间戳
            listStr.Add(verCode.stoken);
            listStr.Add(verCode.username);
            listStr.Add(verCode.password);


            StringBuilder sb = new StringBuilder();
            string[] str = listStr.ToArray();//将list容器转为数组
            Array.Sort(str, string.CompareOrdinal);//按照ASCII排序
            foreach (string f in str)
            {
                sb.Append(f);//拼接字符串
            }

            //判断请求是否超时
            long datetimes = Convert.ToInt64(verCode.datetime);//时间戳
            DateTime XiTongDate = DateTime.Now.AddSeconds(30);//获取系统当前时间+30s

            //sign验证
            string yanzheng = (md5(sb.Append("jnht2018").ToString())).ToLower();//用MD5[32]加密
            if (yanzheng == verCode.sign)
            {
                #endregion
                //*******************************************************代码区Start*******************************************************

                DT = bll.GetYearMonthLastDaySaleDT();
                R = COMMON.StringHelper.JsonHelper(DT);
                DT.Clear();
                //*******************************************************代码区End*******************************************************
                #region 验证代码


                if (DateTime.Now > XiTongDate)
                {
                    return Models.Error.ErrorModel(yanzheng);
                }
            }
            else
            {
                return Models.Error.ErrorModel(yanzheng);
            }
            #endregion

            return R;
        }

        /// <summary>
        ///本年度每月成交客户详情
        /// </summary>
        /// <param name="verCode"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetYearSaleData([FromBody]Verification verCode)
        {

            #region 验证代码
            //获取值进行排序
            List<string> listStr = new List<string>();//创建List

            //向List中加入元素，不像数组，List可以无限的加下去，没有越界问题
            listStr.Add(verCode.datetime);//时间戳
            listStr.Add(verCode.stoken);
            listStr.Add(verCode.username);
            listStr.Add(verCode.password);


            StringBuilder sb = new StringBuilder();
            string[] str = listStr.ToArray();//将list容器转为数组
            Array.Sort(str, string.CompareOrdinal);//按照ASCII排序
            foreach (string f in str)
            {
                sb.Append(f);//拼接字符串
            }

            //判断请求是否超时
            long datetimes = Convert.ToInt64(verCode.datetime);//时间戳
            DateTime XiTongDate = DateTime.Now.AddSeconds(30);//获取系统当前时间+30s

            //sign验证
            string yanzheng = (md5(sb.Append("jnht2018").ToString())).ToLower();//用MD5[32]加密
            if (yanzheng == verCode.sign)
            {
                #endregion
                //*******************************************************代码区Start*******************************************************

                DT = bll.GetYearSaleDT();
                R = COMMON.StringHelper.JsonHelper(DT);
                DT.Clear();
                //*******************************************************代码区End*******************************************************
                #region 验证代码


                if (DateTime.Now > XiTongDate)
                {
                    return Models.Error.ErrorModel(yanzheng);
                }
            }
            else
            {
                return Models.Error.ErrorModel(yanzheng);
            }
            #endregion

            return R;
        }

        #region MD5加密[32位]
        public static String md5(String s)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(s);
            bytes = md5.ComputeHash(bytes);
            md5.Clear();

            string ret = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                ret += Convert.ToString(bytes[i], 16).PadLeft(2, '0');
            }

            return ret.PadLeft(32, '0');
        }
        #endregion

    }
}
