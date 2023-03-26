using Microsoft.AspNetCore.Mvc;
using Api.Dtos;
using Api.Entities;
using Api.Repository.Interface;
using AutoMapper;

namespace Api.Controllers;

public class PlayerController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PlayerController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetPlayers()
    {
        var players = await _unitOfWork.Player.GetAll("Team");
        return GetStatus(StatusCodes.Status200OK, string.Empty, _mapper.Map<IEnumerable<PlayerDto>>(players));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPlayer(int id)
    {
        var player = await _unitOfWork.Player.GetFirstOrDefault(p => p.Id == id, "Team");
        if (player == null) return GetStatus(StatusCodes.Status404NotFound, $"Player with Id - {id} not found");

        return GetStatus(StatusCodes.Status200OK, string.Empty, _mapper.Map<PlayerDto>(player));
    }

    [HttpPost]
    public async Task<IActionResult> Post(PlayerDto playerDto)
    {
        Player newPlayer = new()
        {
            FirstName = playerDto.FirstName,
            LastName = playerDto.LastName,
            Nationality = playerDto.Nationality,
            Role = playerDto.Role,
            TeamId = playerDto.TeamId
        };
        _unitOfWork.Player.Add(newPlayer);
        if (await _unitOfWork.Complete())
            return GetStatus(StatusCodes.Status200OK, "Player saved successfully");

        return GetStatus(StatusCodes.Status400BadRequest, "Failed to save Player");
    }

    [HttpPut]
    public async Task<IActionResult> Put(PlayerDto playerDto)
    {
        var player = await _unitOfWork.Player.GetFirstOrDefault(p => p.Id == playerDto.Id);

        if (player == null) return GetStatus(StatusCodes.Status404NotFound, $"Player with Id - {playerDto.Id} not found");

        _mapper.Map(playerDto, player);

        _unitOfWork.Player.Update(player);
        if (await _unitOfWork.Complete())
            return GetStatus(StatusCodes.Status200OK, "Player updated successfully");

        return GetStatus(StatusCodes.Status400BadRequest, "Failed to updated Player");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var Player = await _unitOfWork.Player.GetFirstOrDefault(p => p.Id == id);

        if (Player == null) return GetStatus(StatusCodes.Status404NotFound, string.Empty);

        _unitOfWork.Player.Remove(Player);
        if (await _unitOfWork.Complete())
            return GetStatus(StatusCodes.Status200OK, "Player deleted successfully");

        return GetStatus(StatusCodes.Status400BadRequest, "Failed to delete Player");
    }
}