using Microsoft.AspNetCore.Mvc;
using Api.Repository.Interface;
using AutoMapper;
using Api.Dtos.Tournament;

namespace Api.Controllers;

public class TournamentController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TournamentController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetTournamentes()
    {
        var tournamentes = await _unitOfWork.Tournament.GetAll();
        return GetStatus(StatusCodes.Status200OK, string.Empty, _mapper.Map<IEnumerable<TournamentDto>>(tournamentes));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTournament(int id)
    {
        var tournament = await _unitOfWork.Tournament.GetFirstOrDefault(p => p.Id == id);
        if (tournament == null) return GetStatus(StatusCodes.Status404NotFound, $"Tournament with Id - {id} not found");

        return GetStatus(StatusCodes.Status200OK, string.Empty, _mapper.Map<TournamentDto>(tournament));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var tournament = await _unitOfWork.Tournament.GetFirstOrDefault(p => p.Id == id);

        if (tournament == null) return GetStatus(StatusCodes.Status404NotFound, $"Tournament with Id - {id} not found");

        _unitOfWork.Tournament.Remove(tournament);
        if (await _unitOfWork.Complete())
            return GetStatus(StatusCodes.Status200OK, "Tournament deleted successfully");

        return GetStatus(StatusCodes.Status400BadRequest, "Failed to delete Tournament");
    }
}