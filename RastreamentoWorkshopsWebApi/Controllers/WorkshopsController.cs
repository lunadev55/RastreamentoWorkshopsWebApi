using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RastreamentoWorkshopsWebApi.CQRS.Commands;
using RastreamentoWorkshopsWebApi.CQRS.Queries;

namespace RastreamentoWorkshopsWebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class WorkshopsController : ControllerBase
{
    private readonly IMediator _mediator;

    public WorkshopsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateWorkshop([FromBody] CreateWorkshopCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetWorkshops), new { id }, id);
    }

    [HttpGet]
    public async Task<IActionResult> GetWorkshops()
    {
        var workshops = await _mediator.Send(new GetWorkshopsQuery());
        return Ok(workshops);
    }

    [HttpGet("GetByName")]
    public async Task<IActionResult> GetWorkshopsByName([FromQuery] string workshopNome)
    {
        if (string.IsNullOrWhiteSpace(workshopNome))        
            return BadRequest("O nome do workshop deve ser informado.");        

        var query = new GetWorkshopsByNameQuery(workshopNome);
        var result = await _mediator.Send(query);

        if (result == null || !result.Any())        
            return NotFound("Nenhum workshop encontrado com o nome especificado.");        

        return Ok(result);
    }

    [HttpGet("GetByDate")]
    public async Task<IActionResult> GetWorkshopsByDate([FromQuery] DateTime data)
    {
        if (data == default)        
            return BadRequest("A data do workshop deve ser informada.");        

        var query = new GetWorkshopsByDateQuery(data);
        var result = await _mediator.Send(query);

        if (result == null || !result.Any())        
            return NotFound("Nenhum workshop encontrado para a data especificada.");        

        return Ok(result);
    }
}

