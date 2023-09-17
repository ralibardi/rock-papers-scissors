using Mapster;
using Microsoft.AspNetCore.Mvc;
using RA.RockPaperScissors.API.Extensions;

namespace RA.RockPaperScissors.API.ApplicationStartup.Configuration;

public static class ServiceCollectionExtensions
{
    public static void ConfigureServices(
        this IServiceCollection services,
        IWebHostEnvironment environment,
        IConfiguration configuration)
    {
        services.AddMvc();

        services.AddControllersWithViews(options =>
        {
            if (!environment.IsDevelopment())
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            }
        });

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.WithOrigins("http://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        services
            .AddOptions()
            .AddDependencies(configuration, environment.IsDevelopment());

        // Mapper Registration
        TypeAdapterConfig.GlobalSettings.Apply(new MapsterConfigRegistration());

        // In production, the React files will be served from this directory
        services.AddSpaStaticFiles(configuration => configuration.RootPath = "ClientApp/build");
    }
}