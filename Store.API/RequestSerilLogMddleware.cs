using Serilog.Context;

namespace Store.API
{
    public class RequestSerilogMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestSerilogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            using (LogContext.PushProperty("UserName", context?.User?.Identity?.Name ?? "anônimo"))
            {
                return _next.Invoke(context);
            }
        }
    }
}
