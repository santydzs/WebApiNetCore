using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Log.DbModels;

namespace WebApi.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            Logs log = new Logs();
            log.Controller = context.HttpContext.Request.Path.ToString();
            log.Mensaje = context.Exception.Message;
            Log.Gestor.GestorLogs.Log(log);
        }
    }
}
