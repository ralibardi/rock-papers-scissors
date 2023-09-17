namespace RA.RockPaperScissors.API.Models;

public class PlayerDto
{
    public int Id { get; set; }
    public int Score { get; set; }
    public Enums.RockPaperScissors LastMove { get; set; }
    public bool IsHuman { get; set; }

    public PlayerDto(int id, int score, Enums.RockPaperScissors lastMove, bool isHuman)
    {
        Id = id;
        Score = score;
        LastMove = lastMove;
        IsHuman = isHuman;
    }
}