using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Infrastructure.Middlewares
{
    //public static class HttpLoggerMiddlewareExtensions
    //{
    //    public static IApplicationBuilder UseHttpLogging(this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<HttpLoggerMiddleware>();
    //    }
    //}
    //public class HttpLoggerMiddleware
    //{
    //    private readonly RequestDelegate next;
    //    private static readonly Logger logger = LogManager.GetLogger(typeof(HttpLoggerMiddleware).Assembly.FullName);

    //    public HttpLoggerMiddleware(RequestDelegate next)
    //    {
    //        this.next = next;
    //    }

    //    public Task Invoke(HttpContext context)
    //    {
    //        logger.Log(new NLog.LogEventInfo(NLog.LogLevel.Info, logger.Name, $"Start request: {context.Request.Method} {context.Request.Path.ToString()}"));

    //        var startTime = DateTime.Now;
    //        return next(context).ContinueWith(task => {

    //            var beginRequestEvent = new NLog.LogEventInfo(NLog.LogLevel.Info, logger.Name, $"End request: {context.Request.Method} {context.Request.Path.ToString()}");
    //            beginRequestEvent.Properties.Add("appdata_start_time", startTime.ToString("yyyy-MM-dd HH:mm:ss.fffff"));
    //            beginRequestEvent.Properties.Add("appdata_status", context.Response.StatusCode);
    //            beginRequestEvent.Properties.Add("appdata_timetaken", (DateTime.Now - startTime).TotalMilliseconds);

    //            logger.Log(beginRequestEvent);
    //        });
    //    }
    //}
}
