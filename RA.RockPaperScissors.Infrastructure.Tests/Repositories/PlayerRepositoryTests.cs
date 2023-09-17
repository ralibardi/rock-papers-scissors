namespace RA.RockPaperScissors.Infrastructure.Tests.Repositories;

public class PlayerRepositoryTests
{
    private readonly PlayerRepository _playerRepository;
    private readonly Player _testPlayer;
    private readonly Player _testPlayer2;
    private readonly Leaderboard _testLeaderboard;

    public PlayerRepositoryTests()
    {
        _playerRepository = new PlayerRepository();
        _testPlayer = Player.Create(1,0,Domain.Enums.RockPaperScissors.Rock,false);
        _testPlayer2 = Player.Create(2, 1, Domain.Enums.RockPaperScissors.Paper, true);
        _testLeaderboard = Leaderboard.Create(new List<Player> {_testPlayer, _testPlayer2});
    }

    [Fact]
    public void SetPlayerToHuman_ReturnsListFromRepository()
    {
        // Arrange

        // Act
        var actualEntities = _playerRepository.SetPlayerToHuman(_testPlayer, _testLeaderboard);
        _testPlayer.SetIsHuman(true);
        var expectedEntities = new List<Player> { _testPlayer, _testPlayer2 };

        // Assert
        actualEntities.Should().BeEquivalentTo(expectedEntities);
    }

    [Fact]
    public void AddPlayerScore_ReturnsListFromRepository()
    {
        // Arrange

        // Act
        var actualEntities = _playerRepository.AddPlayerScore(_testPlayer, _testLeaderboard);
        _testPlayer.AddScore(1);
        var expectedEntities = new List<Player> { _testPlayer, _testPlayer2 };

        // Assert
        actualEntities.Should().BeEquivalentTo(expectedEntities);
    }
}