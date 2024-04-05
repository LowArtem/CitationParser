using System.Reflection;
using AutoMapper;
using CitationParser.Api.Extensions.Application;
using CitationParser.Api.Mappers;
using CitationParser.Data.Context;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Serilog;
using Hangfire;
using Hangfire.MySql;
using CitationParser.Api.Services;
using CitationParser.Data.Services.WebScraper;

var builder = WebApplication.CreateBuilder();

builder.Services.AddBaseModuleDi("DefaultConnection", builder.Configuration);

// Auto Mapper Configurations
var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });

var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddTransient<CitationParser.Data.Services.Parser.CitationParser>();
builder.Services.AddTransient<WebScraperService>();
builder.Services.AddTransient<ParseHtmlService>();
builder.Services.AddHostedService<TimeHostedService>();

#region Hangfire

// Add Hangfire services
builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseStorage(new MySqlStorage(builder.Configuration.GetConnectionString("HangfireConnection"),
        new MySqlStorageOptions
        {
            PrepareSchemaIfNecessary = true,
            TablesPrefix = "hangfire_"
        }))
);

// Add the processing server as IHostedService
builder.Services.AddHangfireServer();

#endregion

builder.Host.UseSerilog((ctx, lc) =>lc
    .WriteTo.Console()
    .ReadFrom.Configuration(ctx.Configuration));

var app = builder.Build();

app.MigrateDatabase(app.Logger);

app.UseBaseServices(app.Environment, app.Services.GetRequiredService<IApiVersionDescriptionProvider>());

app.UseSerilogRequestLogging();

app.Run();