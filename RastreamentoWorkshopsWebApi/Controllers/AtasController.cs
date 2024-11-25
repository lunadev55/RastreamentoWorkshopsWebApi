using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RastreamentoWorkshopsWebApi.CQRS.Commands;

namespace RastreamentoWorkshopsWebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class AtasController : ControllerBase
{
    private readonly IMediator _mediator;

    public AtasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAta([FromBody] CreateAtaCommand command)
    {
        var id = await _mediator.Send(command);
        return Created(id.ToString(), new { Message = "Ata criada com sucesso!" });        
    }

    [HttpPut("{ataId}/colaboradores/{colaboradorId}")]
    public async Task<IActionResult> AddColaboradorToAta(int ataId, int colaboradorId)
    {
        await _mediator.Send(new AddColaboradorToAtaCommand(ataId, colaboradorId));        
        return Ok("Colaborador adicionado a Ata com sucesso!");
    }

    [HttpDelete("{ataId}/colaboradores/{colaboradorId}")]
    public async Task<IActionResult> RemoveColaboradorFromAta(int ataId, int colaboradorId)
    {
        try
        {
            var result = await _mediator.Send(new RemoveColaboradorFromAtaCommand(ataId, colaboradorId));
            if (result)            
                return Ok(new { message = "Colaborador removido da ata com sucesso." });            

            return BadRequest(new { message = "Não foi possível remover o colaborador." });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}

