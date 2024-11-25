using MediatR;
using Microsoft.EntityFrameworkCore;
using RastreamentoWorkshopsWebApi.CQRS.Queries;
using RastreamentoWorkshopsWebApi.Data.Context;
using RastreamentoWorkshopsWebApi.Models.Dtos;

namespace RastreamentoWorkshopsWebApi.CQRS.Handlers;
public class GetWorkshopsByDateQueryHandler : IRequestHandler<GetWorkshopsByDateQuery, List<WorkshopWithAtaDto>>
{
    private readonly ApplicationDbContext _context;

    public GetWorkshopsByDateQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<WorkshopWithAtaDto>> Handle(GetWorkshopsByDateQuery request, CancellationToken cancellationToken)
    {
        var workshops = await _context.Workshops
            .Include(w => w.Ata) // Inclui a ata associada
                .ThenInclude(a => a.Colaboradores) // Inclui os colaboradores da ata
            .Where(w => w.DataRealizacao.Date == request.Data.Date) // Filtra pela data do workshop
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
