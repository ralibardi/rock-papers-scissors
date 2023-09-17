namespace RA.RockPaperScissors.Domain.Services;

public class LeaderboardDomainServiceTests
{
    private readonly Mock<ILeaderboardRepository> _mockLeaderboardRepository;
    private readonly Leaderboard _testLeaderboard;

    public LeaderboardDomainServiceTests()
    {
        _mockLeaderboardRepository = new Mock<ILeaderboardRepository>();
        var testPlayer = Player.Create(1, 0, Enums.RockPaperScissors.Rock, false);
        var testPlayer2 = Player.Create(2, 1, Enums.RockPaperScissors.Paper, true);
        _testLeaderboard = Leaderboard.Create(new List<Player> { testPlayer, testPlayer2 });
    }

    [Fact]
    public void GetLeaderboard_ReturnsList()
    {
        // Arrange
        _mockLeaderboardRepository
            .Setup(x => x.GetLeaderboard())
            .Returns(_testLeaderboard);

        // Act
        var actualEntities = _mockLeaderboardRepository.Object.GetLeaderboard();

        // Assert
        actualEntities.Should().BeEquivalentTo(_testLeaderboard);
    }

    [Fact]
    public void SetLeaderboard_Returns()
    {
        // Arrange
        _mockLeaderboardRepository
            .Setup(x => x.SetLeaderboard(_testLeaderboard))
            .Verifiable();

        // Act
        _mockLeaderboardRepository.Object.SetLeaderboard(_testLeaderboard);

        // Assert
        _mockLeaderboardRepository.Verify();
    }
}