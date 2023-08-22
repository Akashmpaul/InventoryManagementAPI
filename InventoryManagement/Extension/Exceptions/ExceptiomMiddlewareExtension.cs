using InventoryManagement.DTOs.Error;
using InventoryManagement.Extension.Logger;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;


namespace InventoryManagement.Extension.Exceptions
{
    public static class ExceptiomMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this WebApplication app, ILoggerManager logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var exception = contextFeature.Error;
                        context.Response.StatusCode = exception switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            BadRequestException => StatusCodes.Status400BadRequest,
                            _ => StatusCodes.Status500InternalServerError
                        };
                        logger.LogError($"Something went wrong: {exception}");
                        // setting complete error message
                        var errorMessage = contextFeature.Error.Message;
                        while (exception.InnerException != null)
                        {
                            exception = exception.InnerException;
                        }
                        await context.Response.WriteAsync(
                            JsonSerializer.Serialize(
                                new ErrorDetails()
                                {
                                    StatusCode = context.Response.StatusCode,
                                    Message = exception.Message
                                }));
                    }
                });
            });
        }
    }
}
