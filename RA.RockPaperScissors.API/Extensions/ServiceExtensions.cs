using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RA.RockPaperScissors.API.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration, bool isDevEnvironment)
    {
        // Add HttpContextAccessor
        services.AddHttpContextAccessor();

        // Domain Services

        // Strategies

        // Integration Services

        // Repositories


        return services;
    }
}