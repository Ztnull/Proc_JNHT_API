using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class SqlExtentHelper
    {


        public static T Excute<T>(string sql, Func<SqlCommand, T> func)
        {
            using (SqlConnection conn = new SqlConnection(DBHelp.DBHelper.Connection))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sql, conn);
                    T t = func(sqlCommand);
                    return t;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            }
        }
    }
}
