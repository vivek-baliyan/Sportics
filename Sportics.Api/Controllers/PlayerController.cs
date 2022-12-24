using Microsoft.AspNetCore.Mvc;
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
}