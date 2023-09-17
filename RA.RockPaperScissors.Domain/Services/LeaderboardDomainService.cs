using RA.RockPaperScissors.Domain.Interfaces;
using RA.RockPaperScissors.Domain.Entities.LeaderboardAggregate;

namespace RA.RockPaperScissors.Domain.Services;

public class LeaderboardDomainService : ILeaderboardDomainService
{
    private readonly ILeaderboardRepository _leaderboardRepository;

    public LeaderboardDomainService(ILeaderboardRepository leaderboardRepository)
    {
        _leaderboardRepository = leaderboardRepository;
    }

    public Leaderboard? GetLeaderboard()
    {
        return _leaderboardRepository.GetLeaderboard();
    }

    public void SetLeaderboard(Leaderboard leaderboard)
    {
        _leaderboardRepository.SetLeaderboard(leaderboard);
    }
}