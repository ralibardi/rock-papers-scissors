using RA.RockPaperScissors.Domain.Entities.PlayerAggregate;

namespace RA.RockPaperScissors.Domain.Entities.LeaderboardAggregate;

public interface ILeaderboard
{
    IEnumerable<Player> Players { get; }
}