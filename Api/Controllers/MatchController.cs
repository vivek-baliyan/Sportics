using Microsoft.AspNetCore.Mvc;
using Api.Repository.Interface;
using AutoMapper;
using Api.Dtos.Match;
using Api.Entities.Match;

namespace Api.Controllers;

public class MatchController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MatchController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetMatches()
    {
        var matches = await _unitOfWork.Match.GetAll("Team1,Team2");
        return GetStatus(StatusCodes.Status200OK, string.Empty, _mapper.Map<IEnumerable<MatchDto>>(matches));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMatch(int id)
    {
        var match = await _unitOfWork.Match.GetFirstOrDefault(p => p.Id == id);
        if (match == null) return GetStatus(StatusCodes.Status404NotFound, $"Match with Id - {id} not found");

        return GetStatus(StatusCodes.Status200OK, string.Empty, _mapper.Map<MatchDto>(match));
    }

    [HttpPost]
    public async Task<IActionResult> Post(MatchDto matchDto)
    {
        var match = await _unitOfWork.Match.GetFirstOrDefault(t => t.MatchNo == matchDto.MatchNo);
        if (match != null) return GetStatus(StatusCodes.Status400BadRequest, "Match already exists");

        Match newMatch = new()
        {
            MatchNo = matchDto.MatchNo,
            MatchDate = matchDto.MatchDate,
            Venue = matchDto.Venue,
            Team1Id = matchDto.Team1Id,
            Team2Id = matchDto.Team2Id,
            TournamentId = matchDto.TournamentId
        };
        _unitOfWork.Match.Add(newMatch);

        if (await _unitOfWork.Complete())
            return GetStatus(StatusCodes.Status200OK, "Match saved successfully");

        return GetStatus(StatusCodes.Status400BadRequest, "Failed to save Match");
    }

    [HttpPut]
    public async Task<IActionResult> Put(MatchDto MatchDto)
    {
        var Match = await _unitOfWork.Match.GetFirstOrDefault(p => p.Id == MatchDto.Id);

        if (Match == null) return GetStatus(StatusCodes.Status404NotFound, $"Match with Id - {MatchDto.Id} not found");

        _mapper.Map(MatchDto, Match);

        _unitOfWork.Match.Update(Match);
        if (await _unitOfWork.Complete())
            return GetStatus(StatusCodes.Status200OK, "Match updated successfully");

        return GetStatus(StatusCodes.Status400BadRequest, "Failed to updated Match");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var Match = await _unitOfWork.Match.GetFirstOrDefault(p => p.Id == id);

        if (Match == null) return GetStatus(StatusCodes.Status404NotFound, $"Match with Id - {id} not found");

        _unitOfWork.Match.Remove(Match);
        if (await _unitOfWork.Complete())
            return GetStatus(StatusCodes.Status200OK, "Match deleted successfully");

        return GetStatus(StatusCodes.Status400BadRequest, "Failed to delete Match");
    }
}