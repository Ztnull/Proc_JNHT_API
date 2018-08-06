using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: api/Default
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Default/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        public void test()
        {
            int a = 3;
            testLambda((a1,b) => { return a1+b; }, 1,1);
            Func<int, int, string> getFunc = (p1, p2) =>
            {
                return p1 + "    " + p2;
            };
            getFunc.Invoke(1, 1);
        }

        
        private void testLambda<T>(Func<int,int,T> func, int a,int b)
        {
            var def = default(T);
            func.Invoke(a,b);
        }

    }
}
