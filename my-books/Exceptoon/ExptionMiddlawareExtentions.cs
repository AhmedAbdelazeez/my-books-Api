using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using my_books.Data.viewmodel;
using System.Net;

namespace my_books.Exceptoon
{
    public static class ExptionMiddlawareExtentions
    {
        public static void ConfigureeBuildTnExptionHander(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(apperror =>
            {
                apperror.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType ="application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var ContextRequesr=context.Features.Get<IHttpRequestFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorVm
                        {
                            StatusCode =context.Response.StatusCode,
                            Message=contextFeature.Error.Message,
                            Path=ContextRequesr.Path
                        }.ToString());
                    }
                });
            });
        }

        public static void CongigureCustomExptionHandeler(this IApplicationBuilder app)
        {
            app.UseMiddleware < CustomExptionMidlware>();
        }
    }
}
