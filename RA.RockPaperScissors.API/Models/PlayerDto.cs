namespace RA.RockPaperScissors.API.Models;

public class PlayerDto
{
    public int Id { get; set; }
    public int Score { get; set; }
    public Enums.RockPaperScissors LastMove { get; set; }
    public bool IsHuman { get; set; }

    public static PlayerDto Create(int id, int score, Enums.RockPaperScissors lastMove, bool isHuman) => new()
    {
        Id = id,
        Score = score,
        LastMove = lastMove,
        IsHuman = isHuman
    };
}