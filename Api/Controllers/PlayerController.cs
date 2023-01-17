using Microsoft.AspNetCore.Mvc;
using Sportics.Api.Dtos;
using Sportics.Api.Entities;
using Sportics.Api.Repository.Interface;

namespace Sportics.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayerController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public PlayerController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_unitOfWork.Player.GetAll());
    }

    [HttpPost]
    public IActionResult Post(PlayerDto playerDto)
    {
        var player = new Player()
        {
            PlayerName = playerDto.PlayerName,
            TeamId = playerDto.TeamId
        };
        _unitOfWork.Player.Add(player);
        _unitOfWork.Save();
        return Ok();
    }
}