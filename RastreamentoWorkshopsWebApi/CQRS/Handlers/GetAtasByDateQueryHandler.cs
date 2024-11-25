using MediatR;
using Microsoft.EntityFrameworkCore;
using RastreamentoWorkshopsWebApi.CQRS.Queries;
using RastreamentoWorkshopsWebApi.Data.Context;
using RastreamentoWorkshopsWebApi.Models;

namespace RastreamentoWorkshopsWebApi.CQRS.Handlers;

public class GetAtasByDateQueryHandler : IRequestHandler<GetAtasByDateQuery, List<Ata>>
{
    private readonly ApplicationDbContext _context;

    public GetAtasByDateQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Ata>> Handle(GetAtasByDateQuery request, CancellationToken cancellationToken)
    {
        return await _context.Atas
            .Include(a => a.Workshop)
            .Include(a => a.Colaboradores)
            .Where(a => a.Workshop.DataRealizacao.Date == request.Data.Date)
            .ToListAsync(cancellationToken);
    }
}
