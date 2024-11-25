using MediatR;
using Microsoft.EntityFrameworkCore;
using RastreamentoWorkshopsWebApi.CQRS.Queries;
using RastreamentoWorkshopsWebApi.Data.Context;
using RastreamentoWorkshopsWebApi.Models.Dtos;

namespace RastreamentoWorkshopsWebApi.CQRS.Handlers;

public class GetColaboradoresQueryHandler : IRequestHandler<GetColaboradoresQuery, List<ColaboradorWorkshopsDto>>
{
    private readonly ApplicationDbContext _context;

    public GetColaboradoresQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ColaboradorWorkshopsDto>> Handle(GetColaboradoresQuery request, CancellationToken cancellationToken)
    {
        var colaboradores = await _context.Colaboradores
            .Include(c => c.Atas)
                .ThenInclude(a => a.Workshop)
            .OrderBy(c => c.Nome)
            .ToListAsync(cancellationToken);

        var result = colaboradores.Select(c => new ColaboradorWorkshopsDto
        {
            ColaboradorId = c.Id,
            Nome = c.Nome,
            Workshops = c.Atas.Select(a => new WorkshopDto
            {
                WorkshopId = a.Workshop.Id,
                Nome = a.Workshop.Nome,
                DataRealizacao = a.Workshop.DataRealizacao,
                Descricao = a.Workshop.Descricao
            }).ToList()
        }).ToList();

        return result;
    }
}
