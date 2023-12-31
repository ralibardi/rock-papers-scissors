﻿using Mapster;
using Microsoft.AspNetCore.Mvc;
using RA.RockPaperScissors.API.Models;
using RA.RockPaperScissors.Domain.Entities.PlayerAggregate;
using RA.RockPaperScissors.Domain.Interfaces;

namespace RA.RockPaperScissors.API.Controllers;

public class PlayerController : BaseController.BaseController
{
    private readonly ILogger<PlayerController> _logger;
    private readonly IPlayerDomainService _playerDomainService;

    public PlayerController(ILogger<PlayerController> logger, IPlayerDomainService playerDomainService, ILeaderboardDomainService leaderboardDomainService)
    {
        _logger = logger;
        _playerDomainService = playerDomainService;
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(typeof(PlayerDto), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public IActionResult PatchPlayer(int id, [FromBody] PlayerDto patchDto)
    {
        _logger.LogInformation(nameof(PostMatch));

        _playerDomainService.SetPlayerToHuman(patchDto.Adapt<Player>());

        return Ok();
    }

    [HttpPost("match")]
    [ProducesResponseType(typeof(PlayerDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public IActionResult PostMatch([FromBody] IEnumerable<PlayerDto> players)
    {
        _logger.LogInformation(nameof(PostMatch));

        var winner = _playerDomainService.GetTurnResult(players.First().Adapt<Player>(), players.Last().Adapt<Player>());

        _playerDomainService.AddPlayerScore(winner);

        return Ok(winner.Adapt<PlayerDto>());
    }
}