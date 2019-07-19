using Admin.Common;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace vue_admin_webapi.Helper
{
    public class WebApiExceptionFilterAttribute : IExceptionFilter, IAsyncExceptionFilter, IFilterMetadata
    {
        public void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled == false)
            {
                string msg = context.Exception.Message;

                WebApiMonitorLog monitorLog = new WebApiMonitorLog();
                monitorLog.Path = context.HttpContext.Request.Path;
                monitorLog.HttpMethod = context.HttpContext.Request.Method;
                monitorLog.IP = DBCenter.GetIP(context.HttpContext);
                monitorLog.HttpRequestHeaders = context.HttpContext.Request.Headers.ToString();
                context.HttpContext.Request.Body.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(context.HttpContext.Request.Body))
                {
                    monitorLog.ActionParams = reader.ReadToEnd();
                }

                LoggerHelper.Error(monitorLog.GetLoginfo());
                context.Result = new JsonResult(new { Code = -3, Message=msg }) { StatusCode = 200 };
            }
            context.ExceptionHandled = true;
        }

        public Task OnExceptionAsync(ExceptionContext context)
        {
            OnException(context);
            return Task.CompletedTask;
        }
    }
}
