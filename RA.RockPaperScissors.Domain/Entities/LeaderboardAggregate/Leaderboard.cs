using RA.RockPaperScissors.Domain.Entities.PlayerAggregate;

namespace RA.RockPaperScissors.Domain.Entities.LeaderboardAggregate;

public sealed class Leaderboard : ILeaderboard
{
    private Leaderboard() { }
    public IEnumerable<Player> Players { get; private set; }

    public static Leaderboard Create(IEnumerable<Player> players) => new()
    {
        Players = players
    };
}