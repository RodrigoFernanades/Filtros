using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filtros.Filters
{
    public class ElapsedTimeAttribute : ActionFilterAttribute
    {
        private Stopwatch duration;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.duration = Stopwatch.StartNew();
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            this.duration.Stop();
            string info = string.Format("Duração total: {0} ms", duration.ElapsedMilliseconds);
            filterContext.HttpContext.Response.Write(info);
        }
    }
}