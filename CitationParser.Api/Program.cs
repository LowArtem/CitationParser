using System.Reflection;
using AutoMapper;
using CitationParser.Api.Extensions.Application;
using CitationParser.Api.Mappers;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Serilog;

var builder = WebApplication.CreateBuilder();

builder.Services.AddBaseModuleDi("DefaultConnection", builder.Configuration);

// Auto Mapper Configurations
var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });

var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Host.UseSerilog((ctx, lc) =>lc
    .WriteTo.Console()
    .ReadFrom.Configuration(ctx.Configuration));

var app = builder.Build();

app.MigrateDatabase(app.Logger);

app.UseBaseServices(app.Environment, app.Services.GetRequiredService<IApiVersionDescriptionProvider>());

app.UseSerilogRequestLogging();