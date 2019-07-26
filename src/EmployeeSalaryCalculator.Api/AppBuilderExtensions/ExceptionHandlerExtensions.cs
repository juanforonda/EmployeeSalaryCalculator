using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EmployeeSalaryCalculator.Api.AppBuilderExtensions
{
    public static class ExceptionHandlerExtensions
    {
        public static IApplicationBuilder UseApiGlobalExceptionHandler(this IApplicationBuilder appBuilder)
        {
            var loggerFactory = appBuilder.ApplicationServices.GetService(typeof(ILoggerFactory)) as ILoggerFactory;
            return appBuilder.UseExceptionHandler(HandleApiException(loggerFactory));
        }

        private static Action<IApplicationBuilder> HandleApiException(ILoggerFactory loggerFactory)
        {
            return appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var guidException = Guid.NewGuid().ToString();
                    if (exceptionHandlerFeature != null)
                    {
                        var logger = loggerFactory.CreateLogger("Global exception logger");
                        logger.LogError(guidException,
                            exceptionHandlerFeature.Error, exceptionHandlerFeature.Error.Message);
                    }
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";
                    var errorModel = new ProblemDetails()
                    {
                        Status = StatusCodes.Status500InternalServerError,
                        Title = "SYSTEM ERROR HAS OCCURRED",
                        Detail = $"Trace id: {guidException}"
                    };
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(errorModel));
                });
            };
        }
    }
}
