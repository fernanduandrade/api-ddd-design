using Newtonsoft.Json;
using Store.Application.DTOs;
using System.Net;

namespace Store.API.Middlewares
{
    public class MiddlewareError
    {
        private readonly RequestDelegate _next;
        private readonly Microsoft.Extensions.Logging.ILogger _log;

        public MiddlewareError(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _log = loggerFactory.CreateLogger("MiddlewareErrorLog");
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {

            ResponseDTO errorResponseVm;

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToLower() == "development" ||
                Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToLower() == "test")
            {
                errorResponseVm = new ResponseDTO
                {
                    Type = Domain.Enums.ResponseTypeEnum.Error,
                    Message = $"{ex.Message} {ex?.InnerException?.Message}"
                };
            }
            else
            {
                errorResponseVm = new ResponseDTO
                {
                    Type = Domain.Enums.ResponseTypeEnum.Error,
                    Message = "Ocorreu um erro interno do servidor"
                };
            }

            _log.LogError($"Error: {ex.Message}");
            _log.LogError($"Stack: {ex.StackTrace}");

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            var result = JsonConvert.SerializeObject(errorResponseVm, jsonSettings);
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}
