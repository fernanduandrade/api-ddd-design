using System.Text.Json.Serialization;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Store.Infra.CrossCutting.IOC;
using Store.Infra.Data;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Store.API;
using Store.API.Middlewares;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;
using System.Net.Mime;

try
{
    var builder = WebApplication.CreateBuilder(args);
    SerilogExtension.AddSerilogExtension(builder.Configuration);
    builder.Host.UseSerilog(Log.Logger);
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    // Add services to the container.
    builder.Services.AddDbContext<LocalContext>(options =>
    {
        var server = "localhost";
        var port = "5432";
        var database = "store";
        var username = "postgres";
        var password = "postgres";
        options.UseNpgsql($"Server={server};Port={port};Database={database};User Id={username};Password={password}", opt =>
        {
        }).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    });
    builder.Services.AddControllers();
    builder.Services.AddControllers()
        .AddJsonOptions(option =>
        {
            option.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddAuthentication(opt =>
    {
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKeys = new[] { new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])) }

                };
            });
    
    builder.Services.AddHealthChecks();

    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo() { Title = "Store", Version = "V1" });
    });
    builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new IocModule());
    });


    var app = builder.Build();
    // Configure the HTTP request pipeline.

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.UseMiddleware<RequestSerilogMiddleware>();
    app.UseMiddleware<ErrorHandlingMiddleware>();

    
    app.UseHealthChecks("/status", new HealthCheckOptions
    {
        ResultStatusCodes =
        {
            [HealthStatus.Healthy] = StatusCodes.Status200OK,
            [HealthStatus.Degraded] = StatusCodes.Status200OK,
            [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable,
        },
        ResponseWriter = async (context, report) =>
        {
            var result = JsonSerializer.Serialize(
                new
                {
                    currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    statusApplication = report.Status.ToString(),
                });

            context.Response.ContentType = MediaTypeNames.Application.Json;
            await context.Response.WriteAsync(result);
        }
    });

    app.MapHealthChecks("/status")
    .RequireAuthorization();

    app.Run();
    

}
catch (Exception ex)
{
    Log.Fatal(ex, "Aplicação finalizou inesperadamente");
}
finally
{
    Log.Information("Servidor desligando...");
    Log.CloseAndFlush();
}