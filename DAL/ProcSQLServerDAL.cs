using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DBHelp;
using System.Data.SqlClient;

namespace DAL
{
    public class ProcSQLServerDAL
    {
        public ProcSQLServerDAL()
        { }
        public string Str = "";


        #region  成员方法


         

        /// <summary>
        /// 查询当前缺货的门店及对应缺货的名目
        /// </summary>
        /// <returns></returns>
        public DataTable GetCurrOOSStoreNameDT()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from e_view_shopGoodsName");
            return DBHelp.OracleHelper.ExecuteDataTable(builder.ToString());

        }


        /// <summary>
        /// 省份名称和客户数量 
        /// </summary>
        /// <returns></returns>
        public DataTable GetProvinceCustomerSumDT()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from e_view_ProvinceCustMer order by fqty desc");
            return DBHelp.OracleHelper.ExecuteDataTable(builder.ToString());

        }

        /// <summary>
        /// 增加当天新订单
        /// </summary>
        /// <returns></returns>
        public DataTable GetTodayNewOrderDT()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from  e_view_DaySale");
            return DBHelp.OracleHelper.ExecuteDataTable(builder.ToString());

        }


        /// <summary>
        /// 门店
        /// </summary>
        /// <returns></returns>
        public DataTable GetStoreDT()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  substr(fname,1,2) as FCity,FName from  sf_t_dep");
            return DBHelp.OracleHelper.ExecuteDataTable(builder.ToString());

        }


        /// <summary>
        /// 当前库存金额数据（从高到低排序）
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable GetJSKCDT()
        {
            Str = "";
            Str = "select FShopName,round(FAmount,2) as FAmount ,remark,fcity from E_view_JSKC  order by  to_number(FAmount)  desc";
            return DBHelp.OracleHelper.ExecuteDataTable(Str);

        }

        /// <summary>
        /// 本年度每月成交客户数
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable GetYearSaleDT()
        {
            Str = "";
            Str = "select FMonth,FQTY from E_view_YearSale order by FMonth  desc";
            return DBHelp.OracleHelper.ExecuteDataTable(Str);
        }
        /// <summary>
        /// //农机类型销售占比（从高到低排序）
        /// </summary>
        /// <returns></returns>
        public DataTable GetTypeSaleDT()
        {
            Str = "";
            Str = "select FTypeName,round(FAmount,2) as FAmount from E_view_TypeSale order by  to_number(FAmount)  desc";
            return DBHelp.OracleHelper.ExecuteDataTable(Str);
        }
        /// <summary>
        /// 品牌销量占比（从高到低排序）
        /// </summary>
        /// <returns></returns>
        public DataTable GetbrandSaleDT()
        {
            Str = "";
            Str = "select FbrandName,round(FAmount,2) as FAmount  from E_view_brandSale order by  to_number(FAmount)  desc ";
            return DBHelp.OracleHelper.ExecuteDataTable(Str);
        }


        /// <summary>
        ///门店销量数据（从高到低排序）
        /// </summary>
        /// <returns></returns>
        public DataTable GetShopSaleDT()
        {
            Str = "";
            Str = "select FShopName,round(FAmount,2) as FAmount  from E_view_ShopSale order by  to_number(FAmount)  desc";
            return DBHelp.OracleHelper.ExecuteDataTable(Str);
        }


        /// <summary>
        ///门店采购数据（从高到低排序）
        /// </summary>
        /// <returns></returns>
        public DataTable GetShopInDT()
        {
            Str = "";
            Str = "select FShopName,round(FAmount,2) as FAmount  from E_view_ShopIn order by  to_number(FAmount)  desc";
            return DBHelp.OracleHelper.ExecuteDataTable(Str);
        }


        /// <summary>
        ///过去12个月内集团销售金额
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable Get12MonthSaleDT()
        {
            Str = "";
            Str = " select FMonth,round(FAmount,2) as FAmount , round(FHBAmount,2)  as FHBAmount  from E_view_12MonthSaleDT order by  to_number(FAmount)  desc ";
            return DBHelp.OracleHelper.ExecuteDataTable(Str);
        }

        /// <summary>
        ///本年，本月，昨天，今天
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable GetYearMonthLastDaySaleDT()
        {
            Str = "";
            Str = "select FYear, FMonth, FlastDay,FDAY from E_view_YearMonthLastDay ";
            return DBHelp.OracleHelper.ExecuteDataTable(Str);
        }
        #endregion


        #region Oracle 时间 ：2018年7月30日 

        public DataTable GetSF_DEPMENT()
        {
            return DBHelp.OracleHelper.ExecuteDataTable(@" SELECT  fid, 
 fnumber,
 fname_l2,
 fisstart FROM SF_DEPMENT ");
        }


        public DataTable Getsf_item()
        {
            return DBHelp.OracleHelper.ExecuteDataTable(@"  SELECT fid, 
fnumber, 
fname_l2, 
fname_l3, 
fmodel, 
fmaterialgroupid, 
fstatus FROM sf_item ");
        }

        public DataTable Getsf_item_type()
        {
            return DBHelp.OracleHelper.ExecuteDataTable(@" Select fid, 
fnumber, 
fname_l2, 
fparentid, 
flevel from sf_item_type ");
        }
        public DataTable Getsf_customer()
        {
            return DBHelp.OracleHelper.ExecuteDataTable(@"  select fid, 
      fnumber, 
      fname_l2, 
      fname_l3 from sf_customer ");
        }


        public DataTable Getsf_supplier()
        {
            return DBHelp.OracleHelper.ExecuteDataTable(@" SELECT fid, 
 fnumber, 
 fname_l2, 
 fname_l3 FROM sf_supplier ");
        }


        public DataTable Getsf_purorder()
        {
            return DBHelp.OracleHelper.ExecuteDataTable(@"  SELECT fcreatetime, 
fyear, 
fperiod, 
fnumber, 
fstorageorgunitid, 
fmaterialid, 
funitid, 
fbaseunitid, 
ftaxprice, 
fsupplierid, 
fqty, 
fprice, 
famount FROM sf_purorder ");
        }

        public DataTable Getsf_saleissuebill()
        {
            return DBHelp.OracleHelper.ExecuteDataTable(@"  SELECT fcreatetime, 
 fyear, 
 fperiod, 
 fnumber, 
 fstorageorgunitid, 
 fmaterialid, 
 funitid, 
 fbaseunitid, 
 fqty, 
 fprice, 
 famount FROM sf_saleissuebill ");
        }

        public DataTable Getsf_purinwarehsbill()
        {
            return DBHelp.OracleHelper.ExecuteDataTable(@"  SELECT fcreatetime, 
 fyear, 
 fperiod, 
 fnumber, 
 fstorageorgunitid, 
 fmaterialid, 
 funitid, 
 fbaseunitid, 
 ftaxprice, 
 fsupplierid, 
 fday, 
 fqty, 
 fprice, 
 famount FROM sf_purinwarehsbill ");
        }


        public DataTable Getsf_otherissuebill()
        {
            return DBHelp.OracleHelper.ExecuteDataTable(@"  SELECT  fcreatetime, 
 fyear, 
 fperiod, 
 fnumber, 
 fstorageorgunitid, 
 fmaterialid, 
 funitid, 
 fbaseunitid, 
 fqty, 
 fprice, 
 famount FROM sf_otherissuebill ");
        }


        public DataTable Getsf_otherinwarehsbill()
        {
            return DBHelp.OracleHelper.ExecuteDataTable(@"  SELECT fcreatetime, 
fyear, 
fperiod, 
fnumber, 
fstorageorgunitid, 
fmaterialid, 
funitid, 
fbaseunitid, 
fqty, 
fprice, 
famount FROM sf_otherinwarehsbill ");
        }


        public DataTable Getsf_moveinwarehsbill()
        {
            return DBHelp.OracleHelper.ExecuteDataTable(@"  SELECT fcreatetime, 
fyear, 
fperiod, 
fnumber, 
fstorageorgunitid, 
fmaterialid, 
funitid, 
fbaseunitid, 
fqty FROM sf_moveinwarehsbill ");
        }

        #endregion

    }
}
