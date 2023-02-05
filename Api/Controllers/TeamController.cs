using Microsoft.AspNetCore.Mvc;
using Api.Dtos;
using Api.Entities;
using Api.Repository.Interface;
using AutoMapper;

namespace Api.Controllers;

public class TeamController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TeamController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetTeams()
    {
        var teams = await _unitOfWork.Team.GetAll();
        return GetStatus(StatusCodes.Status200OK, string.Empty, _mapper.Map<IEnumerable<TeamDto>>(teams));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeam(int id)
    {
        var team = await _unitOfWork.Team.GetFirstOrDefault(p => p.Id == id);
        if (team == null) return GetStatus(StatusCodes.Status404NotFound, $"Team with Id - {id} not found");

        return GetStatus(StatusCodes.Status200OK, string.Empty, _mapper.Map<TeamDto>(team));
    }

    [HttpPost]
    public async Task<IActionResult> Post(TeamDto teamDto)
    {
        var team = await _unitOfWork.Team.GetFirstOrDefault(t => t.TeamName.ToLower() == teamDto.TeamName.ToLower());
        if (team != null) return GetStatus(StatusCodes.Status400BadRequest, "Team already exists");

        Team newTeam = new()
        {
            TeamName = teamDto.TeamName
        };
        _unitOfWork.Team.Add(newTeam);
        if (await _unitOfWork.Complete())
            return GetStatus(StatusCodes.Status200OK, "Team saved successfully");

        return GetStatus(StatusCodes.Status400BadRequest, "Failed to save team");
    }

    [HttpPut]
    public async Task<IActionResult> Put(TeamDto teamDto)
    {
        var team = await _unitOfWork.Team.GetFirstOrDefault(p => p.Id == teamDto.Id);

        if (team == null) return GetStatus(StatusCodes.Status404NotFound, $"Team with Id - {teamDto.Id} not found");

        _mapper.Map(teamDto, team);

        _unitOfWork.Team.Update(team);
        if (await _unitOfWork.Complete())
            return GetStatus(StatusCodes.Status200OK, "Team updated successfully");

        return GetStatus(StatusCodes.Status400BadRequest, "Failed to updated team");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var team = await _unitOfWork.Team.GetFirstOrDefault(p => p.Id == id);

        if (team == null) return GetStatus(StatusCodes.Status404NotFound, $"Team with Id - {id} not found");

        _unitOfWork.Team.Remove(team);
        if (await _unitOfWork.Complete())
            return GetStatus(StatusCodes.Status200OK, "Team deleted successfully");

        return GetStatus(StatusCodes.Status400BadRequest, "Failed to delete team");
    }
}