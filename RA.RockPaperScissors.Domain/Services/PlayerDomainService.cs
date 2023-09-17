using RA.RockPaperScissors.Domain.Entities.LeaderboardAggregate;
using RA.RockPaperScissors.Domain.Entities.PlayerAggregate;
using RA.RockPaperScissors.Domain.Interfaces;

namespace RA.RockPaperScissors.Domain.Services;

public class PlayerDomainService : IPlayerDomainService
{
    private readonly ILeaderboardRepository _leaderboardRepository;
    private readonly IPlayerRepository _playerRepository;

    public PlayerDomainService(ILeaderboardRepository leaderboardRepository, IPlayerRepository playerRepository)
    {
        _leaderboardRepository = leaderboardRepository;
        _playerRepository = playerRepository;
    }

    public Player? GetTurnResult(Player player1, Player player2)
    {
        var player1Move = player1.LastMove;
        var player2Move = player2.LastMove;

        if (player1 == player2)
        {
            return null;
        }

        if (
            (player1Move == Enums.RockPaperScissors.Rock && player2Move == Enums.RockPaperScissors.Scissors) ||
            (player1Move == Enums.RockPaperScissors.Paper && player2Move == Enums.RockPaperScissors.Rock) ||
            (player1Move == Enums.RockPaperScissors.Scissors && player2Move == Enums.RockPaperScissors.Paper)
        )
        {
            return player1;
        }

        return player2;
    }

    public void SetPlayerToHuman(Player player)
    {
        var leaderboard = _leaderboardRepository.GetLeaderboard();

        if (leaderboard == null)
        {
            return;
        }

        var players = _playerRepository.SetPlayerToHuman(player, leaderboard);

        var newLeaderboard = Leaderboard.Create(players);

        _leaderboardRepository.SetLeaderboard(newLeaderboard);
    }

    public void AddPlayerScore(Player player)
    {
        var leaderboard = _leaderboardRepository.GetLeaderboard();

        if (leaderboard == null)
        {
            return;
        }

        var players = _playerRepository.AddPlayerScore(player, leaderboard);

        var newLeaderboard = Leaderboard.Create(players);

        _leaderboardRepository.SetLeaderboard(newLeaderboard);
    }
}