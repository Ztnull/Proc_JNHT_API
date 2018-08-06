using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;
using API.Models;
using Newtonsoft.Json;


namespace API.Controllers
{
    public class HomeController : ApiController
    {

        public HomeController()
        {
            var request = HttpContext.Current.Request;
            request.InputStream.Position = 0;//核心代码
            byte[] byts = new byte[request.InputStream.Length];
            request.InputStream.Read(byts, 0, byts.Length);
            string pa = Encoding.Default.GetString(byts);

            var parsModel = JsonConvert.DeserializeObject<Verification>(pa);
            if (!SignStoken(parsModel))
            {
                state = 1;
            }
        }

        /// <summary>
        /// 逻辑处理层
        /// </summary>
        BLL.ProcBLL bll = new BLL.ProcBLL();

        /// <summary>
        /// 数据容器
        /// </summary>
        private DataTable DT = new DataTable();
        private delegate HttpResponseMessage delegateMessage();
        /// <summary>
        /// 响应返回体
        /// </summary>
        HttpResponseMessage R = new HttpResponseMessage();

        /// <summary>
        /// stoken验证状态[Message:但状态为：1时，结束当前操作]
        /// </summary>
        public int state { get; set; }



        public static bool SignStoken(Verification verCode)
        {
            try
            {
                if (verCode.stoken != "33436stokensysgcaich" || verCode.password != "2018-07-171211" || verCode.username != "jnht2018")
                    return false;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// 过去十二个月的销售金额
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage SaleAmount([FromBody]Verification verCode)
        {
            return R = GetObjAction(verCode, state, () =>
                     {
                         DT = bll.Get12MonthSaleDT();
                         R = COMMON.StringHelper.JsonHelper(DT);
                         if (DT != null) DT.Clear();
                         return R;
                     });
        }



        /// <summary>
        /// 品牌销量占比
        /// </summary>
        /// <param name="verCode"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage SalesRatio([FromBody]Verification verCode)
        {
            return R = GetObjAction(verCode, state, () =>
               {
                   DT = bll.GetbrandSaleDT();
                   R = COMMON.StringHelper.JsonHelper(DT);
                   if (DT != null) DT.Clear();
                   return R;
               });
        }



        /// <summary>
        /// 当前库存金额数据
        /// </summary>
        /// <param name="verCode"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage CurrInventoryData([FromBody]Verification verCode)
        {

            return R = GetObjAction(verCode, state, () =>
           {
               DT = bll.GetJSKCDT();
               R = COMMON.StringHelper.JsonHelper(DT);
               if (DT != null) DT.Clear();
               return R;
           });
        }



        /// <summary>
        /// 门店采购数据
        /// </summary>
        /// <param name="verCode"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage StorePurchData([FromBody]Verification verCode)
        {
            return R = GetObjAction(verCode, state, () =>
           {
               DT = bll.GetShopInDT();
               R = COMMON.StringHelper.JsonHelper(DT);
               if (DT != null) DT.Clear();
               return R;
           });
        }

        /// <summary>
        /// 门店销量数据 【Desc 类型：从高到低】
        /// </summary>
        /// <param name="verCode"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage StoreSaleData([FromBody]Verification verCode)
        {

            return R = GetObjAction(verCode, state, () =>
           {
               DT = bll.GetShopSaleDT();
               R = COMMON.StringHelper.JsonHelper(DT);
               if (DT != null) DT.Clear();
               return R;
           });
        }


        /// <summary>
        /// 农机销量数据比【Desc 类型由高到低】
        /// </summary>
        /// <param name="verCode"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetMachineTypeSaleData([FromBody]Verification verCode)
        {
            return R = GetObjAction<HttpResponseMessage>(verCode, state, () =>
           {
               DT = bll.GetTypeSaleDT();
               R = COMMON.StringHelper.JsonHelper(DT);
               if (DT != null) DT.Clear();
               return R;
           });
        }


        #region 不使用此方法
        //Func<HttpResponseMessage>  new Func<HttpResponseMessage>( () => ()
        //{
        //    BLL.ProcBLL bll = new BLL.ProcBLL();
        //    var DT = bll.GetYearMonthLastDaySaleDT();
        //    HttpResponseMessage m = new HttpResponseMessage();
        //    m = COMMON.StringHelper.JsonHelper(DT);
        //    if(DT!=null)  DT.Clear();
        //    return m;
        //}); 
        #endregion

        /// <summary>
        ///本年，本月，昨天，今天即时数据
        /// </summary>
        /// <param name="verCode"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetYearMonthLastDaySaleDate([FromBody]Verification verCode)
        {
            return R = GetObjAction(verCode, state, () =>
            {
                DT = bll.GetYearMonthLastDaySaleDT();
                R = COMMON.StringHelper.JsonHelper(DT);
                if (DT != null) DT.Clear();
                return R;
            });
        }


        /// <summary>
        ///本年度每月成交客户详情
        /// </summary>
        /// <param name="verCode"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetYearSaleData([FromBody]Verification verCode)
        {
            return R = GetObjAction(verCode, state, () =>
                {
                    DT = bll.GetYearSaleDT();
                    R = COMMON.StringHelper.JsonHelper(DT);
                    if (DT != null) DT.Clear();
                    return R;
                });
        }




        /*********************************************Oracle 时间 ： 2018年7月30日*********************************************************/
        #region Oracle 时间 ： 2018年7月30日
        /*
    [HttpPost]
    public HttpResponseMessage GetDEPMENT([FromBody]Verification verCode)
    {
        return R = GetObjAction(verCode, state,
             () =>
        {
            DT = bll.GetSF_DEPMENT();
            R = COMMON.StringHelper.JsonHelper(DT);
            if(DT!=null)  DT.Clear();
            return R;
        });
    }
    [HttpPost]
    public HttpResponseMessage Getitem([FromBody]Verification verCode)
    {
        return R = GetObjAction(verCode, state,
           () =>
     {
         DT = bll.Getsf_item();
         R = COMMON.StringHelper.JsonHelper(DT);
         if(DT!=null)  DT.Clear();
         return R;
     });
    }

    [HttpPost]
    public HttpResponseMessage Getitem_type([FromBody]Verification verCode)
    {
        return R = GetObjAction(verCode, state,
           () =>
          {
              DT = bll.Getsf_item_type();
              R = COMMON.StringHelper.JsonHelper(DT);
              if(DT!=null)  DT.Clear();
              return R;
          });
    }

    [HttpPost]
    public HttpResponseMessage Getcustomer([FromBody]Verification verCode)
    {
        return R = GetObjAction(verCode, state,
           () =>
          {
              DT = bll.Getsf_customer();
              R = COMMON.StringHelper.JsonHelper(DT);
              if(DT!=null)  DT.Clear();
              return R;
          });
    }

    [HttpPost]
    public HttpResponseMessage Getsupplier([FromBody]Verification verCode)
    {
        return R = GetObjAction(verCode, state,
           () =>
          {
              DT = bll.Getsf_supplier();
              R = COMMON.StringHelper.JsonHelper(DT);
              if(DT!=null)  DT.Clear();
              return R;
          });
    }
    [HttpPost]
    public HttpResponseMessage Getpurorder([FromBody]Verification verCode)
    {
        return R = GetObjAction(verCode, state,
           () =>
          {
              DT = bll.Getsf_purorder();
              R = COMMON.StringHelper.JsonHelper(DT);
              if(DT!=null)  DT.Clear();
              return R;
          });
    }

    [HttpPost]
    public HttpResponseMessage Getsaleissuebill([FromBody]Verification verCode)
    {
        return R = GetObjAction(verCode, state,
           () =>
          {
              DT = bll.Getsf_saleissuebill();
              R = COMMON.StringHelper.JsonHelper(DT);
              if(DT!=null)  DT.Clear();
              return R;
          });
    } 

    [HttpPost]
    public HttpResponseMessage Getpurinwarehsbill([FromBody]Verification verCode)
    {
        return R = GetObjAction(verCode, state,
           () =>
          {
              DT = bll.Getsf_purinwarehsbill();
              R = COMMON.StringHelper.JsonHelper(DT);
              if(DT!=null)  DT.Clear();
              return R;
          });
    }
    [HttpPost]
    public HttpResponseMessage Getotherissuebill([FromBody]Verification verCode)
    {
        return R = GetObjAction(verCode, state,
           () =>
          {
              DT = bll.Getsf_otherissuebill();
              R = COMMON.StringHelper.JsonHelper(DT);
              if(DT!=null)  DT.Clear();
              return R;
          });
    }


    [HttpPost]
    public HttpResponseMessage Getotherinwarehsbill([FromBody]Verification verCode)
    {
        return R = GetObjAction(verCode, state,
           () =>
          {
              DT = bll.Getsf_otherinwarehsbill();
              R = COMMON.StringHelper.JsonHelper(DT);
              if(DT!=null)  DT.Clear();
              return R;
          });
    }
    [HttpPost]
    public HttpResponseMessage Getmoveinwarehsbill([FromBody]Verification verCode)
    {
        return R = GetObjAction(verCode, state,
           () =>
          {
              DT = bll.Getsf_moveinwarehsbill();
              R = COMMON.StringHelper.JsonHelper(DT);
              if(DT!=null)  DT.Clear();
              return R;
          });
    }

*/
        #endregion


        public HttpResponseMessage GetObjAction<T>(Verification verCode, int state, Func<T> action)
        {

            if (state == 1)
            {
                return Models.Error.ErrorModel(null, "stoken错误");
            }


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
            DateTime XiTongDate = DateTime.Now.AddSeconds(200);//获取系统当前时间+200s


            string yanzheng = (md5(sb.Append("jnht2018").ToString())).ToLower();
            if (yanzheng == verCode.sign)
            {
                #endregion

                R = action.Invoke() as HttpResponseMessage;

                #region 验证代码


                if (DateTime.Now > XiTongDate)
                {
                    return Models.Error.ErrorModel(yanzheng, null);
                }
            }
            else
            {
                return Models.Error.ErrorModel(yanzheng, null);
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
