using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class ProcBLL
    {
        ProcSQLServerDAL dal = new ProcSQLServerDAL();




        /// <summary>
        /// 增加当天新订单
        /// </summary>
        /// <returns></returns>
        public DataTable GetTodayNewOrderDT()
        {
            return dal.GetTodayNewOrderDT();
        }

        /// <summary>
        /// 省份名称和客户数量 
        /// </summary>
        /// <returns></returns>
        public DataTable GetProvinceCustomerSumDT()
        {
            return dal.GetProvinceCustomerSumDT();
        }


        /// <summary>
        /// 查询当前缺货的门店及对应缺货的名目
        /// </summary>
        /// <returns></returns>
        public DataTable GetCurrOOSStoreNameDT()
        {
            return dal.GetCurrOOSStoreNameDT();
        }

        /// <summary>
        /// 门店
        /// </summary>
        /// <returns></returns>
        public DataTable GetStoreDT()
        {
            return dal.GetStoreDT();
        }


        /// <summary>
        /// 当前库存金额数据（从高到低排序）
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable GetJSKCDT()
        {
            return dal.GetJSKCDT();
        }


        /// <summary>
        /// 本年度每月成交客户数
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable GetYearSaleDT()
        {
            return dal.GetYearSaleDT();
        }

        /// <summary>
        /// //农机类型销售占比（从高到低排序）
        /// </summary>
        /// <returns></returns>
        public DataTable GetTypeSaleDT()
        {
            return dal.GetTypeSaleDT();
        }
        /// <summary>
        /// 品牌销量占比（从高到低排序）
        /// </summary>
        /// <returns></returns>
        public DataTable GetbrandSaleDT()
        {
            return dal.GetbrandSaleDT();
        }

        /// <summary>
        ///门店销量数据（从高到低排序））
        /// </summary>
        /// <returns></returns>
        public DataTable GetShopSaleDT()
        {
            return dal.GetShopSaleDT();
        }

        /// <summary>
        ///门店采购数据（从高到低排序）
        /// </summary>
        /// <returns></returns>
        public DataTable GetShopInDT()
        {
            return dal.GetShopInDT();
        }

        /// <summary>
        ///过去12个月内集团销售金额
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable Get12MonthSaleDT()
        {
            return dal.Get12MonthSaleDT();
        }

        /// <summary>
        ///本年，本月，昨天，今天
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable GetYearMonthLastDaySaleDT()
        {
            return dal.GetYearMonthLastDaySaleDT();
        }


        #region Oracle 时间 ： 2018年7月30日


        public DataTable GetSF_DEPMENT()
        {
            return dal.GetSF_DEPMENT();
        }

        public DataTable Getsf_item()
        {
            return dal.Getsf_item();
        }

        public DataTable Getsf_item_type()
        {
            return dal.Getsf_item_type();
        }


        public DataTable Getsf_customer()
        {
            return dal.Getsf_customer();
        }


        public DataTable Getsf_supplier()
        {
            return dal.Getsf_supplier();
        }


        public DataTable Getsf_purorder()
        {
            return dal.Getsf_purorder();
        }


        public DataTable Getsf_saleissuebill()
        {
            return dal.Getsf_saleissuebill();
        }

        public DataTable Getsf_purinwarehsbill()
        {
            return dal.Getsf_purinwarehsbill();
        }

        public DataTable Getsf_otherissuebill()
        {
            return dal.Getsf_otherissuebill();
        }

        public DataTable Getsf_otherinwarehsbill()
        {
            return dal.Getsf_otherinwarehsbill();
        }

        public DataTable Getsf_moveinwarehsbill()
        {
            return dal.Getsf_moveinwarehsbill();
        }




        #endregion
    }
}