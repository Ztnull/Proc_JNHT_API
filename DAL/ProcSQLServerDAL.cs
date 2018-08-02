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
        /// 当前库存金额数据（从高到低排序）
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable GetJSKCDT()
        {
            Str = "";
            Str = "select FShopName,round(FAmount,28) as FAmount ,remark,fcity from E_view_JSKC  order by  to_char(FAmount,'fm9999990.99')  desc";
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
            Str = "select FTypeName,round(FAmount,28) as FAmount from E_view_TypeSale order by  to_char(FAmount,'fm9999990.99')  desc";
            return DBHelp.OracleHelper.ExecuteDataTable(Str);
        }
        /// <summary>
        /// 品牌销量占比（从高到低排序）
        /// </summary>
        /// <returns></returns>
        public DataTable GetbrandSaleDT()
        {
            Str = "";
            Str = "select FbrandName,round(FAmount,28) as FAmount  from E_view_brandSale order by  to_char(FAmount,'fm9999990.99')  desc ";
            return DBHelp.OracleHelper.ExecuteDataTable(Str);
        }


        /// <summary>
        ///门店销量数据（从高到低排序）
        /// </summary>
        /// <returns></returns>
        public DataTable GetShopSaleDT()
        {
            Str = "";
            Str = "select FShopName,round(FAmount,28) as FAmount  from E_view_ShopSale order by  to_char(FAmount,'fm9999990.99')  desc";
            return DBHelp.OracleHelper.ExecuteDataTable(Str);
        }


        /// <summary>
        ///门店采购数据（从高到低排序）
        /// </summary>
        /// <returns></returns>
        public DataTable GetShopInDT()
        {
            Str = "";
            Str = "select FShopName,round(FAmount,28) as FAmount  from E_view_ShopIn order by  to_char(FAmount,'fm9999990.99')  desc";
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
            Str = " select FMonth,round(FAmount,28) as FAmount , round(FHBAmount,28)  as FHBAmount  from E_view_12MonthSaleDT order by  to_char(FHBAmount,'fm9999990.99')  desc ";
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
