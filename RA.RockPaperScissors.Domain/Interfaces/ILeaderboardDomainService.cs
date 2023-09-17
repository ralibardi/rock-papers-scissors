using RA.RockPaperScissors.Domain.Entities.LeaderboardAggregate;

namespace RA.RockPaperScissors.Domain.Interfaces;

public interface ILeaderboardDomainService
{
    Leaderboard? GetLeaderboard();
    void SetLeaderboard(Leaderboard leaderboard);
}