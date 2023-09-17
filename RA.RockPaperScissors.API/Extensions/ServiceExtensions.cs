using RA.RockPaperScissors.Domain.Entities.LeaderboardAggregate;
using RA.RockPaperScissors.Domain.Entities.PlayerAggregate;
using RA.RockPaperScissors.Domain.Interfaces;
using RA.RockPaperScissors.Domain.Services;
using RA.RockPaperScissors.Infrastructure.Repositories;

namespace RA.RockPaperScissors.API.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration, bool isDevEnvironment)
    {
        // Add HttpContextAccessor
        services.AddHttpContextAccessor();

        // Domain Services
        services.AddTransient<IPlayerDomainService, PlayerDomainService>();
        services.AddTransient<ILeaderboardControllerDomainService, LeaderboardControllerDomainService>();

        // Repositories
        services.AddTransient<IPlayerRepository, PlayerRepository>();
        services.AddTransient<ILeaderboardRepository, LeaderboardRepository>();

        return services;
    }
}