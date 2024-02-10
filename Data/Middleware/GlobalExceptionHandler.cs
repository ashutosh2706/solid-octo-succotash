using System.Net;
using System.Text.Json;

namespace MyApi.Data.Middleware
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(RequestDelegate requestDelegate, ILogger<GlobalExceptionHandler> logger)
        {
            _next = requestDelegate;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception e)
            {
                _logger.LogError(e, e.StackTrace);
                var response = JsonSerializer.Serialize(new 
                { 
                    code = 500, 
                    Error = e.Message, 
                });
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(response);
            }
            
        }
    }
}