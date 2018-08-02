using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHelp;

namespace UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var reslut = OracleHelper.ExecuteDataTable(" select * from SF_DEPMENT ");
            Console.WriteLine(reslut);
            Console.ReadKey();
        }
    }
}
