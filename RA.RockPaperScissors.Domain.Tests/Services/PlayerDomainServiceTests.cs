namespace RA.RockPaperScissors.Domain.Services;

public class PlayerDomainServiceTests 
{
    private readonly Mock<IPlayerRepository> _mockPlayerRepository;
    private readonly Player _testPlayer;
    private readonly Player _testPlayer2;
    private readonly Leaderboard _testLeaderboard;
    private readonly IEnumerable<Player> _testPlayers;

    public PlayerDomainServiceTests()
    {
        _mockPlayerRepository = new Mock<IPlayerRepository>();
        _testPlayer = Player.Create(1, 0, Enums.RockPaperScissors.Rock, false);
        _testPlayer2 = Player.Create(2, 1, Enums.RockPaperScissors.Paper, true);
        _testPlayers = new List<Player> { _testPlayer, _testPlayer2 };
        _testLeaderboard = Leaderboard.Create(_testPlayers);

    }

    [Fact]
    public void GetPlayer_ReturnsList()
    {
        // Arrange
        _testPlayer.AddScore(1);
        var array = new[] { _testPlayer, _testPlayer2 };
        _mockPlayerRepository
            .Setup(x => x.AddPlayerScore(_testPlayer, _testLeaderboard))
            .Returns(array);

        // Act
        var actualEntities = _mockPlayerRepository.Object.AddPlayerScore(_testPlayer, _testLeaderboard);

        // Assert
        actualEntities.Should().BeEquivalentTo(array);
    }

    [Fact]
    public void SetPlayer_Returns()
    {
        // Arrange
        _testPlayer.SetIsHuman(true);
        var array = new[] { _testPlayer, _testPlayer2 };
        _mockPlayerRepository
            .Setup(x => x.SetPlayerToHuman(_testPlayer, _testLeaderboard))
            .Returns(array);

        // Act
        var actualEntities = _mockPlayerRepository.Object.SetPlayerToHuman(_testPlayer, _testLeaderboard);

        // Assert
        actualEntities.Should().BeEquivalentTo(array);
    }
}