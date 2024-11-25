using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RastreamentoWorkshopsWebApi.CQRS.Commands;
using RastreamentoWorkshopsWebApi.CQRS.Queries;

namespace RastreamentoWorkshopsWebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ColaboradoresController : ControllerBase
{
    private readonly IMediator _mediator;

    public ColaboradoresController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateColaborador([FromBody] CreateColaboradorCommand command)
    {
        var id = await _mediator.Send(command);
        return Created(id.ToString(), command);        
    }

    [HttpGet]
    public async Task<IActionResult> GetColaboradores()
    {
        var colaboradores = await _mediator.Send(new GetColaboradoresQuery());
        return Ok(colaboradores);
    }
}

