using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
        public HttpResponseMessage Get()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, new[] { "value1", "value2" });
            return response;
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, "value");
            response.Content = new StringContent("hello", Encoding.Unicode);
            return response;
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]string value)
        {
            Debug.WriteLine("value: " + value);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            return response;
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}
