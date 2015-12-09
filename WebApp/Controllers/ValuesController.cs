using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApp.Filters;

namespace WebApp.Controllers
{
    /*[DemoFilter]*/
    /*[Authorize]*/
    [EnableCors(origins: "http://run.plnkr.co", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        // GET api/values
        /*[DemoFilter]*/
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            Debug.WriteLine("value: " + value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
