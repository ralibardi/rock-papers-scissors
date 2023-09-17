using RA.RockPaperScissors.Domain.Entities.LeaderboardAggregate;

namespace RA.RockPaperScissors.Domain.Entities.PlayerAggregate;

public interface IPlayerRepository
{
    IEnumerable<Player> SetPlayerToHuman(Player player, Leaderboard leaderboard);
    IEnumerable<Player> AddPlayerScore(Player player, Leaderboard leaderboard);
}