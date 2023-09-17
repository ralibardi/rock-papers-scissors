namespace RA.RockPaperScissors.Domain.Entities.PlayerAggregate;

public sealed class Player : IPlayer
{
    private Player() { }

    public int Id { get; private set; }
    public int Score { get; private set; }
    public Enums.RockPaperScissors LastMove { get; private set; }

    public bool IsHuman { get; private set; }

    public static Player Create(int id, int score, Enums.RockPaperScissors lastMove, bool isHuman) => new()
    {
        Id = id,
        Score = score,
        LastMove = lastMove,
        IsHuman = isHuman
    };

    public void SetLastMove(Enums.RockPaperScissors move)
    {
        LastMove = move;
    }

    public void AddScore(int score)
    {
        Score = score + 1;
    }

    public void SetIsHuman(bool isHuman)
    {
        IsHuman = isHuman;
    }
}