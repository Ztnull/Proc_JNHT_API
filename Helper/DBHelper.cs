using System;


namespace DBHelp
{
    /// <summary>
    /// 连接数据库层
    /// </summary>
    public static class DBHelper
    {
        public static string  Connection
        {
            get
            {
                string StrIP;
                string StrUID;
                string Strpwd;
                string StrDataBase;

                StrIP = "39.108.65.247";
                StrUID = "sa";
                Strpwd = "sfkj123!1";
                StrDataBase = "SF_EAS_ERP";   
            
               return "server=" + StrIP + ";uid=" + StrUID + ";pwd=" + Strpwd + ";database=" + StrDataBase + "";
               Console.WriteLine(Strpwd);
            }
        }
    }
}
