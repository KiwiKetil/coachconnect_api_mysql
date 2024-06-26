﻿using CoachConnect.BusinessLayer.DTOs.Games;
using CoachConnect.BusinessLayer.Services.Interfaces;
using CoachConnect.Shared.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoachConnect.API.Controllers;

[Route("api/v1/games")]
[ApiController]
public class GamesController : ControllerBase
{
    private readonly IGameService _gameService;
    private readonly ILogger<GamesController> _logger;

    public GamesController(IGameService gameService, ILogger<GamesController> logger)
    {
        _gameService = gameService;
        _logger = logger;
    }

    [Authorize(Roles = "Admin, Coach, User")]
    // https://localhost:7036/api/v1/games
    [HttpGet(Name = "GetAllGames")]
    public async Task<ActionResult<IEnumerable<GameDTO>>> GetAllGames([FromQuery] GameQuery gameQuery)
    {
        _logger.LogDebug("Getting Games");

        var res = await _gameService.GetAllAsync(gameQuery);
        return res != null ? Ok(res) : NotFound("Could not find any games");
    }

    [Authorize(Roles = "Admin, Coach, User")]
    // https://localhost:7036/api/v1/games/2f042e86-d75e-4591-a810-aca808725555
    [HttpGet("{id}", Name = "GetGameById")]
    public async Task<ActionResult<GameDTO>> GetGameById(Guid id)
    {
        _logger.LogDebug("Getting game by ID: {id}", id);

        var game = await _gameService.GetByIdAsync(id);
        return game != null ? Ok(game) : NotFound($"Game with ID '{id}' not found");
    }

    [Authorize(Roles = "Admin, Coach")]
    // https://localhost:7036/api/v1/games/2f042e86-d75e-4591-a810-aca80812cde3
    [HttpPut("{id}", Name = "UpdateGame")]
    public async Task<ActionResult<GameUpdateDTO>> UpdateGame(Guid id, [FromBody] GameUpdateDTO gameUpdateDTO)
    {
        _logger.LogDebug("Updating game with ID: {id}", id);

        string idFromToken = (string)this.HttpContext.Items["UserId"]!;
        bool isAdmin = this.HttpContext.User.IsInRole("Admin");

        var res = await _gameService.UpdateAsync(isAdmin, idFromToken, id, gameUpdateDTO);
        return res != null ? Ok(res) : BadRequest("Could not update game");
    }

    [Authorize(Roles = "Admin, Coach")]
    // https://localhost:7036/api/v1/games/register
    [HttpPost("register", Name = "CreateGame")]
    public async Task<ActionResult<GameRegistrationDTO>> CreateGame([FromBody] GameRegistrationDTO gameRegistrationDTO)
    {
        _logger.LogDebug("Create new Game");

        string idFromToken = (string)this.HttpContext.Items["UserId"]!;        
        bool isAdmin = this.HttpContext.User.IsInRole("Admin");   

        var res = await _gameService.CreateAsync(isAdmin, idFromToken, gameRegistrationDTO);
        return res != null ? Ok(res) : BadRequest("Could not create new game");
    }

    [Authorize(Roles = "Admin, Coach")]
    // https://localhost:7036/api/v1/games/2f042e86-d75e-4591-a810-aca80812cde3
    [HttpDelete("{id}", Name = "DeleteGame")]
    public async Task<ActionResult<GameDTO>> DeleteGame(Guid id)
    {
        _logger.LogDebug("Deleting game with ID: {id}", id);

        string idFromToken = (string)this.HttpContext.Items["UserId"]!;
        bool isAdmin = this.HttpContext.User.IsInRole("Admin");

        var res = await _gameService.DeleteAsync(isAdmin, idFromToken, id);
        return res != null ? Ok(res) : BadRequest("Could not delete game");
    }
}
