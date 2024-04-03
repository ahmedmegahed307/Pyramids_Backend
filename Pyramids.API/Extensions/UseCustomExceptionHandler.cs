using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using Serilog;

namespace Pyramids.API.Extensions
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            //app.UseExceptionHandler(config =>
            //{
            //    config.Run(async context =>
            //    {
            //        context.Response.StatusCode = 500;

            //        context.Response.ContentType = "application/json";
            //        var error = context.Features.Get<IExceptionHandlerFeature>();
            //        if (error != null)
            //        {
            //            var ex = error.Error;

            //            ErrorDto errorDto = new()
            //            {
            //                Status = 500
            //            };

            //            errorDto.Errors.Add(ex.Message);

            //            Log.Error("Request: {Method} {Path} {Request} {RequestBody} {StatusCode}",
            //              context.Request.Method,
            //              context.Request.Path,
            //              context.Request,
            //              context.Request.Body,
            //              context.Response.StatusCode
            //            );

            //            Log.Error(ex, ex.Message);

            //            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDto));
            //        }
            //    });
            //});
        }
    }
}
