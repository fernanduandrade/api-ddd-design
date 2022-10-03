using Newtonsoft.Json;
using Store.Application.DTOs;
using System.Net;

namespace Store.API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                context.Request.EnableBuffering();
                var stream = context.Request.Body;
                stream.Seek(0, SeekOrigin.Begin);
                using var reader = new StreamReader(stream);
                var payloadString = await reader.ReadToEndAsync();
                Log.Information(payloadString);
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            ResponseDTO errorResponseVm;

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToLower() == "development" ||
                Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToLower() == "test")
            {
                errorResponseVm = new ResponseDTO
                {
                    Type = Domain.Enums.ResponseTypeEnum.Error,
                    Message = $"{exception.Message} {exception?.InnerException?.Message}"
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

            Log.Error($"Error: {exception.Message}");
            Log.Error($"Stack: {exception.StackTrace}");


            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            var result = JsonConvert.SerializeObject(errorResponseVm, jsonSettings);


            Log.Error(exception, "Error");

            var code = HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
