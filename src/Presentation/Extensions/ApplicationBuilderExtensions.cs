using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using MsServiceApp.Domain;

namespace MsServiceApp
{
    [ExcludeFromCodeCoverage]
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            _ = app.UseExceptionHandler(appError => appError.Run(async context =>
            {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                if (contextFeature != null)
                {
                    var statusCode = contextFeature.Error switch
                    {
                        ValidationException ex => HttpStatusCode.BadRequest,
                        MsServiceException ex => HttpStatusCode.BadRequest,
                        _ => HttpStatusCode.InternalServerError
                    };

                    var apiError = new ApiError(contextFeature.Error.Message, contextFeature.Error.InnerException?.Message, contextFeature.Error.StackTrace);

                    context.Response.StatusCode = (int)statusCode;
                    context.Response.ContentType = "application/json";


                    await context.Response.WriteAsync(JsonSerializer.Serialize(apiError));
                }
            }));

            return app;
        }
    }
}