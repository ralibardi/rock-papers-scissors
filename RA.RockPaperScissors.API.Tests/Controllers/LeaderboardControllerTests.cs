using Microsoft.AspNetCore.Mvc;
using RA.RockPaperScissors.API.Models;
using System.Net;
using Mapster;
using RA.RockPaperScissors.Domain.Entities.LeaderboardAggregate;

namespace RA.RockPaperScissors.API.Controllers;

public class LeaderboardControllerTests 
{
    private readonly Mock<ILeaderboardDomainService> _mockLeaderboardDomainService;
    private readonly LeaderboardController _leaderboardController;
    private readonly PlayerDto _testPlayer;
    private readonly PlayerDto _testPlayer2;

    public LeaderboardControllerTests()
    {
        Mock<ILogger<LeaderboardController>> mockLogger = new();
        _mockLeaderboardDomainService = new Mock<ILeaderboardDomainService>();
        _leaderboardController = new LeaderboardController(mockLogger.Object, _mockLeaderboardDomainService.Object);
        _testPlayer = new PlayerDto(1, 0, Models.Enums.RockPaperScissors.Rock, false);
        _testPlayer2 = new PlayerDto(2, 1, Models.Enums.RockPaperScissors.Paper, true);
    }

    [Fact]
    public void GetPlayers_Returns()
    {
        // Arrange
        var expectedEntity = new LeaderboardDto
        (
        new List<PlayerDto> { _testPlayer, _testPlayer2 }
        );
        _mockLeaderboardDomainService.Setup(x => x.SetLeaderboard(expectedEntity.Adapt<Leaderboard>())).Verifiable();

        // Act
        var response = _leaderboardController.GetPlayers();

        // Assert
        response.Should().NotBeNull();
        response.Should().BeOfType<OkObjectResult>();

        var okObjectResult = (OkObjectResult)response;
        okObjectResult.StatusCode.Should().Be((int)HttpStatusCode.OK);
    }

    [Fact]
    public void GetLeaderboard_Returns()
    {
        // Arrange
        var expectedEntity = new LeaderboardDto
        (
            new List<PlayerDto> { _testPlayer, _testPlayer2 }
        );
        _mockLeaderboardDomainService.Setup(x => x.GetLeaderboard()).Returns(expectedEntity.Adapt<Leaderboard>()).Verifiable();

        // Act
        var response = _leaderboardController.GetLeaderboard();

        // Assert
        _mockLeaderboardDomainService.VerifyAll();
        response.Should().NotBeNull();
        response.Should().BeOfType<OkObjectResult>();

        var okObjectResult = (OkObjectResult)response;
        okObjectResult.StatusCode.Should().Be((int)HttpStatusCode.OK);
    }
}