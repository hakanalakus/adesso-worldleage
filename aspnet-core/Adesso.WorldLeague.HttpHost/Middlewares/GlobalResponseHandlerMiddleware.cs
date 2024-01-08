using Adesso.WorldLeague.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Adesso.WorldLeague.Middlewares
{
    public class GlobalResponseHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalResponseHandlerMiddleware> _logger;
        public GlobalResponseHandlerMiddleware(ILogger<GlobalResponseHandlerMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e, e.Message);
                context.Response.ContentType = "application/json";

                if (e is UserFriendlyException)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    await context.Response.WriteAsJsonAsync(Result.Fail(e.Message));
                    return;
                }
                else if (e is BadHttpRequestException)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    var msg = e.InnerException.Message;
                    if (e.InnerException != null && e.InnerException is JsonException)
                        msg = e.InnerException.Message;
                    else
                        msg = e.Message;

                    await context.Response.WriteAsJsonAsync(Result.Fail(msg));
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    await context.Response.WriteAsJsonAsync(Result.Fail(e.Message));
                }
            }
        }
    }

    public class Result<T> : Result where T : class, new()
    {
        public T Payload { get; set; }

        public static Result<T> Success(T payload)
        {
            return new Result<T> { IsSuccess = true, Payload = payload };
        }
    }

    public class Result
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }

        public static Result Fail(string message)
        {
            return new Result { IsSuccess = false, ErrorMessage = message };
        }

        public static Result Success()
        {
            return new Result { IsSuccess = true };
        }
    }
}
