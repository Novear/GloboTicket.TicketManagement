using Microsoft.AspNetCore.Builder;

namespace GloboTicket.TicketManagement.Api.Middleware
{
    public static class MiddlewareExtensions
    {
        // here we are invoking the middleware into the request pipeline
        // IApplicationBuilder give access to the middleware pipeline.
        // and in the Startup class app.UseCustomExceptionHandler
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder) 
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
