using RA.RockPaperScissors.Domain.Interfaces;
using RA.RockPaperScissors.Domain.Entities.LeaderboardAggregate;

namespace RA.RockPaperScissors.Domain.Services;

public class LeaderboardControllerDomainService : ILeaderboardControllerDomainService
{
    private readonly ILeaderboardRepository _leaderboardRepository;

    public LeaderboardControllerDomainService(ILeaderboardRepository leaderboardRepository)
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