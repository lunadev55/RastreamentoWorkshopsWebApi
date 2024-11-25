using MediatR;
using Microsoft.EntityFrameworkCore;
using RastreamentoWorkshopsWebApi.Data.Context;
using RastreamentoWorkshopsWebApi.Models.Dtos;

namespace RastreamentoWorkshopsWebApi.CQRS.Handlers;

public class GetWorkshopsByNameQueryHandler : IRequestHandler<GetWorkshopsByNameQuery, List<WorkshopWithAtaDto>>
{
    private readonly ApplicationDbContext _context;

    public GetWorkshopsByNameQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

     public async Task<List<WorkshopWithAtaDto>> Handle(GetWorkshopsByNameQuery request, CancellationToken cancellationToken)
    {
        var workshops = await _context.Workshops
            .Include(w => w.Ata) // Inclui a ata associada
                .ThenInclude(a => a.Colaboradores) // Inclui os colaboradores da ata
            .Where(w => EF.Functions.Like(w.Nome, $"%{request.WorkshopNome}%")) // Filtra pelo nome do workshop
            .ToListAsync(cancellationToken);

        var result = workshops.Select(w => new WorkshopWithAtaDto
        {
            Nome = w.Nome,
            Descricao = w.Descricao,
            DataRealizacao = w.DataRealizacao,
            Colaboradores = w.Ata?.Colaboradores.Select(c => c.Nome).ToList() ?? new List<string>() // Lista de colaboradores
        }).ToList();

        return result;
    }
}
