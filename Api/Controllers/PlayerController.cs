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
        return Ok(_mapper.Map<IEnumerable<PlayerDto>>(players));
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetPlayers(int id)
    {
        var player = await _unitOfWork.Player.GetFirstOrDefault(p => p.Id == id, "Team");
        return Ok(_mapper.Map<PlayerDto>(player));
    }

    [HttpPost]
    public async Task<IActionResult> Post(PlayerDto playerDto)
    {
        Player player = new()
        {
            FirstName = playerDto.FirstName,
            LastName = playerDto.LastName,
            TeamId = playerDto.TeamId
        };
        _unitOfWork.Player.Add(player);
        if (await _unitOfWork.Complete())
            return Ok("Player saved successfully");

        return BadRequest("Failed to save player");
    }

    [HttpPut]
    public async Task<IActionResult> Put(PlayerDto playerDto)
    {
        var player = await _unitOfWork.Player.GetFirstOrDefault(p => p.Id == playerDto.Id);

        if (player == null) return NotFound();

        player = _mapper.Map<Player>(playerDto);

        _unitOfWork.Player.Update(player);
        if (await _unitOfWork.Complete())
            return Ok("Player updated successfully");

        return BadRequest("Failed to updated player");
    }

    [HttpPost("id")]
    public async Task<IActionResult> Delete(int id)
    {
        var player = await _unitOfWork.Player.GetFirstOrDefault(p => p.Id == id);

        if (player == null) return NotFound();

        _unitOfWork.Player.Remove(player);
        if (await _unitOfWork.Complete())
            return Ok("Player deleted successfully");

        return BadRequest("Failed to delete player");
    }
}