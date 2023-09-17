namespace RA.RockPaperScissors.Domain.Entities.PlayerAggregate;

public interface IPlayer
{
    int Id { get; }
    int Score { get; }
    Enums.RockPaperScissors LastMove { get; }
    bool IsHuman { get; }
}