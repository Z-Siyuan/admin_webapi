using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vue_admin_webapi.Helper
{
    public class APIResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
        }
        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is BadRequestObjectResult)
            {
                BadRequestObjectResult res = (BadRequestObjectResult)context.Result;
                SerializableError obj = res.Value as SerializableError;
                StringBuilder sb = new StringBuilder();
                foreach (var item in obj)
                {
                    var vals = item.Value as string[];
                    if (vals != null)
                    {
                        sb.AppendLine(vals[0]);
                    }
                }
                context.Result = new JsonResult(new { Code=-3, Message = sb.ToString() }) { StatusCode = 200 };
                return;
            }
        }
    }
}
