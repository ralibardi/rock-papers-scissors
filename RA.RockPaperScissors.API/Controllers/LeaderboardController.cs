﻿using Mapster;
using Microsoft.AspNetCore.Mvc;
using RA.RockPaperScissors.API.Models;
using RA.RockPaperScissors.Domain.Entities.LeaderboardAggregate;
using RA.RockPaperScissors.Domain.Interfaces;

namespace RA.RockPaperScissors.API.Controllers;

public class LeaderboardController : BaseController.BaseController
{
    private readonly ILogger<LeaderboardController> _logger;
    private readonly ILeaderboardDomainService _leaderboardDomainService;

    public LeaderboardController(ILogger<LeaderboardController> logger, ILeaderboardDomainService leaderboardDomainService)
    {
        _logger = logger;
        _leaderboardDomainService = leaderboardDomainService;
    }

    [HttpGet("start")]
    [ProducesResponseType(typeof(LeaderboardDto), StatusCodes.Status200OK)]
    public IActionResult GetPlayers()
    {
        _logger.LogInformation(nameof(GetPlayers));

        var player1 = new PlayerDto(1, 0, Models.Enums.RockPaperScissors.None, false);
        var player2 = new PlayerDto(2, 0, Models.Enums.RockPaperScissors.None, false);

        var leaderboard = new LeaderboardDto
        (
            new List<PlayerDto> { player1, player2 }
        );

        _leaderboardDomainService.SetLeaderboard(leaderboard.Adapt<Leaderboard>());

        return Ok(leaderboard);
    }

    [HttpGet]
    [ProducesResponseType(typeof(LeaderboardDto), StatusCodes.Status200OK)]
    public IActionResult GetLeaderboard()
    {
        _logger.LogInformation(nameof(GetLeaderboard));

        var leaderboard = _leaderboardDomainService.GetLeaderboard().Adapt<LeaderboardDto>();

        return Ok(leaderboard);
    }
}