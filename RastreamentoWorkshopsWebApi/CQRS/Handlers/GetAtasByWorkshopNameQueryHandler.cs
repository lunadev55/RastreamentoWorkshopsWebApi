using MediatR;
using Microsoft.EntityFrameworkCore;
using RastreamentoWorkshopsWebApi.CQRS.Queries;
using RastreamentoWorkshopsWebApi.Data.Context;
using RastreamentoWorkshopsWebApi.Models;

namespace RastreamentoWorkshopsWebApi.CQRS.Handlers;

public class GetAtasByWorkshopNameQueryHandler : IRequestHandler<GetAtasByWorkshopNameQuery, List<Ata>>
{
    private readonly ApplicationDbContext _context;

    public GetAtasByWorkshopNameQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Ata>> Handle(GetAtasByWorkshopNameQuery request, CancellationToken cancellationToken)
    {
        return await _context.Atas
            .Include(a => a.Workshop)
            .Include(a => a.Colaboradores)
            .Where(a => a.Workshop.Nome.Contains(request.Nome))
            .ToListAsync(cancellationToken);
    }
}
