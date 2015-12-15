using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApp.Controllers
{
    [EnableCors(origins: "http://run.plnkr.co", headers: "*", methods: "*")]
    public class DemoController : ApiController
    {
        public async Task<IHttpActionResult> Get()
        {
            bool demoMode;
            bool.TryParse(ConfigurationManager.AppSettings["DemoMode"], out demoMode);
            
            return await Task.Run(() => Ok(demoMode));
        }
    }
}
