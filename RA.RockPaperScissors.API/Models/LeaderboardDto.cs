namespace RA.RockPaperScissors.API.Models;

public class LeaderboardDto
{
    public IEnumerable<PlayerDto> Players { get; set; }
}