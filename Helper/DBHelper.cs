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

                StrIP = ".";
                StrUID = "sa";
                Strpwd = "123";
                StrDataBase = "YDDCRMOA";   
            
               return "server=" + StrIP + ";uid=" + StrUID + ";pwd=" + Strpwd + ";database=" + StrDataBase + "";
               Console.WriteLine(Strpwd);
            }
        }
    }
}
