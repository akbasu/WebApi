using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApp.Filters
{
    public class DemoFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            bool demoMode;
            bool.TryParse(ConfigurationManager.AppSettings["DemoMode"], out demoMode);

            if (!demoMode)
            {
                base.OnActionExecuting(actionContext);
                return;
            }

            Debug.WriteLine("HTTP Method :" + actionContext.Request.Method.Method);

            if (actionContext.Request.Method != HttpMethod.Get)
            {
                var appResponse = new AppResponse
                {
                    Error = new AppError()
                    {
                        Code = ApplicationErrors.InvalidDemoOperation,
                        Message = Resources.ResourceManager.GetString("InvalidDemoOperationMessage")
                    }
                };
                actionContext.Response = actionContext.Request.CreateResponse(
                    HttpStatusCode.Accepted,
                    appResponse,
                    actionContext.ControllerContext.Configuration.Formatters.JsonFormatter);
            }

            base.OnActionExecuting(actionContext);
        }
    }

    public class AppResponse
    {
        public AppError  Error { get; set; }
    }

    public class AppError
    {
        public ApplicationErrors Code { get; set; }
        public string Message { get; set; }
    }

    public enum ApplicationErrors
    {
        InvalidDemoOperation = 1001
    };
}