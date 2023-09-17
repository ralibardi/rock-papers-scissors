using Microsoft.AspNetCore.Mvc;
using RA.RockPaperScissors.API.Models;
using System.Net;
using Mapster;

namespace RA.RockPaperScissors.API.Controllers;

public class PlayerControllerTests
{
    private readonly Mock<IPlayerDomainService> _mockPlayerDomainService;
    private readonly PlayerController _playerController;
    private readonly PlayerDto _testPlayer;
    private readonly PlayerDto _testPlayer2;

    public PlayerControllerTests()
    {
        Mock<ILogger<PlayerController>> mockLogger = new();
        Mock<ILeaderboardDomainService> mockLeaderboardDomainService = new();
        _mockPlayerDomainService = new Mock<IPlayerDomainService>();
        _playerController = new PlayerController(mockLogger.Object, _mockPlayerDomainService.Object, mockLeaderboardDomainService.Object);
        _testPlayer = new PlayerDto(1, 0, Models.Enums.RockPaperScissors.Rock, false);
        _testPlayer2 = new PlayerDto(2, 1, Models.Enums.RockPaperScissors.Paper, true);
    }

    [Fact]
    public void PatchPlayer_Returns()
    {
        // Arrange
        var patchPlayer = new PlayerDto(_testPlayer.Id, _testPlayer.Score, _testPlayer.LastMove, true);

        // Act
        var response = _playerController.PatchPlayer(_testPlayer.Id, patchPlayer);

        // Assert
        response.Should().BeOfType<OkResult>();
    }

    [Fact]
    public void GetTurnResult_Returns()
    {
        // Arrange
        var players = new List<PlayerDto> {_testPlayer, _testPlayer2};
        _mockPlayerDomainService
            .Setup(x => x.GetTurnResult(_testPlayer.Adapt<Player>(), _testPlayer2.Adapt<Player>()))
            .Returns(_testPlayer2.Adapt<Player>())
            .Verifiable();

        _mockPlayerDomainService
            .Setup(x => x.AddPlayerScore(_testPlayer2.Adapt<Player>()))
            .Verifiable();

        // Act
        var response = _playerController.PostMatch(players);

        // Assert
        response.Should().NotBeNull();
        response.Should().BeOfType<OkObjectResult>();

        var okObjectResult = (OkObjectResult)response;
        okObjectResult.StatusCode.Should().Be((int)HttpStatusCode.OK);
    }
}