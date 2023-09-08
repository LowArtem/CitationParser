using CitationParser.Api.Extensions.Application;
using CitationParser.Api.Mappers;
using AutoMapper;
using Hangfire;
using Hangfire.MySql;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Serilog;

namespace CitationParser.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddBaseModuleDi("DefaultConnection", Configuration);

        // Services can be added here
        // services.AddTransient(typeof(UserService), typeof(UserService));


        // Auto Mapper Configurations
        var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });

        var mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        #region Hangfire

        // Add Hangfire services
        services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseStorage(new MySqlStorage(Configuration.GetConnectionString("HangfireConnection"),
                new MySqlStorageOptions
                {
                    PrepareSchemaIfNecessary = true,
                    TablesPrefix = "hangfire_"
                }))
        );

        // Add the processing server as IHostedService
        services.AddHangfireServer();

        #endregion
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app,
        IApiVersionDescriptionProvider provider,
        IWebHostEnvironment env,
        ILogger<Startup> logger)
    {
        app.MigrateDatabase(logger);

        app.UseBaseServices(env, provider);

        app.UseSerilogRequestLogging();
    }
}