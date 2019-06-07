using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp1.Middlewares
{
    public class ErrorClass
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }

    /// 

    /// This is the Custom Middleware
    /// 
    public class GlobalErrorHandler
    {
        /// 

        /// We need to inject the "RequestDelegate" class.
        /// This will be used to process httprequest
        /// 
        RequestDelegate requestDelegate;
        public GlobalErrorHandler(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }
        /// 

        /// We need to add the InvokeAsync() method. 
        /// We need this method so that RequestDelegate can process the HttpRequest
        /// 
        /// 
        /// 
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await requestDelegate(httpContext);
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(httpContext, ex);
            }
        }

        /// 

        /// Method to handle Exceptions occures while Request processing
        /// 
        /// 
        /// 
        /// 
        public static Task HandleErrorAsync(HttpContext httpContext, Exception exception)
        {
            // send the status code based on the error occured
            httpContext.Response.StatusCode = 500;
            httpContext.Response.ContentType = "application/json";

            // Get the thrown error
            string errorMessage = exception.Message;

            // create the response
            string ResponseMessage = JsonConvert.SerializeObject(new ErrorClass()
            {
                ErrorCode = httpContext.Response.StatusCode,
                ErrorMessage = errorMessage
            });
            // get the response message
            return httpContext.Response.WriteAsync(ResponseMessage);
        }
    }
    /// 

    /// The class that register the Middleware
    /// 
    public static class CustomErrorExtensionsMiddleware
    {
        /// 

        /// The following method will use ErrorMiddleware class
        /// 
        /// 
        public static void CustomExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalErrorHandler>();
        }
    }
}
