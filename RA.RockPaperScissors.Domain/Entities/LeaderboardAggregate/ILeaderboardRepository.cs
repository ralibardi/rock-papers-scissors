namespace RA.RockPaperScissors.Domain.Entities.LeaderboardAggregate;

public interface ILeaderboardRepository
{
    Leaderboard? GetLeaderboard();
    void SetLeaderboard(Leaderboard leaderboard);
}