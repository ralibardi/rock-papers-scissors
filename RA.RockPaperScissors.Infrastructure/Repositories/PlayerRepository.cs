using RA.RockPaperScissors.Domain.Entities.LeaderboardAggregate;
using RA.RockPaperScissors.Domain.Entities.PlayerAggregate;

namespace RA.RockPaperScissors.Infrastructure.Repositories;

public class PlayerRepository : IPlayerRepository
{
    public IEnumerable<Player> SetPlayerToHuman(Player player, Leaderboard leaderboard)
    {
        player.SetIsHuman(player.IsHuman);

        var playersList = new List<Player> { player, leaderboard.Players.First(p => p.Id != player.Id) };

        return playersList.OrderBy(p => p.Id).ToList();
    }

    public IEnumerable<Player> AddPlayerScore(Player player, Leaderboard leaderboard)
    {
        player.AddScore(player.Score);

        var playersList = new List<Player> { player, leaderboard.Players.First(p => p.Id != player.Id) };

        return playersList.OrderBy(p => p.Id).ToList();
    }
}