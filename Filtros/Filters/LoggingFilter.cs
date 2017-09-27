using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filtros.Filters
{
    public class LoggingFilter : IActionFilter
    {
        private static string filename = "RequisicoesInfo.log";
        private static string logFilePath;

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            SaveInfo(filterContext);
        }

        private void SaveInfo(ControllerContext context)
        {
            string info = String.Format("Usuário: {0}, IP: {1}, Data/Hora: {2}, Url: {3}",
                context.HttpContext.User.Identity.Name,
                context.HttpContext.Request.UserHostAddress,
                DateTime.Now,
                context.HttpContext.Request.RawUrl);

            var path = GetLogFilePath(context);

            using(var logWriter = new StreamWriter(path, true))
            {
                logWriter.WriteLine(info);
            }
        }

        private static string GetLogFilePath(ControllerContext context)
        {
            if(LoggingFilter.logFilePath == null)
            {
                var logPath = context.HttpContext.Server.MapPath("~/Logs");
                if (!Directory.Exists(logPath))
                {
                    Directory.CreateDirectory(logPath);
                }
                var path = Path.Combine(logPath, filename);
                LoggingFilter.logFilePath = path;
            }
            return LoggingFilter.logFilePath;
        }
    }
}