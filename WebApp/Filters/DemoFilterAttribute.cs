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
                actionContext.Response = actionContext.Request.CreateResponse(
                    HttpStatusCode.Forbidden,
                    new
                    {
                        errorCode = ApplicationErrors.InvalidDemoOperation, // Application error codes to help the UI workflow
                        errorMessage = Resources.ResourceManager.GetString("InvalidDemoOperationMessage")
                    },
                    actionContext.ControllerContext.Configuration.Formatters.JsonFormatter);
            }

            base.OnActionExecuting(actionContext);
        }
    }

    public enum ApplicationErrors
    {
        InvalidDemoOperation = 1001
    };
}