using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.IO;
using System.Collections;
using System.Diagnostics;
using Oracle.ManagedDataAccess.Types;
using System.Net.Sockets;

namespace DBHelp
{
    public class OracleHelper
    {
        private static string connStr = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=182.140.132.139)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));User Id=system;Password=admin";
        private static string connStr1 = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=182.140.132.138)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));User Id=system;Password=admin";




        #region 测试数据库服务器连接 +static bool TestConnection(string host, int port, int millisecondsTimeout)
        /// <summary> 
        /// 采用Socket方式，测试数据库服务器连接 
        /// </summary> 
        /// <param name="host">服务器主机名或IP</param> 
        /// <param name="port">端口号</param> 
        /// <param name="millisecondsTimeout">等待时间：毫秒</param> 
        /// <exception cref="Exception">链接异常</exception>
        /// <returns></returns> 
        public static bool TestConnection(string host, int port, int millisecondsTimeout)
        {
            using (var client = new TcpClient())
            {
                try
                {
                    var ar = client.BeginConnect(host, port, null, null);
                    ar.AsyncWaitHandle.WaitOne(millisecondsTimeout);
                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        #endregion


        #region 执行SQL语句,返回受影响行数
        public static int ExecuteNonQuery(string sql, params OracleParameter[] parameters)
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();
                using (OracleCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);
                    try
                    {
                        return cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        return 0;
                    }
                }
            }

        }

        public static int ExecuteNonQuery1(string sql, params OracleParameter[] parameters)
        {
            using (OracleConnection conn = new OracleConnection(connStr1))
            {
                conn.Open();
                using (OracleCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);
                    try
                    {
                        return cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                        return 0;
                    }
                }
            }

        }
        #endregion


        #region 执行SQL语句,返回DataTable;只用来执行查询结果比较少的情况

        public static DataTable ExecuteDataTable(string sql, params OracleParameter[] parameters)
        {
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                try
                {
                    conn.Open();
                    using (OracleCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.Parameters.AddRange(parameters);
                        OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                        DataTable datatable = new DataTable();
                        adapter.Fill(datatable);
                        return datatable;
                    }
                }
                catch (Exception ex)
                {
                    return ExecuteDataTableEx(sql, parameters);
                }

            }

        }


        /// <summary>
        /// 备用
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTableEx(string sql, params OracleParameter[] parameters)
        {
            using (OracleConnection conn = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=182.140.132.138)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));User Id=system;Password=admin"))
            {
                try
                {
                    conn.Open();
                    using (OracleCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.Parameters.AddRange(parameters);
                        OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                        DataTable datatable = new DataTable();
                        adapter.Fill(datatable);
                        return datatable;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }

            }
            #endregion
        }
    }
}