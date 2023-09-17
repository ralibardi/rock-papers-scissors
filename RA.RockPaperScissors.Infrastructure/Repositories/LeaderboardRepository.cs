using Microsoft.Extensions.Caching.Memory;
using RA.RockPaperScissors.Domain.Entities.LeaderboardAggregate;

namespace RA.RockPaperScissors.Infrastructure.Repositories;

public class LeaderboardRepository : ILeaderboardRepository
{
    private readonly IMemoryCache _memoryCache;

    public LeaderboardRepository(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public Leaderboard? GetLeaderboard()
    {
        if (_memoryCache.TryGetValue("leaderboard", out Leaderboard leaderboard))
        {
            return leaderboard;
        }

        return null;
    }

    public void SetLeaderboard(Leaderboard leaderboard)
    {
        _memoryCache.Set("leaderboard", leaderboard, new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        });
    }
}