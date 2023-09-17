using RA.RockPaperScissors.Domain.Entities.LeaderboardAggregate;

namespace RA.RockPaperScissors.Domain.Interfaces;

public interface ILeaderboardControllerDomainService
{
    Leaderboard? GetLeaderboard();
    void SetLeaderboard(Leaderboard leaderboard);
}