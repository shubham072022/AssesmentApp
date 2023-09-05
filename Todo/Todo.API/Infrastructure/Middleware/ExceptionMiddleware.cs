﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;
using Todo.Application.Common.Exceptions;
using Todo.Application.Common.Wrapper.Concrete;

namespace Todo.API.Infrastructure.Middleware
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        public Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message = "Internal Server Error";
            if (ex.InnerException is ApiException || ex.GetType() == typeof(ApiException))
            {
                var e = ex.InnerException != null ? (ApiException)ex.InnerException : (ApiException)ex;
                httpContext.Response.StatusCode = e.StatusCode;
                var apierror = JsonConvert.SerializeObject(new ErrorResponse(e.StatusCode, e.Errors), new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                return httpContext.Response.WriteAsync(apierror);
            }

            List<string> exceptions = new List<string>();

            if (ex.InnerException != null)
            {
                exceptions.Add(ex.InnerException.ToString());
                if (ex.InnerException.Message != null)
                {
                    exceptions.Add(ex.InnerException.Message);
                }
                else if (ex.InnerException.InnerException.Message != null)
                {
                    exceptions.Add(ex.InnerException.InnerException.Message);
                }
            }
            else if (ex.Message != null)
            {
                exceptions.Add(ex.Message);
            }
            var errorlogDetail = new
            {
                Errors = exceptions
            };
            var serializedError = JsonConvert.SerializeObject(errorlogDetail, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

            var error = JsonConvert.SerializeObject(new ErrorResponse(httpContext.Response.StatusCode, message), new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            return httpContext.Response.WriteAsync(error);
        }
    }
}
