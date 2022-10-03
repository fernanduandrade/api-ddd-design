using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Filters;

namespace Store.API
{
    public static class SerilogExtension
    {
        public static void AddSerilogExtension(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
               .Enrich.FromLogContext()
               .Enrich.WithExceptionDetails()
               .Enrich.WithCorrelationId()
               .Enrich.WithProperty("ApplicationName", $"API Serilog - {Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}")
               .Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore.StaticFiles"))
               .Filter.ByExcluding(z => z.MessageTemplate.Text.Contains("Business error"))
               .WriteTo.Async(wt => wt.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}"))
               .WriteTo.File(
                    Path.Combine($"C:\\Projetos\\StoreApi\\Log\\log-.txt"),
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
                )
               .CreateLogger();
        }
    }
}
