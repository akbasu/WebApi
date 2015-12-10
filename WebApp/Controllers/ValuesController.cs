using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
        public async Task<IHttpActionResult> Get()
        {
            var strings = new List<string> { "value1", "value2" };
            return  await Task.Run(() => Ok(strings));
        }

        // GET api/values/5
        [HttpGet]
        [Route("api/values/{id}", Name = "GetValueById")]
        public async Task<IHttpActionResult> Get(int id)
        {
            return await Task.Run(() => Ok("value"));
        }

        // POST api/values
        public async Task<IHttpActionResult> Post([FromBody]string value)
        {
            Debug.WriteLine("value: " + value);
            return await Task.Run(() => CreatedAtRoute("GetValueById", new { id = 1 }, value));
        }

        // PUT api/values/5
        [HttpPut]
        [Route("api/values/{id}", Name = "PutValueById")]
        public async Task<IHttpActionResult> Put(int id, [FromBody]string value)
        {
            return await Task.Run(() => Ok());
            //return await Task.Run(() => BadRequest());
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("api/values/{id}", Name = "DeleteValueById")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            return await Task.Run(() => Ok());
        }
    }
}
