using Microsoft.AspNetCore.Http;
using my_books.Data.viewmodel;
using System;
using System.Net;
using System.Threading.Tasks;

namespace my_books.Exceptoon
{
    public class CustomExptionMidlware
    {
        public readonly RequestDelegate _next;

        public CustomExptionMidlware(RequestDelegate next)
        {
            _next=next;
        }
        public async Task InVokeAsynv(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);   
            }
            catch(Exception ex)
            {
                await handelExptionasync(httpContext,ex) ;
            }
        }

        private Task handelExptionasync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";

            var response = new ErrorVm()
            {
                StatusCode= httpContext.Response.StatusCode,
                Message="Internal server Error From the Custom ",
                Path="path-goes-here"
            };
            return httpContext.Response.WriteAsync(response.ToString());    
        }
    }
}
