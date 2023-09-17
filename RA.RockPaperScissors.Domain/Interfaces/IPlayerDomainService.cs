using RA.RockPaperScissors.Domain.Entities.PlayerAggregate;

namespace RA.RockPaperScissors.Domain.Interfaces;

public interface IPlayerDomainService
{
    Player? GetTurnResult(Player player1, Player player2);
    void SetPlayerToHuman(Player player);
    void AddPlayerScore(Player player);
}